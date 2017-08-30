namespace Database.Repository
{
    using Database.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private readonly CardGameContext _dbContext;

        public CardRepository(CardGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Card> GetCards(string category, int level)
        {
            return _dbContext.Cards.Where(x => x.Category == category && x.Level == level).ToList();
        }

        public IList<Card> GetCards()
        {
            return _dbContext.Cards.ToList();
        }
    }
}
