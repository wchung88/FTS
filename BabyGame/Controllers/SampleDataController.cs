using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BabyGame.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static Card[] cards = new[]
        {
            new Card{ Title = "Ball", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ec/Soccer_ball.svg"},
            new Card{ Title = "Car", ImageUrl = "http://trottingmaregarage.co.uk/wp-content/uploads/2017/08/Car.png"}
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<Card> Cards()
        {
            return cards;
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

        public class Card
        {
            public string Title { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
