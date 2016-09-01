namespace LinkedInZIPParser.Extensions
{
    using Attributes;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    public static class DataTableToListExtension
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            /* Get the column convention */
            var convention = GetConvention<T>();

            /* Set field names to parse */
            var propertyNames = GetPropertyMapping<T>();

            /* Process the rows */
            List<T> returnList = new List<T>();

            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                T returnObject = new T();

                for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                {
                    var columnName = ApplyConvention(convention, table.Columns[colIndex].ColumnName);

                    if (propertyNames.ContainsKey(columnName)) {
                        var property = propertyNames[columnName];
                        property.SetValue(returnObject, FieldToObject(table.Rows[rowIndex][colIndex], property.PropertyType), null);
                    }
                }
                returnList.Add(returnObject);
            }
            return returnList;
        }

        public static T ToSingle<T>(this DataTable table) where T : new()
        {
            const int rowIndex = 0;

            if (table.Rows.Count == 0)
                return default(T);

            /* Get the column convention */
            var convention = GetConvention<T>();

            /* Set field names to parse */
            var propertyNames = GetPropertyMapping<T>();

            /* Process the first row */
            T returnObject = new T();

            for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
            {
                var columnName = ApplyConvention(convention, table.Columns[colIndex].ColumnName);
                if (propertyNames.ContainsKey(columnName))
                {
                    var property = propertyNames[columnName];
                    property.SetValue(returnObject, FieldToObject(table.Rows[rowIndex][colIndex], property.PropertyType), null);
                }
            }

            return returnObject;
        }

        private static ColumnMappingConventionAttribute.Conventions GetConvention<T>() {
            /* Read the class naming convention */
            var columnMappingConventionAttribute = (ColumnMappingConventionAttribute)typeof(T).GetCustomAttribute(typeof(ColumnMappingConventionAttribute), false);

            return columnMappingConventionAttribute != null ? columnMappingConventionAttribute.Convention : ColumnMappingConventionAttribute.Conventions.NONE;
        }

        private static string ApplyConvention(ColumnMappingConventionAttribute.Conventions convention, string name)
        {
            switch (convention)
            {
                case ColumnMappingConventionAttribute.Conventions.NONE:
                    return name;
                case ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE:
                    return name.Replace(" ", "");
                default:
                    return name;
            }
        }

        private static object FieldToObject(object obj, Type type)
        {
            if (type == typeof(int))
            {
                int output = 0;
                int.TryParse(obj.ToString(), out output);
                return output;
            }
            else if (type == typeof(bool))
            {
                try
                {
                    return Convert.ToBoolean(obj);
                }
                catch { return false; }
            }
            else
            {
                return obj;
            }
        }

        private static Dictionary<string, PropertyInfo> GetPropertyMapping<T>() where T : new()
        {
            /* Set field names to parse */
            T testObject = new T();
            var properties = testObject.GetType().GetProperties();
            var propertyNames = new Dictionary<string, PropertyInfo>(properties.Length);
            foreach (var property in properties)
            {
                var fieldName = property.Name;
                var columnMappingAttribute = (ColumnMappingAttribute)property.GetCustomAttribute(typeof(ColumnMappingAttribute), false);

                if (columnMappingAttribute != null)
                {
                    fieldName = columnMappingAttribute.FieldName;
                }

                if (!propertyNames.ContainsKey(fieldName))
                    propertyNames.Add(fieldName, property);
            }

            return propertyNames;
        }
    }
}