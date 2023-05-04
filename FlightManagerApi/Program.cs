using FlightManagerApi.Data;
using FlightManagerApi.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 
 builder.Services.AddControllers();
 // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<LogicLegs>();

 var app = builder.Build();
 // Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }
 app.UseAuthorization();
 app.MapControllers();
 app.Run();
 