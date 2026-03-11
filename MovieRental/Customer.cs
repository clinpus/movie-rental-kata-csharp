using System.Collections.Generic;

namespace MovieRental
{
    public class Customer
    {

        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + getName() + "\n";

            foreach (Rental each in _rentals)
            {
                // Refactoring : Utilisation de la méthode déléguée dans Movie pour obtenir le montant.
                // Cela élimine le switch complexe et centralise la logique tarifaire.
                double thisAmount = each.getMovie().GetCharge(each.getDaysRented());

                // Délégation du calcul des points au film pour respecter le principe d'encapsulation.
                frequentRenterPoints += each.getMovie().GetFrequentRenterPoints(each.getDaysRented());

                // show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }
    }

}
