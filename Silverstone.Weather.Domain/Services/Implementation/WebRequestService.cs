using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Silverstone.Weather.Domain.Services.Implementation
{
    public class WebRequestService : IWebRequestService
    {
        /// <summary>
        /// Perform a simple Get Web Request via the given Uri
        /// </summary>
        /// <param name="uri">Uri containing the url to make the web request on</param>
        /// <returns>A string of the result from the web request</returns>
        public async Task<string> GetAsync(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using(var reader = new StreamReader(stream))
                        {
                            return await reader.ReadToEndAsync();
                        }
                    }
                }
            }

            return null;
        }
    }
}