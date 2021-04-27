using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// value: 6pS-kPti98-IB~EJS~~8YFZUg_Ge4n4.B2
// id: 6a69737a-49c3-4ddc-ac25-f0de24f35732
//# Replace {tenant} with your tenant!
//curl -X POST -H "Content-Type: application/x-www-form-urlencoded" -d 'client_id=65832151-79a3-4033-88b6-f78f2e683e04&scope=api%3A%2F%2F9efa84a8-e42e-49c1-8ba6-c7563417d817%2F.default&client_secret=6pS-kPti98-IB~EJS~~8YFZUg_Ge4n4.B2&grant_type=client_credentials' 'https://login.microsoftonline.com/9e39049b-8d44-443e-af95-efab838bd9b9/oauth2/v2.0/token'

namespace webapi.Controllers
{
    [ApiController]
    [Authorize(Policy = "ApplicationPolicy")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var random = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                Temperature = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)]
            });
        }
    }
}
