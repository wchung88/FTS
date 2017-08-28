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

        private static Card[] GeneralCards = new[]
        {
            new Card{ Title = "Ball", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ec/Soccer_ball.svg"},
            new Card{ Title = "Car", ImageUrl = "http://trottingmaregarage.co.uk/wp-content/uploads/2017/08/Car.png"},
            new Card{ Title = "Shoe", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHyjSQqNveV1ywzszD9J4pmODmn_hmuP4KqJWuZ_OtpoDKKKRS"},
            new Card{ Title = "Tree", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFePMTXAcB-SsAUs9e73zV_dgB_c12Prh0I7xI7Aef1rlaF_nL8g"},
            new Card{Title= "TV", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.bzN1Pnbh08kQFTaEt_Q53QEsD0&pid=15.1&P=0&w=195&h=160"},
            new Card {Title = "Plane", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.G89eDI1KdEi1ZwPCCIZnSgGDCh&pid=15.1&P=0&w=381&h=159"},
            new Card {Title = "Bird", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.F-dZ2WG24SVnG2M4hamOIwEsDL&pid=15.1&P=0&w=248&h=169"},
            new Card {Title = "Cup", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.jv7t5yz9zi_8-wuaRkC6WwEsDc&pid=15.1&P=0&w=226&h=167"},
            new Card {Title = "Table", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.9uvBZ1hvhWXt0Kugdua1TQEsDB&pid=15.1&P=0&w=258&h=167"},
            new Card {Title = "Moon", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.Vtx4EgelwPqTRH699C9dLgEsEs&pid=15.1&P=0&w=300&h=300"},
            new Card { Title = "Bike", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.xGuQhZBOCeTdC-cIXhgNQwD6D6&pid=15.1&P=0&w=300&h=300"},
            new Card { Title = "Flower", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.PE6kwhCuojmF8Z_wfeNPJwEsDI&pid=15.1&P=0&w=257&h=172"}
        };

        private static Card[] NumericCards = new[]
        {
            new Card{ Title = "Number 1", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.mNhMnGJLNXbZeMgn0HgHmADnEs&pid=15.1&P=0&w=300&h=300"},
            new Card{ Title = "Numbers 2", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.4jo9kd1WrCwxBhCMPWxWqgD6D6&pid=15.1&P=0&w=300&h=300"},
            new Card{ Title = "Number 3", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.2KbDpKvdKTWCjQeMBqYWVQDnEs&pid=15.1&P=0&w=300&h=300"},
            new Card{ Title = "Number 4", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.bsh0NvjI0JHD93ITFeDh0gEsEs&pid=15.1&P=0&w=300&h=300"},
            new Card{ Title = "Number 5", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.D0yWzi7a8Ovtfkxnu1ta8wDnEs&pid=15.1&P=0&w=300&h=300"},
            new Card {Title = "Number 6", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.Wesa1hGi1R22O2Smr2kxlQEsEs&pid=15.1&P=0&w=300&h=300"},
            new Card {Title = "Number 7", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.vArf07pJ8cAILR8NetDR2gDnEs&pid=15.1&P=0&w=300&h=300"},
            new Card {Title = "Number 8", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.vRE8gFdn9ZOzQr7e-sy53gDnEs&pid=15.1&P=0&w=300&h=300"},
            new Card {Title = "Number 9", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.PudxPc1y9gewaSFtVY6n4AEsEs&pid=15.1&P=0&w=300&h=300"},
            new Card {Title = "Number 10", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.aplAA8ilmd0E5W67LtpHKABVBg&pid=15.1&P=0&w=300&h=300"},
            new Card { Title = "Number 11", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.byIaRc1MTfnkzNGbtCa74AEsEs&pid=15.1&P=0&w=300&h=300"},
            new Card { Title = "Number 12", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.eFE-ZT0s8lXlw7wh4zTRtgEsEs&pid=15.1&P=0&w=300&h=300"}
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

        [HttpGet("[action]/{category}")]
        public IEnumerable<Card> Cards(string category)
        {
            switch(category)
            {
                case "Numeric": return GetCards(NumericCards);
                default: return GetCards(GeneralCards);
            }
        }

        private IEnumerable<Card> GetCards(Card[] CardsToQuery)
        {
            var rng = new Random();
            IList<Card> cardsToReturn = new List<Card>();

            while (cardsToReturn.Count < 4)
            {
                int index = rng.Next(CardsToQuery.Length);
                var card = CardsToQuery[index];

                if (!cardsToReturn.Contains(card))
                    cardsToReturn.Add(card);
            }

            return cardsToReturn;
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

            public override bool Equals(object obj)
            {
                Card objCard = (Card)obj;
                return this.Title == objCard.Title;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}
