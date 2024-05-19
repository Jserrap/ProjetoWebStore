namespace WebStoreApi.ProductDtos;

public record class PostProductDto(
    int SellerId,
    string Name,
    decimal Price,
    string Description
);
