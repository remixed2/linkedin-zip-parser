namespace LinkedInZIPParser.Models
{
    using System.Collections.Generic;

    public class Info
    {
        public Profile Profile { get; set; }
        public RegistrationInfo RegistrationInfo { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Course> Courses { get; set; }
        public List<Education> Education { get; set; }
        public List<Language> Languages { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Position> Positions { get; set; }
        public List<Project> Projects { get; set; }
        public List<RecommendationReceived> RecommendationsReceived { get; set; }
        public List<RecommendationGiven> RecommendationsGiven { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Connection> Connections { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Inbox> Inbox { get; set; }
        public List<Inbox> Invitations { get; set; }
    }
}