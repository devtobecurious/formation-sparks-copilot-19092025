# Copilot Instructions

## Objectif du projet
Ce projet est une API .NET minimaliste permettant de gérer des sessions de jeux vidéo.  
Les principales entités sont : GameSession (session de jeu) et Game (jeu vidéo).

## Bonnes pratiques attendues
- Utiliser le style Minimal API de .NET 8.
- Respecter la séparation des responsabilités (services, modèles, endpoints).
- Utiliser des noms de variables et méthodes explicites en anglais.
- Générer des exemples de tests unitaires pour chaque nouvelle fonctionnalité.
- Documenter les endpoints via Swagger.

## Workflow collaboratif à respecter
Pour chaque nouvelle fonctionnalité, suis impérativement ce processus :

1. Demande systématiquement le **titre de la feature** à l'utilisateur.
2. Crée une **branche** dédiée, nommée d'après ce titre (en anglais, format kebab-case recommandé).
3. Bascule sur cette branche avant tout développement.
4. Détaille les étapes de réalisation de la fonctionnalité (planification, architecture, endpoints, tests, etc.).
5. **Attends la confirmation explicite de l'utilisateur** avant de commencer le développement.

Ce workflow garantit une collaboration efficace, une traçabilité des évolutions et une validation continue par l'utilisateur.

## Fonctionnalités à privilégier
- CRUD complet sur les sessions de jeu.
- Gestion d’une liste de jeux vidéo disponibles.
- Recherche de sessions par joueur ou par jeu.
- Calcul automatique de la durée d’une session.

## À éviter
- Utiliser une base de données relationnelle : mysql. Et créer une migration pour chaque model.
- Ne pas ajouter d’authentification ou d’autorisation pour l’instant.
- Ne pas générer de code inutile ou de dépendances externes non justifiées.

## Exemples de requêtes Copilot
- Génère un endpoint pour lister tous les jeux vidéo disponibles.
- Ajoute un service en mémoire pour gérer les jeux vidéo.
- Propose des tests unitaires pour la création de session de jeu.