using System;

namespace MovieRental
{
    public static class PriceValidator
    {
        public static void Validate(int priceCode)
        {
            // Vérifie si l'entier correspond à une valeur de l'Enum MovieType
            if (!Enum.IsDefined(typeof(MovieType), priceCode))
            {
                Logger.LogError($"Échec de validation : le code {priceCode} n'existe pas dans l'Enum MovieType.");
                throw new ArgumentException("Type de film non reconnu.");
            }
        }
    }
}
