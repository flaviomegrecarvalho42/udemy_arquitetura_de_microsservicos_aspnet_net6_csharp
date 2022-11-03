using AutoMapper;
using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.Models.Context;
using GeekShopping.ProductAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                Product product = await _context.Products.Where(product => product.Id == id)
                                                         .FirstOrDefaultAsync() ?? new Product();

                if (product.Id <= 0)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> FindAllAsync()
        {
            List<Product> listProduct = await _context.Products.ToListAsync();
            var listProductDto = _mapper.Map<List<ProductDto>>(listProduct);
            
            return listProductDto;
        }

        public async Task<ProductDto> FindByIdAsync(long id)
        {
            Product product = await _context.Products.Where(product => product.Id == id)
                                                     .FirstOrDefaultAsync() ?? new Product();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
