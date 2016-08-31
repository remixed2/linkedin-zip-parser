namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string CreatedDate { get; set; }
        public string BirthDate { get; set; }
        public string ContactInstructions { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Industry { get; set; }
        public string Association { get; set; }
    }
}