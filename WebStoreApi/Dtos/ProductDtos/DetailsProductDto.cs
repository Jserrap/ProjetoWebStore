namespace WebStoreApi.ProductDtos;

public record class DetailsProductDto(
    int Id,
    int SellerId,
    string? Name,
    decimal Price,
    string? Description
);