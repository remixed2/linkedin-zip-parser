namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class PhoneNumber
    {
        public string Number { get; set; }
        public string Extension { get; set; }
        public string Type { get; set; }
    }
}