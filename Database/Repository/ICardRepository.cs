namespace Database.Repository
{
    using Database.Models;
    using System.Collections.Generic;

    public interface ICardRepository
    {
        IList<Card> GetCards(string category, int level);
    }
}
