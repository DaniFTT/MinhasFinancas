using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infra.CrossCutting.IoC;
using MinhasFinancas.Infra.Data.Configurations;
using MinhasFinancas.Infra.CrossCutting.Swagger;
using MinhasFinancas.Infra.CrossCutting.Auth.Services;

var builder = WebApplication.CreateBuilder(args);


//Conexao Banco de Dados
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();

//IoC
NativeInjector.Register(builder.Services, builder.Configuration);

//Autenticacao
AuthenticationService.AddAuthentication(builder.Services, builder.Configuration);

//Swagger
SwaggerSetup.AddSwaggerConfiguration(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SwaggerSetup.UseSwaggerConfiguration(app);
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
