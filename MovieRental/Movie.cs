
namespace MovieRental
{
    public class Movie
    {
        private string _title;
        private IPrice _price; 

        public Movie(string title, IPrice price)
        {
            _title = title;
            _price = price;
        }

        public string Title
        {
            get { return _title; }
        }

        // Getter pour accéder au prix 
        public IPrice Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return _price.GetFrequentRenterPoints(daysRented);
        }
    }
}