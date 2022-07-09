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
               ValidateAudience = true, //olu�turulan token de�erini kimlerin kullanaca��n� belirledi�imiz de�er
               ValidateIssuer = true, // olu�turulacak token de�erini kimin da��tt���n� ifade edece�imiz alan
               ValidateLifetime = true, // olu�turulan token de�erinin s�resini kontrol edecek olan do�rulama
               ValidateIssuerSigningKey = true, //�retilecek token de�erinin uygulamam�za ait bir de�er oldu�unu ifade deden security key verisinin do�rulanmas�d�r.

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
