namespace WebStoreApi.Endpoints;

using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;
using WebStoreApi.Data;
using WebStoreApi.Entities;
using WebStoreApi.SellerDtos;
using WebStoreApi.ProductDtos;
using Microsoft.AspNetCore.Http.HttpResults;
using WebStoreApi.Mapping;

public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("products");

        group.MapGet("/", async (WebStoreContext db) => 
                    await db.Products.Include(product => product.Seller) //mostrar obj dentro de obj
                    .Select(product => product.ToSummary())
                    .AsNoTracking()
                    .ToListAsync());

        group.MapGet("/{id}", async (int id, WebStoreContext db) => 
        {
            ProductEntity? product = await db.Products.FindAsync(id);

            return product is null ?
                Results.NotFound() :
                Results.Ok(product.ToDetails());
        });

        group.MapPost("/",async (WebStoreContext db, PostProductDto newProduct) => 
        {
            var seller = await db.Sellers.FindAsync(newProduct.SellerId);
            if(seller is null) return Results.NotFound("Seller Id not found");

            ProductEntity product = new(){
                SellerId = newProduct.SellerId,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description
            };

            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();    

            return Results.Created($"/{product.Id}", product.ToDetails());
        });

        group.MapPut("/{id}", async (int id, WebStoreContext db, PutProductDto updateDto) => 
        {
            var product = await db.Products.FindAsync(id);
            if(product is null) return Results.NotFound();

            product.Name = updateDto.Name;
            product.Price = updateDto.Price;
            product.Description = updateDto.Description;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WebStoreContext db) =>
        {
            var product = await db.Products.FindAsync(id);
            if(product is null) return Results.NotFound();

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Results.Ok();
        });

        return group;
    }
}