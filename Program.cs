using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PizzaDB>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo {
          Title = "PizzaStore API",
          Description = "Making the Pizzas you love", 
          Version = "v1" });

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/Swagger/v1/swagger.json", "PizzaStore API V1");
});
app.MapGet("/pizzas", async (PizzaDB db) => await db.Pizzas.ToListAsync());

app.Run();
