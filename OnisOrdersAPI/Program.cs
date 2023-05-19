using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnisOrdersAPI;
using OnisOrdersAPI.DbContexts;
using OnisOrdersAPI.Repository;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Lifetime 
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton<IConnection>(sp =>
{
    var factory = new ConnectionFactory()
    {
        HostName = "localhost", // Cambia esto con la dirección IP o nombre de host de tu servidor RabbitMQ
        UserName = "guest", // Cambia esto con tu nombre de usuario de RabbitMQ
        Password = "guest" // Cambia esto con tu contraseña de RabbitMQ
    };

    return factory.CreateConnection();
});




var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
