
# Título del Proyecto

_ApiKalmy es un proyecto desarrollado con NET CORE 3.1 el cual permite insertar, modificar, eliminar y consultar información de automóviles_

## Comenzando 🚀

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

Mira **Deployment** para conocer como desplegar el proyecto.


### Pre-requisitos 📋

_Que cosas necesitas para instalar el software y como instalarlas_

```
* Visual studio 2019
* Sql Server 2018
* NodeJS
* Git
```

### Instalación 🔧

_El primer paso es crear en tu server local una base de datos con el nombre KalmyDBDev_

_Puedes dirigirte al archivo appsettings.json en la sección ConnectionStrings para modificar lo necesario para que la conexión apunte a la base de datos creada anteriormente_

```
 "ConnectionStrings": {
    "Kalmy": "data source=LAPTOP-3NTPDV2V; initial catalog=KalmyDBDev;persist security info=True; Integrated Security=SSPI;MultipleActiveResultSets=True"

  }
```
_Se debe tomar en cuenta si el server local tiene una configuración especifica para un usuario es necesario que la cadena de conexión los especifique_

```
 "ConnectionStrings": {
    "Kalmy": "data source=LAPTOP-3NTPDV2V; initial catalog=KalmyDBDev;User ID=usuario;Password=password;persist security info=True; Integrated Security=SSPI;MultipleActiveResultSets=True"

  }
```

_Lo siguiente es correr las migraciones para la creación de las tablas, para esto se debe seleccionar el proyecto "Api" en la "Consola de administración de paquetes" y correr el siguiente comando_

```
update-database
```

_Si se obtiene algún error primero hay que asegurarse de habilitar las migraciones en entityFramework_

```
enable-migrations
```

_Asegurate que las tablas se crearon en tu manejador de base de datos_

_Dentro de la ruta "ApiKalmy\Api.Data" existe un archivo de nombre Information.sql, el cual tiene una carga inicial para probar con información pre-cargada_

## Ejecutando las pruebas ⚙️

_El proyecto esta configurado usando swagger, una vez desplegado el proyecto se mostrará una pantalla con los endpoints creados en el proyecto_


### Códigos de respuesta del protocolo HTTP 🔩

```
200: Success
204: No Content
400: Bad request
401: Unauthorized
404: Cannot be found
405: Method not allowed
422: Unprocessable Entity 
50X: Server Error
```

###   IMPORTANTE! NOTA: El api esta preparada para 2 usuarios 

```
usuario: admin
password: 1234

usuario: user:
password: 1234

La diferencia principal es que con usuario admin se podrá consultar el endpoint de búsqueda de combinaciones "Type", "Brand" o "Model".
Y con el usuario user sé podra tener acceso a un CRUD para insertar, actualizar, eliminar o consultar el catalogo de "Car".

```

### Usuario: "user" "1234" 🔩

_Como se mencionó anteriormente, el usuario "user" con password "1234" permite poder testear el CRUD de Car para ello, lo primero que se debe hacer en logearse con las credenciales para generar el token de autenticacion jwt_

### Login
### Request

`POST api/login/`

```
curl -X POST "https://localhost:44336/api/Login" -H "accept: */*" -H "Content-Type: application/json" -d "{\"UserName\":\"user\",\"Password\":\"1234\"}"
```
### Response 

```
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6IjIzMTc3Mzg2LWZmMzMtNDYzZC05NjQ5LWRjNTIzMDFjMWQzMiIsImV4cCI6MTYwMTk1MjM5NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.6QXRbWZbaZ3HjCkaXt7DFe8m0OjRHQ5qX57nDIV7GGo",
  "userDetails": {
    "UserName": "user",
    "FullName": "Test User",
    "Password": "1234",
    "UserRole": "User"
  }
}
```



### Get Cars
#### Request

`GET api/car`

