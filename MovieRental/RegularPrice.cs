
namespace MovieRental
{
    public class RegularPrice : Price
    {
        public override MovieType GetPriceCode()
        {
            return MovieType.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
            {
                result += (daysRented - 2) * 1.5;
            }
            return result;
        }

    }
}
