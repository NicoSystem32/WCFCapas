Proyecto WCF en Capas
Este proyecto es una aplicación de ejemplo desarrollada en .NET Framework utilizando el patrón de arquitectura en capas y tecnologías como Windows Communication Foundation (WCF), Entity Framework y SQL Server.

El objetivo principal del proyecto es demostrar una forma de implementar una aplicación escalable, mantenible y flexible a medida que se agregan más funcionalidades o se modifica el comportamiento existente. Para lograr este objetivo, se dividió la aplicación en diferentes capas, cada una con una responsabilidad específica.

Tecnologías utilizadas
.NET Framework 4.8
C# 7.3
Windows Communication Foundation (WCF) para la capa de servicios
Entity Framework 6 para la capa de acceso a datos
SQL Server Express para la base de datos
Patrón de arquitectura en capas
La arquitectura en capas es un patrón comúnmente utilizado en aplicaciones empresariales que se divide en diferentes capas, cada una con una responsabilidad específica. En este proyecto, las capas utilizadas son las siguientes:

Capa de presentación: Esta capa es la interfaz de usuario de la aplicación y está desarrollada con C# Razor en MVC. Se encarga de interactuar con el usuario y enviar solicitudes a la capa de servicios.
Capa de servicios: Esta capa es responsable de exponer la funcionalidad de la aplicación a través de servicios web utilizando WCF. Se comunica con la capa de acceso a datos para realizar operaciones CRUD en la base de datos.
Capa de acceso a datos: Esta capa se encarga de interactuar con la base de datos utilizando Entity Framework. Contiene los modelos de datos y las operaciones de CRUD necesarias para realizar las solicitudes de la capa de servicios.

Instrucciones de uso
Para utilizar la aplicación, siga los siguientes pasos:

Descargue o clone el repositorio en su máquina local.
Abra la solución en Visual Studio.
Restaure los paquetes NuGet necesarios para la solución.
Ejecute el script de creación de la base de datos en SQL Server.
Compile y ejecute el proyecto.
Asegúrese de poner la cadena de conexión correcta en los archivos .config de la capa de negicios y datos
Contribuciones
Las contribuciones son bienvenidas. Si desea contribuir al proyecto, siga los siguientes pasos:

Fork el repositorio en GitHub.
Cree una rama en su repositorio local y realice los cambios necesarios.
Envíe una solicitud de extracción a la rama principal del repositorio.
Se revisarán los cambios y, si son aceptados, se fusionarán en la rama principal del repositorio.
Licencia
Este proyecto está licenciado bajo la Licencia MIT. Consulte el archivo LICENSE para obtener más información.
