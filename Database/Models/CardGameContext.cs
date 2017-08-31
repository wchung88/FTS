﻿namespace Database.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CardGameContext : DbContext
    {
        public CardGameContext(DbContextOptions<CardGameContext> options)
            : base(options) {}

        public void EnsureSeedData()
        {
            
            SaveChanges();
        }

        public void OldEnsureSeedData()
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

            this.Entry(new Card { Title = "Number 13", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzihkcNP7s2CJvL3LUyHoKRMQGra2LEbyA-JItQU8c2usnCHYTdw", Category = "Numeric", Level = 2 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 14", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQv3MzTMynVYAj6hLOyluTSq89dU1OWZvDky7kN4oo0L2QYNutbbQ", Category = "Numeric", Level = 2 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 15", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdO_rrfCtvrA4lq_erh7zdpb1vyEQ7XQlCE-KPMXc957SJf2oGgw", Category = "Numeric", Level = 2 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 16", ImageUrl = "data:image/png;base64,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", Category = "Numeric", Level = 2 }).State = EntityState.Added;

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
            this.Entry(new Card { Title = "Number 17", ImageUrl = "data:image/png;base64,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", Category = "Numeric", Level = 2 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 18", ImageUrl = "data:image/png;base64,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", Category = "Numeric", Level = 2 }).State = EntityState.Added;
            this.Entry(new Card { Title = "Number 19", ImageUrl = "data:image/png;base64,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", Category = "Numeric", Level = 2 }).State = EntityState.Added;
            SaveChanges();
        }

        public DbSet<Card> Cards { get; set; }
    }
}