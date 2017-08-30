namespace Database.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CardGameContext : DbContext
    {
        public CardGameContext(DbContextOptions<CardGameContext> options)
            : base(options)
        { }

        public DbSet<Card> Cards { get; set; }
    }
}
