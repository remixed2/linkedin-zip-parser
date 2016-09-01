namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Certification
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Authority { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LicenseNumber { get; set; }
    }
}