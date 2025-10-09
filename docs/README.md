# Games-API
### Version 1.0

C# REST API with CRUD operations, deployed using Azure App Service. 
Developed for CS-432, Cloud Computing

## Introduction

This API, inspired by [SteamDB](https://steamdb.info/), is meant to catalogue and store Steam Games and relevant information about them. 
For stable builds look to version branches. Main development branch may not function as intended.

## Getting Started
This section is if you want to deploy the Games-API on your own machine or Azure subscription.

If you want to use the Games-API, go [here](#using-the-games-api).

#### Prerequisites
- Development Environment
- Azure Account

#### Dependencies
- C# Compiler
- Azure Functions
- Azure Resources
- Azurite

#### Recommended Packages
- Thunder Client
- Postman

#### Setup

&emsp;Ensure that all dependencies are installed and working.

&emsp;This project is built in C# with .NET 9.0 

> Screenshots show setup in Visual Studio Code
<img width="533" height="335" alt="Screenshot 2025-10-09 at 12 04 11 PM" src="https://github.com/user-attachments/assets/8e94d260-ca76-4700-ab4e-dc25c66f4f53" />

<br>&emsp;Navigate to the Azure Functions button in your local workspace and press 'Create Function'

<img width="735" height="127" alt="Screenshot 2025-10-09 at 12 04 32 PM" src="https://github.com/user-attachments/assets/5cb6574b-8235-42b3-b3c4-1b3694d73bd9" />

<br>&emsp;Select HTTP Trigger template.

&emsp;Input a Function Name and Namespace

&emsp;Access Rights: Anonymous

&emsp;Wait for setup to conclude.

#### Running Locally

&emsp;In a new terminal:
``` func start ```

&emsp;Test with local route.
> **EX: http://localhost:7071/api/games**

#### Deployment

&emsp;Create a Function App within Azure prior to deploying with desired settings.

> Screenshots show deployment in Visual Studio Code
<img width="541" height="342" alt="Screenshot 2025-10-09 at 11 52 52 AM" src="https://github.com/user-attachments/assets/710701e0-1f6b-4d85-8065-6603d3e3275d" />

<br>&emsp;Navigate to the Azure Functions button in your local workspace and select 'Deploy to Azure'

<img width="671" height="128" alt="Screenshot 2025-10-09 at 11 57 09 AM" src="https://github.com/user-attachments/assets/32c2dd51-d16f-423a-a562-565e5ba47afe" />
<br>&emsp;Select desired Function App and wait for deployment to conclude.

> Your deployment domain will now be available on Azure. For instruction on testing go [here](#using-the-games-api).

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

&emsp;Creates a new game entry. Only Title and SteamAppID are required parameters.

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
```

###### Response

```
{
  "title": "Counter-Strike 2",
  "genre": "FPS",
  "developer": "Valve",
  "releaseYear": "2012",
  "steamAppId": 730
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

#### GetGames by ID

>GET /api/games

&emsp;Retrieves all games stored in the API. Games are sorted by their SteamAppID in ascending order.

###### Request

```
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


#### UpdateGame

#### Delete Game

## Possible Errors
- 

#### Error Types

#### Error Messages

## Screenshots

## Sources

[Boilerplate](https://medium.com/dynamics-online/how-to-build-rest-apis-with-azure-functions-b4d26c88aa1d) by Fahad Ahmed
