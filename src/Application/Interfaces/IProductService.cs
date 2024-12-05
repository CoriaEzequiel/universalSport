using Domain.Entities;
using Application.Models.Request;

namespace Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsWithMaxPrice(decimal price);
        Product? Get(string name);
        Product? Get(int id);
        int AddProduct(ProductCreateRequest request);
        void DeleteProduct(int id);
        void UpdateProduct(int id, ProductUpdateRequest request);
    }
}
