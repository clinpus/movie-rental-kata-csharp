
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name
        {
            get { return _name; }
        }

        public string Statement()
        {
            // StringBuilder c'est mieux qu'un string immuable 
            StringBuilder result = new StringBuilder();
            result.Append("Rental Record for ").Append(Name).Append("\n");

            foreach (Rental each in _rentals)
            {
                // Récupérer le montant via la logique métier 
                double thisAmount = each.Movie.GetCharge(each.DaysRented);

                result.Append("\t")
                      .Append(each.Movie.Title)
                      .Append("\t")
                      .Append(thisAmount.ToString())
                      .Append("\n");
            }

            result.Append("Amount owed is ")
                  .Append(GetTotalCharge().ToString())
                  .Append("\n");

            result.Append("You earned ")
                  .Append(GetTotalFrequentRenterPoints().ToString())
                  .Append(" frequent renter points");

            return result.ToString();
        }

        // Calcule le montant total de toutes les locations du client.
        // Cette méthode permet de supprimer la variable temporaire 'totalAmount' dans Statement.
        private double GetTotalCharge()
        {
            return _rentals.Sum(r => r.Movie.GetCharge(r.DaysRented));
        }

        // Calcule le cumul des points de fidélité pour l'ensemble des locations.
        // Isole la logique de sommation pour simplifier la méthode d'affichage.
        private int GetTotalFrequentRenterPoints()
        {
            return _rentals.Sum(r => r.Movie.GetFrequentRenterPoints(r.DaysRented));
        }

    }

}
