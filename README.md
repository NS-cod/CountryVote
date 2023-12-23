# CountryVote

## Description

This project is the implementation of a service that aims to have the possibility of adding users along with a favorite country for which they vote and on the other hand a service that reports the ten countries most voted for by users.

## Repository Content

1. **Implementación del Servicio**
   - [CountryVote\CountryVote\Services\AuthenticatorService]: It is responsible for verifying the previous existence of a user by email.
   - [CountryVote\CountryVote\Services\CountryService]: It is responsible of managing the Crud de Country and what it implies, in this case the top ten most voted
   - [CountryVote\CountryVote\Services\ExternalApiService]: It is responsible for managing the API service external to the project, in this particular case it reports the details of the top ten countries.
   - [CountryVote\CountryVote\Services\UserService]: It is responsible for managing User's crud.

2. **Installation Instructions**
   - You must have a database compatible with Entity Framework.
   - Download the project from the repository.
   - Execute the project with Visual Estudio 2022.
   - Modify the connection with the database in CountryVote\appsetting.json
        - "ConnectionStrings": {
           "ConnectionString": "Server="Server name";Database="Database name";Trusted_Connection=True;TrustServerCertificate=True;"
                               }
   - Execute the following commands in the Package Manager Console, setting "CountryVoteDataBaseContext" as Defaul Project
        - Add-Migration "name" for example: Add-Migration UserCountry (this will generate a Migrations folder in the CountryVoteDataBaseContext project)
        - Update-DataBase

4. **Testing Instructions**

   Once the project is executed, a web window with the name Swagger will open. The project could be tested right here by entering the necessary requests
   AddUser():
   {
  "name": "string",
  "email": "string",
  "countryName": "string"
  }
   If you use an external program such as Postman, you must enter the url that will be similar to the following: https://localhost:"numero"/api/User/AddUser
   To test the GetTopTenVotedCountries functionality, you do not need a body like the previous one but only execute it with the Try it Out and Execute buttons, if it is necessary that at least the database has 20 or more users who have voted for different countries .

6. **Service Design**
 For the design of the code, I decided to separate it by layers and communicate them through Interfaces in order to achieve independence from them, achieving a layer of data models, a layer of services, repository, database and controllers. In this way it would facilitate its maintenance and scalability; For this I use a generic class that inherits my data models and also a generic repository class that implements a CRUD. At the same time, functionalities and services have been separated to facilitate their reusability.
On the other hand, the data model was limited to the resolution of the technical requirements. In this way, the requested technical requirements and certain non-functional requirements such as scalability, maintainability, readability and documentation are met.

8. **Compromises or Trade-offs**

  Due to the time limit, I focused on meeting the functional requirements and as many non-functional requirements as possible, such as those mentioned above.
  Therefore, the model layer was reduced to two entities, which could have been three, including Vote, which could have recorded the country voted for and the user who voted for it; This would improve the possibility of adding functionalities in the future.
  On the other hand, security could be improved by applying JWS to generate tokens in requests.
The DTOs were reduced, specific Requests and Responses could also have been made for the functionalities, which leaves it open to future easily applicable modifications.

8. **Estimated time**
   6 hs
