DEPENDENCIAS
ADMINISTRAR PAQUETES NUGET
Microsoft entity framework core tolos
entity framework sql server


herramientas
administrador de paquetes nuget
consola

Scaffold-DbContext "Server=HP255G8\MSSQLSERVER01; Database=Pub; Trusted_Connection=True; TrustServerCertificate=True " Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


para actualizar es el mismo comando-forcé


te vas a appsettings

y se agrega la cadena de conexion
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "PubContext": "Server=HP255G8\\MSSQLSERVER01;Database=Pub;Trusted_Connection=True;TrustServerCertificate=True"
    }
}






nos vamos a program
y agregamos un servicio <> bdd mas context
builder.Services.AddDbContext<PubContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PubContext");
});  lo de entre comillas es lo de la cadena de coneccion

crear controlador: clic derecho, controllers
agregar conttolador 
mvc 
controlador
en blanco
poner nombre
clic derecho en index
agregar vista
vista vacia




en views en shared tenemos el layout

@{
	Layout = null;
}
para quitarlo de las vistas



para crear una clase se usa una view models
se crea carpeta dentro de models
luego en esta una clase, en este caso como es para beer se hace un "Beerviewmodels



Para hacer API, te vas a controladores
crear controlador
den tipo Api
en blanco
colocas nombre
ApiBeer
