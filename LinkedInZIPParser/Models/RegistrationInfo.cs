namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class RegistrationInfo
    {
        public string RegistrationDate { get; set; }
        public string RegistrationIP { get; set; }
        public string SubscriptionType { get; set; }
        public string InviterFirstName { get; set; }
        public string InviterLastName { get; set; }
    }
}