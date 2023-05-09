using AutoMapper;
using InnovaCatalog;
using InnovaCatalog.DbContexts;
using InnovaCatalog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

//Serilog

    Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/InnovaCatalogs.txt",rollingInterval:RollingInterval.Day).CreateLogger();

    builder.Host.UseSerilog();

    //DbContext
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    //AutoMapper
    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    builder.Services.AddSingleton(mapper);
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    //Life time dependencies
    builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
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
