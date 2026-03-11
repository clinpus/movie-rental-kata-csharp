

namespace MovieRental
{
    public class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            if (daysRented > 1)
            {
                return 2;
            }
            return 1;
        }
    }
}
