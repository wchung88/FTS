namespace BabyGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Database.Repository;
    using Database.Models;
    using System.Linq;

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private ICardRepository cardRepository;

        public SampleDataController(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        [HttpPost("Card/{cardId}/correct")]
        public ActionResult CorrectlyAnswered(int cardId)
        {
            var card = this.cardRepository.GetCard(cardId);
            card.CorrectlyAnswered++;
            this.cardRepository.SaveAll();
            return NoContent();
        }

        [HttpPost("Card/{cardId}/incorrect")]
        public ActionResult IncorrectlyAnswered(int cardId)
        {
            var card = this.cardRepository.GetCard(cardId);
            card.IncorrectlyAnswered++;
            this.cardRepository.SaveAll();
            return NoContent();
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

                int accurracyRatio;
                if (card.IncorrectlyAnswered == 0)
                {
                    accurracyRatio = card.CorrectlyAnswered;
                }
                else
                {
                    accurracyRatio = card.CorrectlyAnswered / card.IncorrectlyAnswered;
                }

                if (accurracyRatio < 7 && !cardsToReturn.Contains(card))
                    cardsToReturn.Add(card);
            }

            return cardsToReturn;
        }

        private Card GetLearningCard(IList<Card> CardsToQuery, int previousCardId)
        {
            var rng = new Random();
            var potentialCardsToLearn = CardsToQuery.Where(x => x.IncorrectlyAnswered > 0).OrderBy(x => x.CorrectlyAnswered / x.IncorrectlyAnswered).ToList();
            var cardsToUse = potentialCardsToLearn.Count > 0 ? potentialCardsToLearn : CardsToQuery;

            while (true)
            {
                // Only return the bottom half of the incorrect ones
                int index = rng.Next(cardsToUse.Count / 2);
                var card = cardsToUse[index];
                if (card.CardId != previousCardId)
                    return card;
            }
        }
    }
}
