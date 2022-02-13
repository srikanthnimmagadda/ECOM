using ECOM.Core.Entities;

namespace ECOM.Core.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductsAsync();
        //Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        //Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
