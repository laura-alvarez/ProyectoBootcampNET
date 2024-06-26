using Blazored.LocalStorage;
using BlazorWebAssemblyApp.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManager.Client.Components;
using TaskManager.Client.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7184/") });

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor(); 
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TaskManager.Client.Extensiones.LocalStorage>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = "tarea",
        ValidAudience = "tarea",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ab1b3089779b50d1b9bb03c3e15be7a0"!))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<User>();
builder.Services.AddScoped<TaskType>();
HttpClient client = new();
client.BaseAddress = new("https://localhost:7184");
builder.Services.AddSingleton(client);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}


app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
