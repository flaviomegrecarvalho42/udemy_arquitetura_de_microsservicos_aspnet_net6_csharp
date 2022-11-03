using GeekShopping.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteProductById(long id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductViewModel>> FindAllProducts();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductViewModel> FindProductById(long id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);
    }
}
