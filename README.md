# movie-rental-kata-csharp
C# implementation of the Movie Rental Kata. Focused on SOLID principles, Unit Testing, and Refactoring patterns.
## Validation
- [x] **Tests Unitaires** : Tous les tests passent avec succès (`dotnet test`).
## Notes Techniques
- **Migration de Framework** : Le projet a été passé de .NET 4.5 à **.NET 4.6.2** pour assurer la compatibilité avec Visual Studio 2022, la version 4.5 n'étant plus supportée par l'IDE.
- **Validation** : La compatibilité descendante a été vérifiée, et tous les tests unitaires passent avec succès sur cette nouvelle cible.
- [x] Déplacement du calcul du prix (`GetCharge`) dans la classe `Movie` pour respecter le **SRP** (Single Responsibility Principle).
- [x] Validation par tests unitaires (7/7 OK).