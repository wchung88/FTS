namespace Database.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
        public int CorrectlyAnswered { get; set; }
        public int IncorrectlyAnswered { get; set; }

        public override bool Equals(object obj)
        {
            var cardObj = (Card)obj;
            return this.CardId == cardObj.CardId;
        }

        public override int GetHashCode()
        {
            return (13 * 7) + this.CardId.GetHashCode();
        }
    }
}
