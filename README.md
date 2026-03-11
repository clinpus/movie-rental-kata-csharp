
# movie-rental-kata-csharp

C# implementation of the Movie Rental Kata. Focused on SOLID principles, Unit Testing, and Refactoring patterns.

## Notes Techniques

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