using MovieRental;

public interface IPrice
{
    MovieType GetPriceCode();
    double GetCharge(int daysRented);
    int GetFrequentRenterPoints(int daysRented);
}