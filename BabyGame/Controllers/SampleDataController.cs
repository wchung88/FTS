using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Database.Repository;
using Database.Models;

namespace BabyGame.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private ICardRepository cardRepository;

        public SampleDataController(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        [HttpGet("[action]/{category}/{level}")]
        public IEnumerable<Card> Cards(string category, int level)
        {
            var cards = this.cardRepository.GetCards(category, level);
            return GetCards(cards);
        }

        private IEnumerable<Card> GetCards(IList<Card> CardsToQuery)
        {
            var rng = new Random();
            IList<Card> cardsToReturn = new List<Card>();

            while (cardsToReturn.Count < 8)
            {
                int index = rng.Next(CardsToQuery.Count);
                var card = CardsToQuery[index];

                if (!cardsToReturn.Contains(card))
                    cardsToReturn.Add(card);
            }

            return cardsToReturn;
        }
    }
}
