# Build status
master [![Build status](https://ci.appveyor.com/api/projects/status/wtxhmtu93xca6i1c/branch/master?svg=true)](https://ci.appveyor.com/project/remixed2/linkedin-zip-parser/branch/master)
Inspired by https://github.com/JMPerez/linkedin-to-json-resume

# linkedin-zip-parser
Simple library to parse the linkedIn export ZIP file. This file contains all the data from your account including:
- Profile
- Certifications
- Contacts
- Courses
- Education
- Skills
- Languages
- PhoneNumbers
- Positions
- Projects
- Recommendation Given
- Recommendation Received
- Registration Info
- Inbox messages
The ZIP file contains a bunch of CSV files and a folder with all the media files used in your profile or messages. The parser reads all these CSV files and assemblies an output INFO object with all the above mentioned data as fields.

# How to backup your personal data from linkedIn
- Go to the Data Export Page on LinkedIn and click on "Request archive".
- Most of the data will be available almost inmediately, as soon as you get an email from linkedIn.
- The remaining data, including your posts and comments will be available somewhere between 24h and 72h. However, this parser only parses the data in the first ZIP file.

# How to use the library
## From a local file
```csharp
Using LinkedInZIPParser;
Using LinkedInZIPParser.Models;

Info info = Parser.Parse(PATH_OF_ZIP_FILE);
```

## From an input stream
```csharp
Using System.IO;
Using LinkedInZIPParser;
Using LinkedInZIPParser.Models;

Info info = null;
using (var stream = File.OpenRead(PATH_OF_ZIP_FILE)) {
    info = Parser.Parse(stream);
}
```
... or ...
```csharp
Using LinkedInZIPParser;
Using LinkedInZIPParser.Models;

Info info = null;
using (var stream = await Request.Content.ReadAsStreamAsync()) {
    info = Parser.Parse(stream);
}
```

