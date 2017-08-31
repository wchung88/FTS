namespace Database.Repository
{
    using Database.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private readonly CardGameContext _dbContext;

        public CardRepository(CardGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUserRecord(int cardId, int userId, int correctlyAnswered, int incorrectlyAnswered)
        {
            _dbContext.UserRecords.Add(new UserRecord
            {
                Card = GetCard(cardId),
                User = GetUser(userId),
                CorrectlyAnswered = correctlyAnswered,
                IncorrectlyAnswered = incorrectlyAnswered
            });
        }

        public Card GetCard(int cardId)
        {
            return _dbContext.Cards.FirstOrDefault(x => x.CardId == cardId);
        }

        public User GetUser(int userId)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public UserRecord GetCard(int cardId, int userId)
        {
            return _dbContext.UserRecords.FirstOrDefault(x => x.Card.CardId == cardId && x.User.UserId == userId);
        }

        public IList<Card> GetCards(string category, int level, int userId)
        {
            _dbContext.Cards.FromSql("select ")
            return _dbContext.Cards.Where(x => x.Category == category && x.Level == level).ToList();
        }

        public IList<Card> GetCards()
        {
            return _dbContext.Cards.ToList();
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }

        public IList<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void CreateUser(string name)
        {
            _dbContext.Users.Add(new User
            {
                Name = name
            });
        }
    }
}
