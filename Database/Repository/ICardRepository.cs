namespace Database.Repository
{
    using Database.Models;
    using System.Collections.Generic;

    public interface ICardRepository
    {
        IList<Card> GetCards(string category, int level, int userId);
        IList<Card> GetCards();
        Card GetCard(int cardId);
        UserRecord GetCard(int cardId, int userId);
        void SaveAll();
        void CreateUserRecord(int cardId, int userId, int correctlyAnswered, int incorrectlyAnswered);
        IList<User> GetUsers();
        void CreateUser(string name);
    }
}
