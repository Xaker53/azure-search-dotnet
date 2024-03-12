using AzureSearch.Quickstart;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}
        private ConnectAzure connect = new();
        [HttpPost(Name = "GetWeatherForecast")]
        public List<Files> Get([FromBody] string model)
        {
            List<Files> list = null;
            if (connect != null)
            {
                list = connect.ConnectSearchFiles(model);
            }
            return list;
        }
    }
}
