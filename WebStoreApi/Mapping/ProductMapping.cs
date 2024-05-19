using WebStoreApi.ProductDtos;
using WebStoreApi.Entities;

namespace WebStoreApi.Mapping;

public static class ProductMapping
{
    // recebe entidade, retona formatada como DTO
    public static SummaryProductDto ToSummary(this ProductEntity product){
        return new SummaryProductDto(
            product.Id,
            product.SellerId,
            product.Seller!.Name,
            product.Name,
            product.Price,
            product.Description
        );
    }

    public static DetailsProductDto ToDetails(this ProductEntity product){
        return new DetailsProductDto(
            product.Id,
            product.SellerId,
            product.Name,
            product.Price,
            product.Description
        );
    }
}
