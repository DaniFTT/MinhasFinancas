using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infra.CrossCutting.IoC;
using MinhasFinancas.Infra.Data.Configurations;
using MinhasFinancas.Infra.CrossCutting.Swagger;
using MinhasFinancas.Infra.CrossCutting.Auth.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


//Conexao Banco de Dados
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<Context>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


//IoC
NativeInjector.Register(builder.Services, builder.Configuration);

//Autenticacao
AuthenticationService.AddAuthentication(builder.Services, builder.Configuration);

//Swagger
SwaggerSetup.AddSwaggerConfiguration(builder.Services);

builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
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
