using AutoMapper;
using InnovaCatalog;
using InnovaCatalog.DbContexts;
using InnovaCatalog.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingresar Bearer [space] tuToken \r\n\r\n " +
                      "Ejemplo: Bearer 123456abcder",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id= "Bearer"
                },
                Scheme = "oauth2",
                Name="Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });




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
    builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

    var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();


    app.UseAuthorization();

    app.MapControllers();

    app.Run();
