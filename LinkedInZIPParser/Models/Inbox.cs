namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Inbox
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Direction { get; set; }
        public string Folder { get; set; }
    }
}