using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebStoreApi.Data;
using WebStoreApi.Endpoints;
using WebStoreApi.Entities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebStore");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<WebStoreContext>(connectionString);

builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "WebStore API",
         Description = "Comprar e vender, aonde você quiser",
         Version = "v1" });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore API V1");
   });
}

app.MapSellerEndpoints();
app.MapProductEndpoints();

app.Run();