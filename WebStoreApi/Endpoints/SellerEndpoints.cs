namespace WebStoreApi.Endpoints;

using Microsoft.EntityFrameworkCore;
using WebStoreApi.Data;
using WebStoreApi.Entities;
using WebStoreApi.SellerDtos;

public static class SellerEndpoints
{
    public static RouteGroupBuilder MapSellerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("seller");

        group.MapGet("/", async (WebStoreContext db) => await db.Sellers.ToListAsync());

        group.MapGet("/{id}", async (int id, WebStoreContext db) => await db.Sellers.FindAsync(id));

        group.MapPost("/", async (WebStoreContext db, SellerDto newSeller) => 
        {
            // instancia da entidade seller (id implicito)
            SellerEntity seller = new(){
                Name = newSeller.Name,
                CreationDate = DateOnly.FromDateTime(DateTime.Today) // data atual
            };

            await db.Sellers.AddAsync(seller);
            await db.SaveChangesAsync();

            return Results.Created($"/{seller.Id}", seller);
        });

        group.MapPut("/{id}", async (int id, WebStoreContext db, SellerDto updateSeller) => 
        {
            var seller = await db.Sellers.FindAsync(id);
            if(seller is null) return Results.NotFound();

            // atualiza apenas nome
            seller!.Name = updateSeller.Name;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WebStoreContext db) =>
        {
            var seller = db.Sellers.Find(id);
            if(seller is null) return Results.NotFound();

            db.Products.Where(product => product.SellerId == seller.Id).ExecuteDelete();

            db.Sellers.Remove(seller);
            await db.SaveChangesAsync();

            return Results.Ok();
        });

        return group;
    }
}
