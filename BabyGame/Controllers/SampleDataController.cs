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

        [HttpPost("Card/{cardId}/correct/{userId}")]
        public ActionResult CorrectlyAnswered(int cardId, int userId)
        {
            var card = this.cardRepository.GetCard(cardId, userId);

            if(card == null)
            {
                this.cardRepository.CreateUserRecord(cardId, userId, 1, 0);
            }
            else
            {
                card.CorrectlyAnswered++;
            }

            this.cardRepository.SaveAll();
            return NoContent();
        }

        [HttpPost("Card/{cardId}/incorrect/{userId}")]
        public ActionResult IncorrectlyAnswered(int cardId, int userId)
        {
            var card = this.cardRepository.GetCard(cardId, userId);

            if (card == null)
            {
                this.cardRepository.CreateUserRecord(cardId, userId, 0, 1);
            }
            else
            {
                card.IncorrectlyAnswered++;
            }

            this.cardRepository.SaveAll();
            return NoContent();
        }

        [HttpGet("[action]/{category}/{level}/{userId}")]
        public IEnumerable<Card> Cards(string category, int level, int userId)
        {
            var cards = this.cardRepository.GetCards(category, level, userId);
            return GetCards(cards, level);
        }

        [HttpGet("[action]/{previousCardId}")]
        public Card LearningCards(int previousCardId)
        {
            var cards = this.cardRepository.GetCards();
            return GetLearningCard(cards, previousCardId);
        }

        [HttpGet("[action]")]
        public IEnumerable<User> Users()
        {
            return this.cardRepository.GetUsers();
        }

        [HttpPut("[action]/Users")]
        public ActionResult Users(string name)
        {
            this.cardRepository.CreateUser(name);
            this.cardRepository.SaveAll();
            return NoContent();
        }

        private IEnumerable<Card> GetCards(IList<Card> CardsToQuery, int level)
        {
            var rng = new Random();
            IList<Card> cardsToReturn = new List<Card>();

            while (cardsToReturn.Count < (4 * level) && cardsToReturn.Count != CardsToQuery.Count)
            {
                int index = rng.Next(CardsToQuery.Count);
                var card = CardsToQuery[index];

                int accurracyRatio = 0;
                /*if (card.IncorrectlyAnswered == 0)
                {
                    accurracyRatio = card.CorrectlyAnswered;
                }
                else
                {
                    accurracyRatio = card.CorrectlyAnswered / card.IncorrectlyAnswered;
                }*/

                if (accurracyRatio < 7 && !cardsToReturn.Contains(card))
                    cardsToReturn.Add(card);
            }

            return cardsToReturn;
        }

        private Card GetLearningCard(IList<Card> CardsToQuery, int previousCardId)
        {
            var rng = new Random();
            var potentialCardsToLearn = new List<Card>(); // CardsToQuery.Where(x => x.IncorrectlyAnswered > 0).OrderBy(x => x.CorrectlyAnswered / x.IncorrectlyAnswered).ToList();
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
