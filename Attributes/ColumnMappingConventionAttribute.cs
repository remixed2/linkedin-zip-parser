namespace LinkedInZIPParser.Attributes
{
    using System;

    public class ColumnMappingConventionAttribute : Attribute
    {
        public enum Conventions
        {
            NONE = 0,
            REMOVE_WHITESPACE = 1
        }

        public Conventions Convention { get; set; }
    }
}