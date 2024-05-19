namespace WebStoreApi.ProductDtos;

public record class SummaryProductDto(
    int Id,
    int SellerId,
    string? Seller,
    string? Name,
    decimal Price,
    string? Description
);