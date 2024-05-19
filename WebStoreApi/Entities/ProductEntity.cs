using WebStoreApi.Data;

namespace WebStoreApi.Entities;

public class ProductEntity
{
    public int Id {get; set;}
    public int SellerId {get; set;}
    public SellerEntity? Seller {get; set;}
    public string? Name {get; set;}
    public decimal Price {get; set;}
    public string? Description {get; set;}    
}
