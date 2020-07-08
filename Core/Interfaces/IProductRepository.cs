using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        /*
            Gets the product by id.
        */
        Task<Product> GetProductByIdAsync(int id);

        /*
            Gets the read-only list of products.
        */
        Task<IReadOnlyList<Product>> GetProductsAsync();

        /*
        
        */
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}