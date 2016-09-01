namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Connection
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CurrentCompany { get; set; }
        public string CurrentPosition { get; set; }
    }
}