
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

_1.- El primer paso es crear en tu server local una base de datos con el nombre KalmyDBDev_

_puedes dirigirte al archivo appsettings.json en la sección ConnectionStrings para modificar lo necesario para que la conexión apunte a la base de datos creada anteriormente_

```
 "ConnectionStrings": {
    "Kalmy": "data source=LAPTOP-3NTPDV2V; initial catalog=KalmyDBDev;persist security info=True; Integrated Security=SSPI;MultipleActiveResultSets=True"

  }
```
_Se debe tomar en cuenta si el server local tiene una configuracion especifica para un usuario es necesario que la cadena de conexión los especifique_

```
 "ConnectionStrings": {
    "Kalmy": "data source=LAPTOP-3NTPDV2V; initial catalog=KalmyDBDev;User ID=usuario;Password=password;persist security info=True; Integrated Security=SSPI;MultipleActiveResultSets=True"

  }
```

_Lo siguiente es correr las migraciones para la creación de las tablas, para esto de se debe seleccionar el proyect "Api" en la "Consola de administracion de paquetes" y correr el siguiente comando_

```
update-database
```

_Si se obtiene algún error primero hay que asegurarse de habilitar las migraciones en entityFramework_

```
enable-migrations
```

_Asegurate que las tablas se crearon en tu manejador de base de datos_


## Ejecutando las pruebas ⚙️

_El proyecto esta configurado usando swagger, una vez desplegado el proyecto de mostrara una pantalla con los endpoints creados en el proyecto_

### Analice las pruebas end-to-end 🔩

_Explica que verifican estas pruebas y por qué_

```
Da un ejemplo
```

### Y las pruebas de estilo de codificación ⌨️

_Explica que verifican estas pruebas y por qué_

```
Da un ejemplo
```

## Despliegue 📦

_Agrega notas adicionales sobre como hacer deploy_

## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto_

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - El framework web usado
* [Maven](https://maven.apache.org/) - Manejador de dependencias
* [ROME](https://rometools.github.io/rome/) - Usado para generar RSS

## Contribuyendo 🖇️

Por favor lee el [CONTRIBUTING.md](https://gist.github.com/villanuevand/xxxxxx) para detalles de nuestro código de conducta, y el proceso para enviarnos pull requests.

## Wiki 📖

Puedes encontrar mucho más de cómo utilizar este proyecto en nuestra [Wiki](https://github.com/tu/proyecto/wiki)

## Versionado 📌

Usamos [SemVer](http://semver.org/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/tu/proyecto/tags).

## Autores ✒️

_Menciona a todos aquellos que ayudaron a levantar el proyecto desde sus inicios_

* **Andrés Villanueva** - *Trabajo Inicial* - [villanuevand](https://github.com/villanuevand)
* **Fulanito Detal** - *Documentación* - [fulanitodetal](#fulanito-de-tal)

También puedes mirar la lista de todos los [contribuyentes](https://github.com/your/project/contributors) quíenes han participado en este proyecto. 

## Licencia 📄

Este proyecto está bajo la Licencia (Tu Licencia) - mira el archivo [LICENSE.md](LICENSE.md) para detalles

## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Invita una cerveza 🍺 o un café ☕ a alguien del equipo. 
* Da las gracias públicamente 🤓.
* etc.



---
⌨️ con ❤️ por [Villanuevand](https://github.com/Villanuevand) 😊
