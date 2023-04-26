# Resident Evil 4 Character API

Resident Evil 4 Character API is an RestfulAPI used to get and send requests to a MySQL database. The database consisting of two tables based on the characters and organizations from Resident Evil 4 (2004).

This API was made as my final project for my Intro to API class. The purpose of this API is to showcase the topics that I've learned throughout the semester and how I can implement it into my First API. I am big fan of the Resident Evil series, especially Resident Evil 4. My love for the game inspired me to create my first API based on the game.

# Requirements
- MySQL Server + MySQL Workbench - used to store information of the characters and organizations into a database.
- C# - used to create the models and controllers for the REST API. Also used to connect to the MySQL database.
- C# NuGet packages - Microsoft.EntityFrameworkCore NuGet Package, Microsoft.EntityFrameworkCore.InMemory and Pomelo.EntityFrameworkCore.MySql.
- PostMan - What we will be using to test the API and its endpoints.

# Installation
1. Download the SQL script provided in the respository and add it to your MySQL Workbench.
2. Download and open the C# API project and run it.
3. Open PostMan and use the API References below.
# Tables

**Characters**
| CharacterId | FirstName| LastName | Age | OrganizationId|
| :-------- | :------- | :-------|:-------|:----- | 
| 1 | Leon |   Kennedy      |  27      |   1    |
| 2 | Ashley |     Graham    |    20    |    2   |
| 3 | Ada |   Wong      |    30    |    4   |
| 4 | Luis  |    Serra     |  28      |   2    |
| 5 | Albert |   Wesker      |   44     |   4    |
| 6 | Ramon |   Salazar      |  20      |    3   |
| 7 | Jack |    Krauser     |   28     |    4   |

**Organizations**
| OrganizationId | OrganizationName| OrganizationType | 
| :-------- | :------- | :-------|
| 1 | US-STRATCOM |  Hero       |             
| 2 | Civilians |     Neutral    |             
| 3 | Los Illuminados |    Villains     |              
| 4 | The Organization |     Villians    |              
| 5 | Test |     Random    |             

- The fifth Organization ID is used to demonstrate the DELETE Request in the Organization controller.
## HTTP Methods & API endpoints

#### GET a specific item;

```http
  GET /api/character/{id}
```

#### DELETE a specific item.

```http
  DELETE /api/organization/{id}
```

#### POST a new item into the character table.

```http
  POST /api/character
```

#### Response Body

```http
{
  StatusCode: 200
  StatusDescription: "ITS VALID!!!! YESSIRRRR!!!!!"
}
```

```http
{
  StatusCode: 400 
  StatusDescription: "L Code. Thats not it chief."
}
```

## Changes
Didn't change much of the project other than the HTTP methods and the endpoints, that I proposed during my API Idea presnetations. Added a test item to showcase the delete request in postman.
