using System.Collections;
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
            string result = "Rental Record for " + getName() + "\n";

            foreach (Rental each in _rentals)
            {
                // On garde cette variable locale uniquement pour l'affichage de la ligne
                double thisAmount = each.getMovie().GetCharge(each.getDaysRented());

                // show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
            }

            // add footer lines - Utilisation des nouvelles méthodes de calcul
            result += "Amount owed is " + GetTotalCharge().ToString() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints().ToString() + " frequent renter points";

            return result;
        }

        // Calcule le montant total de toutes les locations du client.
        // Cette méthode permet de supprimer la variable temporaire 'totalAmount' dans Statement.
        private double GetTotalCharge()
        {
            double result = 0;
            IEnumerator rentals = _rentals.GetEnumerator();
            while (rentals.MoveNext())
            {
                Rental each = (Rental)rentals.Current;
                result += each.getMovie().GetCharge(each.getDaysRented());
            }
            return result;
        }

        // Calcule le cumul des points de fidélité pour l'ensemble des locations.
        // Isole la logique de sommation pour simplifier la méthode d'affichage.
        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            IEnumerator rentals = _rentals.GetEnumerator();
            while (rentals.MoveNext())
            {
                Rental each = (Rental)rentals.Current;
                result += each.getMovie().GetFrequentRenterPoints(each.getDaysRented());
            }
            return result;
        }

    }

}
