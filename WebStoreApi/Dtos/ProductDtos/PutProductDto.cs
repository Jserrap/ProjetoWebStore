namespace WebStoreApi;

public record class PutProductDto(
    string Name,
    decimal Price,
    string Description
);
