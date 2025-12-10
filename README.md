# DSW1_T2_SermenoCruzMarcos_API

Este proyecto implementa una API RESTful para la gestión de préstamos de libros, utilizando la arquitectura de Clean Architecture (Domain, Application, Infrastructure, API) sobre .NET 8 y Entity Framework Core con MySQL.

### REQUISITOS DEL SISTEMA 

- SDK de .NET: Versión 8.0 o superior.

- Servidor MySQL: Debe estar corriendo en tu máquina (localhost por defecto) o en un servidor accesible.

- Herramienta dotnet-ef: Para manejar las migraciones y la base de datos.

``` dotnet tool install --global dotnet-ef --version 8.* ``` 

### Configuración y Ejecución del Proyecto

Configurar el .env en la capa API

DB_SERVER	

DB_DATABASE	

DB_USER	

DB_PASSWORD

### Verificar el estado de la BD y compilar

` dotnet build `

`  dotnet ef database update --startup-project src/DSW1_T2_SermenoCruzMarcos.API --project src/DSW1_T2_SermenoCruzMarcos.Infrastructure `

### Iniciar 

` dotnet run --project src/DSW1_T2_SermenoCruzMarcos.API `

### INGRESAR AL SWAGGER PARA PRUEBAS

http://localhost:5132/swagger

