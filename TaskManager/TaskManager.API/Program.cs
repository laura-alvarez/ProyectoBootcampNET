using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;
using TaskManager.Infrastructure.Data.Repositories;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interfaces;
;

var builder = WebApplication.CreateBuilder(args);
/*try
{
    string? conecte = builder.Configuration.GetConnectionString("DefaultConnection");
    using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")))
    {
        connection.Open();
        Console.WriteLine("Conexión exitosa.");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
}*/
// Add services to the container.
// Connection to the SQL Server Database
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



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
builder.Services.AddSwaggerGen();


// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Swagger only avaliable on development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
