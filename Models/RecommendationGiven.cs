namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class RecommendationGiven
    {
        public string RecommendeeFirstName { get; set; }
        public string RecommendeeLastName { get; set; }
        public string RecommendationDate { get; set; }
        public string Recommendation { get; set; }
        public string RecommendeeCompany { get; set; }
        public string RecommendeeTitle { get; set; }
    }
}