using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;
using TaskManager.Infrastructure.Data.Repositories;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interfaces;
using FluentValidation.AspNetCore;
using TaskManager.Application.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Reflection;
;

var builder = WebApplication.CreateBuilder(args);

//Logs
builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File("Logs\\log.txt")
    .WriteTo.Console()
    .CreateLogger();


// Add services to the container.
// Connection to the SQL Server Database
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RamonConnection")));
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LauraConnection")));

builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TaskValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<StateValidation>();

builder.Services.AddSingleton(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = "tarea",
        ValidAudience = "tarea",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ab1b3089779b50d1b9bb03c3e15be7a0"!))
    };
});
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(opt =>
{
    //Documentación general API
    opt.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "TaskManager API", 
        Description = "Proyecto final del bootcamp de aplicaciones web en .NET de Codigo Facilito",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Laura Alvarez y Ramón Rodriguez",
            Url = new Uri("https://github.com/laura-alvarez/ProyectoBootcampNET")
        }        
    });

    //Autenticación para probar JWT
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor introduzca el bearer token generado con el método CheckUser",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

    //Documentación de la API
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    opt.IncludeXmlComments(xmlCommentsFullPath);
});


// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Swagger only avaliable on development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        //setupAction.RoutePrefix = String.Empty;
        setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
        setupAction.DisplayRequestDuration();
        setupAction.EnableFilter();
    });
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
