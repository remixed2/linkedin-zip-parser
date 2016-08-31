namespace LinkedInZIPParser.Attributes
{
    using System;

    public class ColumnMappingAttribute : Attribute
    {
        public string FieldName { get; set; }
    }
}