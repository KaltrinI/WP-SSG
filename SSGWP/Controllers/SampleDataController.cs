using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSGWP.Models.Templates.Aqua;
using SSGWP.Services;

namespace SSGWP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private HtmlGeneratorService service = new HtmlGeneratorService();
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("aqua")]
        public string AquaTheme()
        {
            return JsonConvert.SerializeObject(new Aqua("test",true));
        }

        [HttpPost("update/aqua")]
        public async Task<string> UpdateAquaTheme([FromBody] Dictionary<string, string> props)
        {
            var aqua = new Aqua(props["SiteName"] as string);
            aqua.FillProps(props);
            var res= await service.GenerateImageForHTML(aqua.TransformText());
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(res);
            return dict["url"];
        }


        [HttpPost("aqua")]
        public async Task<string> SubmitAquaTheme([FromBody] Dictionary<string,string> props)
        {
            var aqua = new Aqua(props["SiteName"]);
            aqua.FillProps(props);
            var res=await service.GenerateHtmlResponse(aqua);
            return res;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}

