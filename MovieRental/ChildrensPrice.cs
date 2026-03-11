
namespace MovieRental
{
    public class ChildrensPrice : Price
    {
        public override MovieType GetPriceCode()
        {
            return MovieType.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
            {
                result = result + ((daysRented - 3) * 1.5);
            }
            return result;
        }

    }
}
