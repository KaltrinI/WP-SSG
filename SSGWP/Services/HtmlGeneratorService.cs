using Microsoft.AspNetCore.Http;
using SSGWP.Models.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSGWP.Services
{
    public class HtmlGeneratorService
    {

        private static readonly string userId= "9c87856f-f670-44c4-afc6-43dd8612b1b0";
        private static readonly string apiKey = "43a70456-96f0-4373-8426-ff0d01ba6813";
        public async Task<string> GenerateHtmlResponse<T>(T template) where T : BaseTemplate
        {
            String pageContent = template.TransformText();
            return pageContent;
        }

        public async Task<string> GenerateImageForHTML(string html)
        {
            byte[] result;

            using (var client = new WebClient())
            {
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userId}:{apiKey}"));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;

                result = client.UploadValues(
                    "https://hcti.io/v1/image",
                    "POST",
                    new System.Collections.Specialized.NameValueCollection()
                    {
                        { "html", html }
                    }
                    );
            }
            string resultString = System.Text.Encoding.UTF8.GetString(result);
            return resultString;
            

        }
    }
}
