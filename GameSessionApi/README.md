# Game Session API

Une API web minimaliste .NET 8 pour gérer les sessions de jeux vidéo.

## Description

Cette API permet de créer, lire, mettre à jour et supprimer des sessions de jeux vidéo. Elle utilise l'architecture des APIs minimales de .NET 8 et un stockage en mémoire pour la simplicité.

## Fonctionnalités

- ✅ Créer une nouvelle session de jeu
- ✅ Lister toutes les sessions
- ✅ Récupérer une session par ID
- ✅ Mettre à jour une session existante
- ✅ Supprimer une session
- ✅ Rechercher les sessions par nom de joueur
- ✅ Rechercher les sessions par titre de jeu
- ✅ Calcul automatique de la durée de session
- ✅ Gestion des statuts de session (Active, Terminée, Pause, Abandonnée)

## Prérequis

- .NET 8.0 SDK (LTS)

## Installation et Exécution

1. **Cloner le repository** :
   ```bash
   git clone <repository-url>
   cd formation-sparks-copilot-19092025/GameSessionApi
   ```

2. **Restaurer les dépendances** :
   ```bash
   dotnet restore
   ```

3. **Construire le projet** :
   ```bash
   dotnet build
   ```

4. **Lancer l'application** :
   ```bash
   dotnet run
   ```

L'API sera disponible sur `http://localhost:5126`

## Documentation API

### Swagger UI

Lorsque l'application est lancée en mode développement, accédez à la documentation Swagger à l'adresse :
`http://localhost:5126/swagger`

### Endpoints

#### Sessions de jeu

| Méthode | Endpoint | Description |
|---------|----------|-------------|
| GET | `/sessions` | Récupère toutes les sessions |
| GET | `/sessions/{id}` | Récupère une session par ID |
| POST | `/sessions` | Crée une nouvelle session |
| PUT | `/sessions/{id}` | Met à jour une session |
| DELETE | `/sessions/{id}` | Supprime une session |
| GET | `/sessions/player/{playerName}` | Récupère les sessions d'un joueur |
| GET | `/sessions/game/{gameTitle}` | Récupère les sessions d'un jeu |

#### Modèles de données

**GameSession** :
```json
{
  "id": 1,
  "gameTitle": "The Legend of Zelda: Tears of the Kingdom",
  "playerName": "Link",
  "startTime": "2025-09-19T09:32:27.160485Z",
  "endTime": "2025-09-19T11:30:00Z",
  "score": 95000,
  "duration": "01:57:32.8395150",
  "status": 1,
  "notes": "Session terminée - boss final vaincu!"
}
```

**CreateGameSessionDto** :
```json
{
  "gameTitle": "Nom du jeu",
  "playerName": "Nom du joueur",
  "notes": "Notes optionnelles"
}
```

**UpdateGameSessionDto** :
```json
{
  "gameTitle": "Nouveau nom du jeu",
  "playerName": "Nouveau nom du joueur",
  "endTime": "2025-09-19T11:30:00Z",
  "score": 95000,
  "status": 1,
  "notes": "Nouvelles notes"
}
```

#### Status de session

- `0` - Active
- `1` - Terminée (Completed)
- `2` - En pause (Paused)
- `3` - Abandonnée (Abandoned)

## Exemples d'utilisation

### Créer une session
```bash
curl -X POST http://localhost:5126/sessions \
  -H "Content-Type: application/json" \
  -d '{
    "gameTitle": "The Legend of Zelda: Tears of the Kingdom",
    "playerName": "Link",
    "notes": "Exploration du château d'\''Hyrule"
  }'
```

### Terminer une session
```bash
curl -X PUT http://localhost:5126/sessions/1 \
  -H "Content-Type: application/json" \
  -d '{
    "endTime": "2025-09-19T11:30:00Z",
    "score": 95000,
    "status": 1
  }'
```

### Rechercher les sessions d'un joueur
```bash
curl http://localhost:5126/sessions/player/Link
```

## Tests

Utilisez le fichier `GameSessionApi.http` pour tester les endpoints avec un client REST ou Visual Studio Code avec l'extension REST Client.

## Technologies utilisées

- .NET 8.0 (LTS)
- ASP.NET Core Minimal APIs
- Swagger/OpenAPI
- C# 12

## Architecture

L'application utilise une architecture simple avec :
- **Models** : Modèles de données et DTOs
- **Services** : Logique métier et gestion des données
- **Program.cs** : Configuration et définition des endpoints

Le stockage des données se fait en mémoire pour cette démonstration. Pour un usage en production, il serait recommandé d'utiliser une base de données.