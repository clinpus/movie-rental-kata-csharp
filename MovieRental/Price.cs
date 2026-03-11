
namespace MovieRental
{
    public abstract class Price : IPrice
    {
        // On force les classes filles à implémenter ces deux-là
        public abstract MovieType GetPriceCode();
        public abstract double GetCharge(int daysRented);

        // Comportement par défaut partagé
        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}