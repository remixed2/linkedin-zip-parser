namespace LinkedInZIPParser.Models
{
    using Attributes;

    [ColumnMappingConvention(Convention = ColumnMappingConventionAttribute.Conventions.REMOVE_WHITESPACE)]
    public class Course
    {
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
       
    }
}