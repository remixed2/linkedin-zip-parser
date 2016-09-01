namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Language
    {
        public string Name { get; set; }
        public string Proficiency { get; set; }
       
    }
}