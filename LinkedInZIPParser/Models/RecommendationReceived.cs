namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class RecommendationReceived
    {
        public string RecommenderFirstName { get; set; }
        public string RecommenderLastName { get; set; }
        public string RecommendationDate { get; set; }
        public string Recommendation { get; set; }
        public string RecommenderCompany { get; set; }
        public string RecommenderTitle { get; set; }
        [ColumnMapping(FieldName = "Recommendationstatus")]
        public string RecommendationStatus { get; set; }
    }
}