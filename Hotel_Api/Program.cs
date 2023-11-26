using Hotel.Repositorio;
using Hotel.Repositorio.Contrato;
using Hotel.Repositorio.Implementaciones;
using Hotel.Utilidades;
using Microsoft.EntityFrameworkCore;
using Hotel.Servicio.Contrato;
using Hotel.Servicio.Implementacion;




var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var builder = WebApplication.CreateBuilder(args);

//ILogger logger = LoggerFactory.Create(config =>
//{
//    config.AddConsole();
//}).CreateLogger("Program"); ;



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8100")
                          .AllowAnyMethod()
                          .AllowAnyHeader(); 
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelContext>(options => {
    string sqlconnectio = builder.Configuration.GetConnectionString("cadenasSQL")!;
    options.UseNpgsql(sqlconnectio);
    //if (!builder.Environment.IsDevelopment())
    //{
    //    //string databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    //    //logger.LogInformation("String de conexion: "+ databaseUrl);
    //}
    //else {
       
    //}
});

builder.Services.AddTransient(typeof(IGenericoRepositorio<>) , typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IImagen, ImagenServicio>();
builder.Services.AddScoped<IInventario, InventarioServicio>();
builder.Services.AddScoped<IPersona, PersonaServicio>();
builder.Services.AddScoped<IUsuario, UsuarioServicio>();
builder.Services.AddScoped<IHotelServicio, HotelServicio>();
builder.Services.AddScoped<IReservaServicio , ReservaServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
