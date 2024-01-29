# Pizza'ed
Only for practicing and showcasing purposes.

## Overview

The application aims to be a review-based web app, allowing users to upload reviews of the pizzas they've eaten. Other users can browse these reviews and view them in detail.

Here are some pictures of the app's [home](https://imgur.com/bIYZMse), [login](https://imgur.com/W6lA5ay), [browse](https://imgur.com/zGYwBFV) and [about](https://imgur.com/5ZGgmF3) pages. 

## Features

- **Azure MS SQL Database:** The app utilizes an Azure MS SQL database to store pizza reviews.

- **ASP.NET 8 Back-end:** The back-end is built using ASP.NET 8, connecting to the database using EntityFramework with a Code-First approach. It also exposes web APIs.

- **Vue 2 Front-end:** The front-end is developed using Vue 2, incorporating Typescript, Routing, and smaller design frameworks.

## Important notes
- The appsettings.json file is ignored from the repo, I decided not to mess with storing keys and passwords in vaults, just writing them in the settings, and exclude it from the project


## Running the app locally

1 - Clone the repository

<b>BACKEND</B>

2 - Create an MS SQL Server instance and a database

3 - Create an appsettings.json in the pizza-app-master/backend/API folder with the following parameters:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Local": "Data Source={{YOUR SQL SERVER NAME}};Initial Catalog={{YOUR SQL DATABASE NAME}};Integrated Security=True;Trust Server Certificate=True"
  },
  "JWTSettings": {
    "Secret": "{{YOUR 64 LENGTH RANDOM STRING}}",
    "Issuer": "https://id.rakmate9812.com",
    "Audience": "https://pizza-app.rakmate9812.com"
  }
}
```

4 - Install all the nuget packages (if not yet installed)

5 - Create the tables: run the following commands in the package manager console in the pizza-app-master/backend folder:

```add-migration "{{YOUR-RANDOM-MIGRATION-NAME}}"```

```update-database```

6 - Run the backend


<b>FRONTEND</B>

7 - run ```npm i``` in the pizza-app-master/frontend in cmd, wait for the necessary node modules to download

8 - run ```npm run serve```
