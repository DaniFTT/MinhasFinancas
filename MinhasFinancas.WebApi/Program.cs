using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infra.Data.Configurations;
using MinhasFinancas.WebApi;

var builder = WebApplication.CreateBuilder(args);


//Conexao Banco de Dados
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(Settings.DefaultConnection));
builder.Services.AddDefaultIdentity<User>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Context>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
