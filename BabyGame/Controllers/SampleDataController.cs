namespace BabyGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Database.Repository;
    using Database.Models;

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
            return GetCards(cards, level);
        }

        [HttpGet("[action]/{previousCardId}")]
        public Card LearningCards(int previousCardId)
        {
            var cards = this.cardRepository.GetCards();
            return GetLearningCard(cards, previousCardId);
        }

        private IEnumerable<Card> GetCards(IList<Card> CardsToQuery, int level)
        {
            var rng = new Random();
            IList<Card> cardsToReturn = new List<Card>();

            while (cardsToReturn.Count < (4 * level) && cardsToReturn.Count != CardsToQuery.Count)
            {
                int index = rng.Next(CardsToQuery.Count);
                var card = CardsToQuery[index];

                if (!cardsToReturn.Contains(card))
                    cardsToReturn.Add(card);
            }

            return cardsToReturn;
        }

        private Card GetLearningCard(IList<Card> CardsToQuery, int previousCardId)
        {
            var rng = new Random();
            while (true)
            {
                int index = rng.Next(CardsToQuery.Count);
                var card = CardsToQuery[index];
                if (card.CardId != previousCardId)
                    return card;
            }
        }
    }
}
