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
            var cards = this.cardRepository.GetCards(category, level);
            var userRecords = this.cardRepository.GetUserRecords(userId);
            return GetCards(cards, userRecords, level);
        }

        [HttpGet("[action]/{previousCardId}/{userId}")]
        public Card LearningCards(int previousCardId, int userId)
        {
            var cards = this.cardRepository.GetCards();
            var userRecords = this.cardRepository.GetUserRecords(userId);
            return GetLearningCard(cards, userRecords, previousCardId);
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

        private IEnumerable<Card> GetCards(IList<Card> CardsToQuery, IList<UserRecord> userRecord, int level)
        {
            var rng = new Random();
            IList<Card> cardsToReturn = new List<Card>();

            while (cardsToReturn.Count < (4 * level) && cardsToReturn.Count != CardsToQuery.Count)
            {
                int index = rng.Next(CardsToQuery.Count);
                var card = CardsToQuery[index];

                int accurracyRatio = 0;

                var record = userRecord.FirstOrDefault(x => x.Card.CardId == card.CardId);

                if (record != null)
                {
                    if (record.IncorrectlyAnswered == 0)
                    {
                        accurracyRatio = record.CorrectlyAnswered;
                    }
                    else
                    {
                        accurracyRatio = record.CorrectlyAnswered / record.IncorrectlyAnswered;
                    }
                }

                if (accurracyRatio < 7 && !cardsToReturn.Contains(card))
                    cardsToReturn.Add(card);
            }

            return cardsToReturn;
        }

        private Card GetLearningCard(IList<Card> CardsToQuery, IList<UserRecord> userRecord, int previousCardId)
        {
            var rng = new Random();

            var potentialCardsWithBadRecord = userRecord.Where(x => x.IncorrectlyAnswered > 0).OrderBy(x => x.CorrectlyAnswered / x.IncorrectlyAnswered).ToList();
            var cardsToUse = UnionLearningCards(potentialCardsWithBadRecord, CardsToQuery);

            while (true)
            {
                // Only return the bottom half of the incorrect ones
                int index = rng.Next(cardsToUse.Count / 2);
                var card = cardsToUse[index];
                if (card.CardId != previousCardId)
                    return card;
            }
        }

        private IList<Card> UnionLearningCards(IList<UserRecord> potentialCardsWithBadRecord, IList<Card> originalCards)
        {
            IList<Card> unionCards = new List<Card>();
            foreach(var record in potentialCardsWithBadRecord)
            {
                unionCards.Add(record.Card);
            }

            return unionCards.Union(originalCards).ToList();
        }
    }
}
