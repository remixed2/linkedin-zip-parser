﻿namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Project
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}