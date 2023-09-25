using UserStoreApi.Models;
using UserStoreApi.Services;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// gets the APIKEY 

var tinderApiKey = builder.Configuration["Tinder:ServiceApiKey"];
var clientId = builder.Configuration["Authentication:Google:ClientId"]!;
var clientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;






// Add services to the container.

builder.Services.Configure<UserStoreDatabaseSettings>(
    builder.Configuration.GetSection("UserStoreDatabase")
);

builder.Services.AddSingleton<UsersService>();

// adding google aut service 
builder.Services.AddAuthentication().AddGoogle(googleOptions => 
    {
        googleOptions.ClientId = clientId;
        googleOptions.ClientSecret = clientSecret;
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => clientSecret);


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
