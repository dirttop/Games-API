# Games-API

C# REST API with CRUD operations, deployed using Azure App Service. 
Developed for CS-432, Cloud Computing

#### Introduction

This API, inspired by [SteamDB](https://steamdb.info/), is meant to catalogue and store Steam Games and relevant information about them. 

#### Getting Started

Make sure the following packages are installed: 
```Azure Functions, Azure Resources, Azurite, C#, Thunder Client (For testing, not required)```

If using ```Version 1.x``` modify the ```API_KEY``` string to any secure string.

If using later versions, check version specific documentation for deployment.

#### Running Locally

Create a new terminal and run the controller with ```func start```. Following initialization local function routes will be generated in the terminal. Use a 

If using ```Version 1.x``` the ```API_KEY``` must be defined in the query header under the specified ```API_HEADER```. EX:

<details>
<summary>Version 1.0</summary>
  #### Deploying to Azure
  Create a Function App with desired settings in the Azure portal, and then deploy to the Function App.
</details>
