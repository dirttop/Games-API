# Games-API
### Version 1.0

C# REST API with CRUD operations, deployed using Azure App Service. 
Developed for CS-432, Cloud Computing

## Introduction

This API, inspired by [SteamDB](https://steamdb.info/), is meant to catalogue and store Steam Games and relevant information about them. 
For stable builds look to version branches. Main development branch may not function as intended.

## Getting Started
This section is if you want to deploy the Games-API on your own machine or Azure subscription. 
If you would like to use the Games-API, click [here](#using-the-games-api).

#### Prerequisites

#### Dependencies

#### Running Locally

#### Deployment

## Using the Games-API

#### URL

>**games-api-a0gveveefgdyfcap.canadacentral-01.azurewebsites.net**

#### Authentication

To access the Games-API endpoints a valid authentication key must be presented.
Include the following key in your HTTP request header as a key/value pair:

> **Key: BOwOKpAMg6Za**

## Endpoints

#### CreateGame

> **POST /api/games**

&emsp;Creates a new game entry. Only title and SteamAppID are required parameters.

###### Request

```
```

###### Request Body

```
{
    "Title": "Counter-Strike 2",
    "Genre": "FPS",
    "Developer": "Valve",
    "ReleaseYear": "2012",
    "SteamAppID": 730
}
{
    "Title": "Hollow Knight",
    "SteamAppID": 367520
}
```

###### Response

```
{
  "730": {
    "title": "Counter-Strike 2",
    "genre": "FPS",
    "developer": "Valve",
    "releaseYear": 2012,
    "steamAppId": 730
  },
  "367520": {
    "title": "Hollow Knight",
    "genre": null,
    "developer": null,
    "releaseYear": 0,
    "steamAppId": 367520
  }
}
```


#### GetGames

>GET /api/games

&emsp;Retrieves all games stored in the API. Games are sorted by their SteamAppID in ascending order.

###### Request

```
```

###### Response

```
```


#### UpdateGame

#### Delete Game

## Possible Errors

#### Error Types

#### Error Messages

## Screenshots

## Sources

[Boilerplate](https://medium.com/dynamics-online/how-to-build-rest-apis-with-azure-functions-b4d26c88aa1d) by Fahad Ahmed
