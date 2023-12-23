# CountryVote

## Descripción

Este proyecto es la implementación de un servicio que pretende tener la posibilidad de agregar usuarios junto con un pais favorito al que votan y por otra parte un servico que informe los diez paises mas votados por los usuarios.

## Contenido del Repositorio

1. **Implementación del Servicio**
   - [CountryVote\CountryVote\Services\AuthenticatorService]: Se encarga de verificar la existencia previa de un usuario por el email.
   - [CountryVote\CountryVote\Services\CountryService]: Se encarga de manejar el Crud de Country y lo que ellos implica, en este caso el top diez mas votados.
   - [CountryVote\CountryVote\Services\ExternalApiService]: Se encarga de manejar el servicio de APis externa al proyecto, en este caso particular informa los detalles de los paises del top diez.
   - [CountryVote\CountryVote\Services\UserService]: Se encarga de manejar el crud de User..

2. **Instrucciones de Instalación**

   - Se debe tener una base de datos compatible con Entity Framework.
   - Descargar el proyecto desde el repositorio.
   - Ejecutar el proyecto con Visual Estudio 2022.
   - Modificar la conexion con la base de datos en CountryVote\CountryVote\appsetting.json
        -  "ConnectionStrings": {
           "ConnectionString": "Server="Nombre del servidor";Database="nombre de la Base de Datos";Trusted_Connection=True;TrustServerCertificate=True;"
                               }
   - Ejecutar los siguientes comandos en la consola Package Manager Console, colocando como Defaul Proyect "CountryVoteDataBaseContext"
        - Add-Migration "nombre" por ejemplo: Add-Migration UserCountry (esto generara una carpeta Migrations en el proyecto de CountryVoteDataBaseContext"
        - Update-DataBase

4. **Instrucciones de Pruebas**

   Una vez Ejecutado el proyecto, se abrira una ventana web con el nombre de Swagger. Aqui mismo podria probarse el proyecto ingresando los request necesarios
   AddUser():
   {
  "name": "string",
  "email": "string",
  "countryName": "string"
  }
   En caso de utilizar un programa externo como Postman de debe colocar la url que sera similar a la siguiente: https://localhost:"numero"/api/User/AddUser
   Para realizar el test del la funcionalidad GetTopTenVotedCountries no es necesario un body como la anterior sino solo ejecutarlo con los botones de Try it Out y Execute, si es necesario que al menos la base de datos tenga 20 o mas usuarios que hayan votado a paises diferentes.

6. **Diseño del Servicio**
  Para el diseño del código decidí separarlo por capas y comunicarlas mediante Interfaces para así poder lograr independencia de las mismas logrando una capa de modelos de datos, una de servicios, repositorio, base de datos y controladores. De esta forma facilitaría su mantenimiento y escalabilidad; para esto utilice una clase genérica que de ella hereda mis modelos de datos y  también una clase genérica de repositorio que implementa un CRUD. A su vez, se han separado funcionalidades y servicios para facilitar su reusabilidad. 
Por otra parte, el modelo de datos fue acotado a la resolución de los requerimientos técnicos. De esta manera se logran cumplir con los requerimientos técnicos pedidos y ciertos requerimientos no funcionales como escalabilidad, mantenibilidad, legibilidad y documentación.
   
7. **Compromisos o Trade-offs**

  Debido al límite de tiempo me centre en cumplir con los requerimientos funcionales y la mayor cantidad de no funcionales posibles como los antes mencionados.
  Por lo tanto, fue reducida la capa de modelos a dos entidades, la cual podrían haber sido tres incluyendo Vote, la cual podría haber registrado el país votado y el usuario que lo votó;  esto mejoraría la posibilidad a futuro de añadir funcionalidades. 
  Por otro lado la seguridad podría mejorarse aplicando JWS para generar tokens en las peticiones.
Los DTO fueron reducidos, también se podría haber realizados Request y Responses específicos para las funcionalidades, lo cual deja abierto a futuras modificaciones fácilmente aplicables.

8. **Tiempo estimado**
   6 hs
