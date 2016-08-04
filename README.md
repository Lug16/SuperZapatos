# SuperZapatos

Prueba técnica utilizando tecnologías Microsoft Web API y Asp.net MVC

Para ejecutar el programa de manera exitosa se debe correr el script de base de datos:

> ######SuperZapatos.sql

Además de esto

- IIS debe estar instalado
- Al crear el sitio WebApi este debe tener tipo de autenticación Anónima (Anonymous Authentication) habilitada, las demás deben estar inhabilitadas
- Trabaja bajo el **.Net Framework 4.5**
- Confirmar las cadenas de conexion de acuerdo a la configuración de la maquina donde se este instalando la plataforma y modificarlas si es necesario
- La llave de configuración de la aplicacion MVC para poder consumir los servicios es **WebRespositoryUrl**, esta debe ser modificada de acuerdo a como haya sido instalada la solucion Web Api (tener en cuenta que la finalizacion *../services/* es importante)
