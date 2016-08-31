using LinkedInZIPParser.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace LinkedInZIPParser.api.Controllers
{
    [RoutePrefix("parser")]
    public class ParserController : ApiController
    {
        //public Info Get() {

        //    const string zip = @"C:\_test_data\zip.zip";

        //    return Parser.Parse(zip);
        //}

        [Route("")]
        public async Task<Info> Post()
        {
            using (var stream = await Request.Content.ReadAsStreamAsync()) {
                return Parser.Parse(stream);
            }
        }
    }
}
