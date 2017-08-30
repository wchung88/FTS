namespace Database.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CardGameContext : DbContext
    {
        public CardGameContext(DbContextOptions<CardGameContext> options)
            : base(options) {}

        public void EnsureSeedData()
        {
            this.Entry(new Card { Title = "Ball", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ec/Soccer_ball.svg", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Car", ImageUrl = "http://trottingmaregarage.co.uk/wp-content/uploads/2017/08/Car.png", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Shoe", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHyjSQqNveV1ywzszD9J4pmODmn_hmuP4KqJWuZ_OtpoDKKKRS", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Tree", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFePMTXAcB-SsAUs9e73zV_dgB_c12Prh0I7xI7Aef1rlaF_nL8g", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "TV", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.bzN1Pnbh08kQFTaEt_Q53QEsD0&pid=15.1&P=0&w=195&h=160", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Plane", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.G89eDI1KdEi1ZwPCCIZnSgGDCh&pid=15.1&P=0&w=381&h=159", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Bird", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.F-dZ2WG24SVnG2M4hamOIwEsDL&pid=15.1&P=0&w=248&h=169", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Cup", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.jv7t5yz9zi_8-wuaRkC6WwEsDc&pid=15.1&P=0&w=226&h=167", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Table", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.9uvBZ1hvhWXt0Kugdua1TQEsDB&pid=15.1&P=0&w=258&h=167", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Moon", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.Vtx4EgelwPqTRH699C9dLgEsEs&pid=15.1&P=0&w=300&h=300", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Bike", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.xGuQhZBOCeTdC-cIXhgNQwD6D6&pid=15.1&P=0&w=300&h=300", Category = "General", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Flower", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.PE6kwhCuojmF8Z_wfeNPJwEsDI&pid=15.1&P=0&w=257&h=172", Category = "General", Level = 1 }).State = EntityState.Added;

            this.Entry(new Card { Title = "Number 1", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.mNhMnGJLNXbZeMgn0HgHmADnEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 2", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.4jo9kd1WrCwxBhCMPWxWqgD6D6&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 3", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.2KbDpKvdKTWCjQeMBqYWVQDnEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 4", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.bsh0NvjI0JHD93ITFeDh0gEsEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 5", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.D0yWzi7a8Ovtfkxnu1ta8wDnEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 6", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.Wesa1hGi1R22O2Smr2kxlQEsEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 7", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.vArf07pJ8cAILR8NetDR2gDnEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 8", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.vRE8gFdn9ZOzQr7e-sy53gDnEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 9", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.PudxPc1y9gewaSFtVY6n4AEsEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 10", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.aplAA8ilmd0E5W67LtpHKABVBg&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 11", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.byIaRc1MTfnkzNGbtCa74AEsEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 12", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.eFE-ZT0s8lXlw7wh4zTRtgEsEs&pid=15.1&P=0&w=300&h=300", Category = "Numeric", Level = 1 }).State = EntityState.Added;

            this.Entry(new Card { Title = "Letter A", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.i4lgcMZdAfeq2yazQaFr9QEMDp&pid=15.1&P=0&w=182&h=159", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter B", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.Yao9sw0KRDSGMa649Y_3TwEsEZ&pid=15.1&P=0&w=171&h=161", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter C", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.JPP_yQFJ1K4mlQrWIuf0ewEsEs&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter D", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.N-uypb55zobDsaVre7kSGwDnEs&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter E", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.FE5xs-Q7jfCPzr5OGQn4iQEoEs&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter F", ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.9lR58LrW2dcnhTuWK41jeQD9Eg&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter G", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.Z_H014Rm7Q_ES0GciZ89UgEsEs&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter H", ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.gHU-_2wqneAv8H8okc1pMQEsD7&pid=15.1&P=0&w=191&h=161", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter I", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP._JXCwLj_IRGRVkfTHCn-fAD6D6&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter J", ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.kSDJJgUKQcGKvbluUj5-iAEsEs&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter K", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.jky0DyyPzK5yCL_ROYBZ3gEsD9&pid=15.1&P=0&w=185&h=158", Category = "Letter", Level = 1 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Letter L", ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.CC60AxMVGgdW4pR3yWbI8wEYEY&pid=15.1&P=0&w=300&h=300", Category = "Letter", Level = 1 }).State = EntityState.Added;

            SaveChanges();
        }

        public DbSet<Card> Cards { get; set; }
    }
}
