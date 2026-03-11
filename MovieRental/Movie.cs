using System;

namespace MovieRental
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        private String _title;
        private int _priceCode;

        public Movie(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }

        // Refactoring : Déplacement de la logique de calcul du prix depuis Customer vers Movie (SRP)
        // Le montant dépend désormais directement du type de film et de la durée.
        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (_priceCode)
            {
                case REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }
            return result;
        }

        // Refactoring : Détermine le gain de points de fidélité.
        // La logique de bonus pour les nouveautés est désormais encapsulée ici.
        public int GetFrequentRenterPoints(int daysRented)
        {
            if ((_priceCode == NEW_RELEASE) && daysRented > 1)
                return 2;

            return 1;
        }

    }
}
