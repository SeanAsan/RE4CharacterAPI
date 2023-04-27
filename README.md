# Resident Evil 4 Character API

Resident Evil 4 Character api is a REST API used to request and update information of the characters and the organization from the video game Resident Evil 4 (2004). The database consists of two tables: characters and organizations, based on the video game Resident Evil 4 (2004).

This API was made as my final project for Intro to API. The purpose of this API is to showcase the topics that I've learned throughout the semester and how I can implement them into my first API. I am big fan of the Resident Evil series, especially Resident Evil 4. Its one of the first horror games I played as a child on the original GameCube. My love for the game inspired me to create this API.

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
    "statusCode": 200,
    "statusDescription": "ITS VALID!!!! YESSIRRRR!!!!!",
    "characters": [
        {
            "characterId": 1,
            "firstName": "Leon",
            "lastName": "Kennedy",
            "age": 27,
            "organization": {
                "organizationId": 1,
                "organizationName": "US-STRATCOM",
                "organizationType": "Hero"
            }
        }
    ]
}
```

```http
{
  StatusCode: 400 
  StatusDescription: "L Code. Thats not it chief."
}
```

## Changes
Didn't change much of the project other than the HTTP methods and the endpoints, that I proposed during my API idea presnetations. Added a test item to showcase the delete request in postman.
