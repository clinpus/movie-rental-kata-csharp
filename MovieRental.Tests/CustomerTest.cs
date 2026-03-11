using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            Customer c = new CustomerBuilder().build();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestAddRental()
        {
            Customer customer2 = new CustomerBuilder().withName("Julia").build();
            Movie movie1 = new Movie("Gone with the Wind", new RegularPrice());
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            Customer c = new Customer("David");
            Assert.AreEqual("David", c.Name);
        }
        [TestMethod]
        public void StatementForRegularMovie()
        {
            Movie movie1 = new Movie("Gone with the Wind", new RegularPrice());
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2 =
                    new CustomerBuilder()
                            .withName("Sallie")
                            .withRentals(rental1)
                            .build();
            string expected = "Rental Record for Sallie\n" +
                    "\tGone with the Wind\t3,5\n" +
                    "Amount owed is 3,5\n" +
                    "You earned 1 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForNewReleaseMovie()
        {
            Movie movie1 = new Movie("Star Wars", new NewReleasePrice());
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2 =
                    new CustomerBuilder()
                            .withName("Sallie")
                            .withRentals(rental1)
                            .build();
            string expected = "Rental Record for Sallie\n" +
                    "\tStar Wars\t9\n" +
                    "Amount owed is 9\n" +
                    "You earned 2 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForChildrensMovie()
        {
            Movie movie1 = new Movie("Madagascar", new ChildrensPrice());
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2
                    = new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rental1)
                    .build();
            string expected = "Rental Record for Sallie\n" +
                    "\tMadagascar\t1,5\n" +
                    "Amount owed is 1,5\n" +
                    "You earned 1 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForManyMovies()
        {
            // Injecter les objets de prix directement dans le constructeur de Movie
            Movie movie1 = new Movie("Madagascar", new ChildrensPrice());
            Rental rental1 = new Rental(movie1, 6);

            Movie movie2 = new Movie("Star Wars", new NewReleasePrice());
            Rental rental2 = new Rental(movie2, 2);

            Movie movie3 = new Movie("Gone with the Wind", new RegularPrice());
            Rental rental3 = new Rental(movie3, 8);

            Customer customer1 = new CustomerBuilder()
                .withName("David")
                .withRentals(rental1, rental2, rental3)
                .build();

            // Construction de la chaîne attendue (Attention aux tabulations \t et retours ligne \n)
            string expected = "Rental Record for David\n" +
                              "\tMadagascar\t6\n" +
                              "\tStar Wars\t6\n" +
                              "\tGone with the Wind\t11\n" +
                              "Amount owed is 23\n" +
                              "You earned 4 frequent renter points";

            string statement = customer1.Statement();

            // Vérification finale
            Assert.AreEqual(expected, statement);
        }

    }

}
