namespace Database.Models
{
    public class UserRecord
    {
        public int UserRecordId { get; set; }
        public User User { get; set; }
        public Card Card { get; set; }
        public int CorrectlyAnswered { get; set; }
        public int IncorrectlyAnswered { get; set; }
    }
}
