
# movie-rental-kata-csharp

C# implementation of the Movie Rental Kata. Focused on SOLID principles, Unit Testing, and Refactoring patterns.

## Notes Techniques
- **Migration de Framework** : Le projet a été passé de .NET 4.5 à **.NET 4.6.2** pour assurer la compatibilité avec Visual Studio 2022, la version 4.5 n'étant plus supportée par l'IDE.
- **Validation** : La compatibilité descendante a été vérifiée, et tous les tests unitaires passent avec succès sur cette nouvelle cible.
- [x] Déplacement du calcul du prix (`GetCharge`) dans la classe `Movie` pour respecter le **SRP** (Single Responsibility Principle).
- [x] Validation par tests unitaires (7/7 OK).
- [x] **Refactoring des points de fidélité** : Déplacement de la logique `frequentRenterPoints` dans `Movie.GetFrequentRenterPoints`.
- [x] **Encapsulation** : La classe `Customer` ne contient plus de règles de gestion (Business Rules), elle ne fait plus que coordonner l'affichage.
- [x] Validation par tests unitaires (7/7 OK).
- [x] **Extraction des totaux** : Création de `GetTotalCharge` et `GetTotalFrequentRenterPoints` pour supprimer les accumulateurs dans la boucle principale.
- [x] **Élimination des variables temporaires** : La méthode `Statement` est désormais purement dédiée à l'affichage (Refactoring : Replace Temp with Query).
- [x] **Design Pattern Strategy** : Suppression totale des switchs de calcul. Chaque type de prix est désormais isolé dans sa propre classe.
## Validation
- [x] **Tests Unitaires** : Tous les tests passent avec succès (`dotnet test`).
- [x] **Optimisation Mémoire** : Utilisation de StringBuilder dans la méthode Statement pour éviter les allocations inutiles de chaînes de caractères lors de la construction du rapport.
- [x] **Architecture Polymorphe** : Implémentation de l'interface IPrice pour permettre une extension facile du catalogue de prix sans modification de la classe Movie (Open-Closed Principle).


### Infrastructure & Migration
* **Migration de Framework** : Passage de .NET 4.5 à **.NET 4.6.2** pour assurer la compatibilité avec Visual Studio 2022.
* **Optimisation Mémoire** : Utilisation de `StringBuilder` dans la méthode `Statement` pour optimiser la gestion de la mémoire (réduction des allocations du GC).

### Architecture & Design Patterns
* **Design Pattern Strategy / State** : Suppression totale des `switch` de calcul. Chaque type de prix est désormais isolé dans sa propre classe implémentant l'interface `IPrice`.
* **Encapsulation & SRP** : 
    * Déplacement du calcul du prix (`GetCharge`) et des points (`GetFrequentRenterPoints`) dans `Movie` / `Price`.
    * La classe `Customer` est désormais purement dédiée à la coordination de l'affichage.
* **Refactoring Patterns** : 
    * *Replace Temp with Query* : Extraction de `GetTotalCharge` et `GetTotalFrequentRenterPoints` pour éliminer les accumulateurs locaux.
    * *Extract Method* : Clarification de la logique de formatage.


## Validation

- [x] **Tests Unitaires** : Tous les tests passent avec succès (7/7 OK).
- [x] **Compatibilité** : Vérifiée sur la nouvelle cible .NET 4.6.2.
