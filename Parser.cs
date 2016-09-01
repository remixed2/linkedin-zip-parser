namespace LinkedInZIPParser
{
    using Extensions;
    using Ionic.Zip;
    using KBCsv;
    using Models;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;

    public static class Parser
    {
        /// <summary>
        /// Parses a ZIP file located in the filesystem
        /// </summary>
        /// <param name="path">Uri of the ZIP file</param>
        /// <returns>An INFO object with the nested properties populated correctly</returns>
        public static Info Parse(string path)
        {
            using (ZipFile zipFile = ZipFile.Read(path))
            {
                return Parse(zipFile);
            }
        }

        /// <summary>
        /// Parses an input ZIP stream 
        /// </summary>
        /// <param name="stream">Input ZIP stream </param>
        /// <returns>An INFO object with the nested properties populated correctly</returns>
        public static Info Parse(Stream stream)
        {
            using (ZipFile zipFile = ZipFile.Read(stream))
            {
                return Parse(zipFile);
            }
        }

        #region Private Methods

        /// <summary>
        /// Do the parsing of the whole ZIP stream and return a INFO object
        /// </summary>
        /// <param name="zipFile">Input ZIP stream</param>
        /// <returns>A single INFO record with all the nested properties filled from the ZIP.</returns>
        private static Info Parse(ZipFile zipFile)
        {
            var info = new Info();

            info.Profile = ReadSingle<Profile>(zipFile, @"Profile.csv");
            info.RegistrationInfo = ReadSingle<RegistrationInfo>(zipFile, @"Registration Info.csv");
            info.Certifications = ReadMultiple<Certification>(zipFile, @"Certifications.csv");
            info.Connections = ReadMultiple<Connection>(zipFile, @"Connections.csv");
            info.Contacts = ReadMultiple<Contact>(zipFile, @"Contacts.csv");
            info.Courses = ReadMultiple<Course>(zipFile, @"Courses.csv");
            info.Education = ReadMultiple<Education>(zipFile, @"Education.csv");
            info.Inbox = ReadMultiple<Inbox>(zipFile, @"Inbox.csv");
            info.Invitations = ReadMultiple<Inbox>(zipFile, @"Invitations.csv");
            info.Languages = ReadMultiple<Language>(zipFile, @"Languages.csv");
            info.PhoneNumbers = ReadMultiple<PhoneNumber>(zipFile, @"PhoneNumbers.csv");
            info.Positions = ReadMultiple<Position>(zipFile, @"Positions.csv");
            info.Projects = ReadMultiple<Project>(zipFile, @"Projects.csv");
            info.RecommendationsReceived = ReadMultiple<RecommendationReceived>(zipFile, @"Recommendations Received.csv");
            info.RecommendationsGiven = ReadMultiple<RecommendationGiven>(zipFile, @"Recommendations Given.csv");
            info.Skills = ReadMultiple<Skill>(zipFile, @"Skills.csv");

            return info;
        }

        /// <summary>
        /// Parse the CSV file from the ZIP stream and returns a single T result
        /// </summary>
        /// <typeparam name="T">Any 'Models' model</typeparam>
        /// <param name="zipFile">Input ZIP stream</param>
        /// <param name="csvFile">Name of the CSV file inside the ZIP stream</param>
        /// <returns>A single T record</returns>
        private static T ReadSingle<T>(ZipFile zipFile, string csvFile) where T : new()
        {
            ZipEntry entry = zipFile[csvFile];

            if (entry == null)
                return default(T);
            else
            {
                using (var reader = new CsvReader(entry.OpenReader()))
                using (var table = new DataTable())
                {
                    reader.ReadHeaderRecord();
                    table.Fill(reader);

                    return table.ToSingle<T>();
                }
            }
        }

        /// <summary>
        /// Parse the CSV file from the ZIP stream and returns a list of results
        /// </summary>
        /// <typeparam name="T">Any 'Models' model</typeparam>
        /// <param name="zipFile">Input ZIP stream</param>
        /// <param name="csvFile">Name of the CSV file inside the ZIP stream</param>
        /// <returns>A list of T records</returns>
        private static List<T> ReadMultiple<T>(ZipFile zipFile, string csvFile) where T : new()
        {
            ZipEntry entry = zipFile[csvFile];

            if (entry == null)
                return new List<T>();
            else
            {
                using (var reader = new CsvReader(entry.OpenReader()))
                using (var table = new DataTable())
                {
                    reader.ReadHeaderRecord();
                    table.Fill(reader);

                    return table.ToList<T>();
                }
            }
        }

        #endregion

    }
}
