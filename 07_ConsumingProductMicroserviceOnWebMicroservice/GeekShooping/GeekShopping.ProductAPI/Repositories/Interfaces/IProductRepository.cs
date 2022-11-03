using GeekShopping.ProductAPI.Data.DTO;

namespace GeekShopping.ProductAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        Task<ProductDto> CreateAsync(ProductDto productDto);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(long id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> FindAllAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductDto> FindByIdAsync(long id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        Task<ProductDto> UpdateAsync(ProductDto productDto);
    }
}