```
curl -X GET "https://localhost:44336/api/Car" -H "accept: application/json" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6IjIzMTc3Mzg2LWZmMzMtNDYzZC05NjQ5LWRjNTIzMDFjMWQzMiIsImV4cCI6MTYwMTk1MjM5NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.6QXRbWZbaZ3HjCkaXt7DFe8m0OjRHQ5qX57nDIV7GGo"
```

#### Response 

```
[
  {
    "Id": 31,
    "Type": "big",
    "Brand": "nissan",
    "Model": 2019,
    "CreatedAt": "2020-10-05T18:41:15.4305501",
    "ModifiedAt": "2020-10-05T18:41:15.4305735"
  },
  {
    "Id": 32,
    "Type": "small",
    "Brand": "nissan",
    "Model": 2019,
    "CreatedAt": "2020-10-05T18:41:28.045708",
    "ModifiedAt": "2020-10-05T18:41:28.0457346"
]
```


### Get Car
#### Request

`GET api/car/1`

```
curl -X GET "https://localhost:44336/api/Car/1" -H "accept: application/json" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6IjIzMTc3Mzg2LWZmMzMtNDYzZC05NjQ5LWRjNTIzMDFjMWQzMiIsImV4cCI6MTYwMTk1MjM5NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.6QXRbWZbaZ3HjCkaXt7DFe8m0OjRHQ5qX57nDIV7GGo"
```

#### Response 

```
{
  "Id": 38,
  "Type": "string",
  "Brand": "string",
  "Model": 0,
  "CreatedAt": "2020-10-05T19:23:07.4033116",
  "ModifiedAt": "2020-10-06T00:21:29.025"
}
```


### Post Car
#### Request

`POST api/car`

```
curl -X POST "https://localhost:44336/api/Car" -H "accept: text/plain" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6ImEyY2M4N2M0LThkMjMtNDYyYy1iNzNkLWNjN2ZkOGE4YWU0OSIsImV4cCI6MTYwMTk1MzYxMywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.a3sd11LNbnkMY8Wf_O8yAxq4wZpqiHePvmug_u9-WDs" -H "Content-Type: application/json" -d "{\"Type\":\"big\",\"Brand\":\"small\",\"Model\":2019}"
```

#### Response 

```
{
  "Id": 50,
  "Type": "big",
  "Brand": "small",
  "Model": 2019,
  "CreatedAt": "2020-10-05T21:37:26.0656991-05:00",
  "ModifiedAt": "2020-10-05T21:37:26.065702-05:00"
}
```



### Put Car
#### Request

`PUT api/car/1`

```
curl -X PUT "https://localhost:44336/api/Car/1" -H "accept: text/plain" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6ImEyY2M4N2M0LThkMjMtNDYyYy1iNzNkLWNjN2ZkOGE4YWU0OSIsImV4cCI6MTYwMTk1MzYxMywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.a3sd11LNbnkMY8Wf_O8yAxq4wZpqiHePvmug_u9-WDs" -H "Content-Type: application/json" -d "{\"Id\":49,\"Type\":\"small\",\"Brand\":\"tesla\",\"Model\":2020}"
```

#### Response 

```
{
}
```


### Delete Car
#### Request

`DELETE api/car`

```
curl -X DELETE "https://localhost:44336/api/Car/49" -H "accept: */*" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6ImEyY2M4N2M0LThkMjMtNDYyYy1iNzNkLWNjN2ZkOGE4YWU0OSIsImV4cCI6MTYwMTk1MzYxMywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.a3sd11LNbnkMY8Wf_O8yAxq4wZpqiHePvmug_u9-WDs"
```

#### Response 

```
{
}
```


### Usuario: "admin" "1234" 🔩

_Como se mencionó anteriormente, el usuario "admin" con password "1234" permite poder testear el endpoint para la generación del json dependiendo la combinación de "Type", "Brand" y "Model", lo primero que se debe hacer en logearse con las credenciales para generar el token de autenticacion jwt_

### Login
### Request

`POST api/login/`

