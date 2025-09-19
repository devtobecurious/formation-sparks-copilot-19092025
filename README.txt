# README

Ce projet est une API .NET minimaliste pour la gestion de sessions de jeux vidéo.

## Structure du projet

- `GameSessionApi/` : Projet principal de l'API
- `GameSessionApi.Tests/` : Projet de tests unitaires (xUnit)

## Fonctionnalités principales
- CRUD sur les sessions de jeu
- Gestion d'une liste de jeux vidéo
- Recherche de sessions par joueur ou par jeu
- Calcul automatique de la durée d'une session

## Lancer l'API

```sh
dotnet run --project GameSessionApi/GameSessionApi.csproj
```

## Lancer les tests

```sh
dotnet test
```

## Bonnes pratiques
- Style Minimal API .NET 8
- Séparation des responsabilités (services, modèles, endpoints)
- Documentation Swagger intégrée

## Auteur
Formation Sparks - Copilot fondamentaux
