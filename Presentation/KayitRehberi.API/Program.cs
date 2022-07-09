using KayitRehberi.Application;
using KayitRehberi.Infrastructure;
using KayitRehberi.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Custom extension metodu ekledik.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer("Admin",options=>
       {
           options.TokenValidationParameters = new()
           {
               ValidateAudience = true, //oluþturulan token deðerini kimlerin kullanacaðýný belirlediðimiz deðer
               ValidateIssuer = true, // oluþturulacak token deðerini kimin daðýttýðýný ifade edeceðimiz alan
               ValidateLifetime = true, // oluþturulan token deðerinin süresini kontrol edecek olan doðrulama
               ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade deden security key verisinin doðrulanmasýdýr.

               ValidAudience = builder.Configuration["Token:Audience"],
               ValidIssuer = builder.Configuration["Token:Issuer"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))

           };
       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