```
curl -X POST "https://localhost:44336/api/Login" -H "accept: */*" -H "Content-Type: application/json" -d "{\"UserName\":\"admin\",\"Password\":\"1234\"}"
```
### Response 

```
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiZnVsbE5hbWUiOiJUZXN0IFVzZXIiLCJyb2xlIjoiVXNlciIsImp0aSI6IjIzMTc3Mzg2LWZmMzMtNDYzZC05NjQ5LWRjNTIzMDFjMWQzMiIsImV4cCI6MTYwMTk1MjM5NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMzYvIn0.6QXRbWZbaZ3HjCkaXt7DFe8m0OjRHQ5qX57nDIV7GGo",
  "userDetails": {
    "UserName": "admin",
    "FullName": "Vaibhav Bhapkar",
    "Password": "1234",
    "UserRole": "Admin"
  }
}
```



### Search dynamic
#### Request

`POST /api/car/search`

#### Combinaciones posibles

```
{
    "parameter1": "Type",
    "parameter2": ""
}

{
    "parameter1": "Type",
    "parameter2": "Brand"
}

{
    "parameter1": "Type",
    "parameter2": "Model"
}


{
    "parameter1": "Model",
    "parameter2": ""
}

{
    "parameter1": "Model",
    "parameter2": "Brand"
}

{
    "parameter1": "Model",
    "parameter2": "Type"
}

{
    "parameter1": "Brand",
    "parameter2": ""
}

{
    "parameter1": "Brand",
    "parameter2": "Model"
}

{
    "parameter1": "Brand",
    "parameter2": "Type"
}
```


```
curl -X POST "https://localhost:44336/api/Car/search" -H "accept: */*" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImZ1bGxOYW1lIjoiVmFpYmhhdiBCaGFwa2FyIiwicm9sZSI6IkFkbWluIiwianRpIjoiZWI1NjUwZGYtNjdiNS00NGFlLWFlZDEtMzQzZTI0OTczZTAyIiwiZXhwIjoxNjAxOTU1MDAwLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMzNi8iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDMzNi8ifQ.aGRr4ujtklMeNRdDBLCwcLkZcbyIohzUeRbp6YfhF1U" -H "Content-Type: application/json" -d "{\"Parameter1\":\"Type\",\"Parameter2\":\"\"}"
```


#### Response (Dependiendo de la combinación la respuesta es dinámica)

```
[
    {
        "name": "nissan",
        "value": 6
    },
    {
        "name": "small",
        "value": 1
    },
    {
        "name": "string",
        "value": 5
    },
    {
        "name": "tesla",
        "value": 7
    }
]
```



```
[
    {
        "name": "nissan",
        "children": [
            {
                "name": 2019,
                "size": 4
            },
            {
                "name": 2020,
                "size": 2
            }
        ]
    },
    {
        "name": "small",
        "children": [
            {
                "name": 2019,
                "size": 1
            }
        ]
    },
    {
        "name": "string",
        "children": [
            {
                "name": 0,
                "size": 5
            }
        ]
    },
    {
        "name": "tesla",
        "children": [
            {
                "name": 2019,
                "size": 7
            }
        ]
    }
]

```

## Construido con 🛠️


_Algunas dependencias usadas dentro del proyecto_

```
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 3.1.4
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.8
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.8
Install-Package Microsoft.AspNetCore.Cors
Install-Package Swashbuckle.AspNetCore -Version 5.5.0
```

## Autores ✒️

_Menciona a todos aquellos que ayudaron a levantar el proyecto desde sus inicios_

* **Cristian Sifuentes** - *Trabajo Inicial* - [CristianSifuentes](https://github.com/CristianSifuentes)
* **Cristian Sifuentes** - *Documentación* 


## Expresiones de Gratitud 🎁

* Gracias por tomarme en cuenta para el test 📢
* Te agradeceria retroalimentación para poder mejorar en mi carrera 🍺.

---
⌨️ con ❤️ por [CristianSifuentes](https://github.com/CristianSifuentes) 😊
