using System;

namespace MovieRental
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        private String _title;

        private Price _price;

        public void setPriceCode(int arg)
        {
            switch (arg)
            {
                case REGULAR:
                    _price = new RegularPrice();
                    break;
                case CHILDRENS:
                    _price = new ChildrensPrice();
                    break;
                case NEW_RELEASE:
                    _price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentException("Code de prix invalide");
            }
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return _price.GetFrequentRenterPoints(daysRented);
        }

        public Movie(String title, int priceCode)
        {
            _title = title;
            // On appelle la méthode pour initialiser l'objet _price correspondant
            setPriceCode(priceCode);
        }

        public String getTitle()
        {
            return _title;
        }

    }
}
