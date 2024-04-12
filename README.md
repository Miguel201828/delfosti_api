# delfosti_api
api rest para tracking de pedidos

Para la solucion del trackin de pedidos, se ha compuesto el siguiente entregable con 3 proyectos

El primero es el api de las entidades que se usaran en el web service, donde se tiene la info del usuario que se logea en el sistema
se tiene ademas la informacion del pedido y de sus cambios de estado.

El proyecto data tiene las conexiones a base de datos y los llamados a procedimientos almacenados para no exponer los nombres de las tablas
y campos de nuestra base de datos, solo se conoceran el nombre de los store procedures y parametros.
Se esta considerando usar un esquema de doble interfaz para la proteccion de la lectura del codigo, usando una interfaz generica que usa
los metodos basicos de mantenimiento (insertar, modificar, eliminar y consultar).

En el proyecto web (API) se tienen los controladores y los servicios que acceden a las clases de base de datos (repositorios), de igual manera
se ha considerado un esquema de interfaz generica para cada entidad para reutilizar los metodos basicos de manteminiento.

Dentro del proyecto web (API) tambien se tiene la configuracion del appsettings.json usados para este ejercicio

Ejemplo
---------------------------------
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "JWT": {
    "SecretKey": "DELFOSTI.@.144.#.Miguel_Vizarraga#$.",
    "Issuer": "http://localhost:5010",
    "Audience": "http://localhost:5010",
    "Subject": "baseWebApiDelfostiSubject"
  },
  "ConnectionStrings": {
    "SQLServerConnection": "Server=localhost\\MSSQLSERVER03;Database=DelfostiTrackBD;TrustServerCertificate=true;Trusted_Connection=True;user id=sa;password=Defolsti01;"
  }
}
---------------------------------------


Se esta colocando la cadena de conexion como un ejemplo de la configuracion para una base de datos SQl Server, en el proyecto data usamos
los objetos de ese motor de base de datos para el tracking de pedidos


La API tiene 3 metodos principales que se pueden consultar,
1. Login, aqui enviamos el correo y clave del trabajador, con lo cual se valida el correcto ingreso al sistema, asu vez que devuelve 
   un token jwt, el cual se registra en la base de datos para validar la conexion desde el front, ya que si se intenta acceder sin logearse
   se validara el token registrado que debe coincidir con el que se logeo, de lo contrario no permitira acciones dentro del api.
2. Creacion de Pedido, en este metodo se enviara la informacion del pedido (fecha, total, cod repartidor y codigo del vendedor, el listado
   de los productos y adicionalmente se estara enviado el cod de usuario logeado y el token jwt que se entrego al momento del logeo,
   primero se hara una validacion con el token (de la sesion del front) que debe coincidir con el registrado en la BD, caso contrario no se
   permitira ejecutar la accion, el metodo ejecutara la creacion del pedido de manera completa (cabecera y detalle) en caso suceda algun error
   se hara un rollback en la transaccion (a nivel de bd) y se enviara una respuesta, en la bd se registrara el detalle del error.
3. Cambio de estado, aqui se podra hacer el cambio del estado de un pedido, indicando el nro y el nuevo estado, adicional tambien se enviara
   el cod del usuario con el token jwt para la validacion del mismo, con lo cual, de proceder el cambio se hara el cambio de esta con la 
   validacion indicada, un estado puede cambiar a otro inferior, pero no a uno anterior, esta validacion se hace a nivel de bd y responde con
   el detalle de lo procesado, si se cambio el estado o no.