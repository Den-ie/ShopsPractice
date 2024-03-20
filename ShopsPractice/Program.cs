using Microsoft.EntityFrameworkCore;
using ShopsPractice.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
var builder = WebApplication.CreateBuilder(args);

string connection = "data source=DESKTOP-VF1AQU4\\SQLEXPRESS; database = Shops; integrated security = True; encrypt = False; MultipleActiveResultSets = True";
builder.Services.AddDbContext<ShopsContext>(op => op.UseSqlServer(connection));

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
