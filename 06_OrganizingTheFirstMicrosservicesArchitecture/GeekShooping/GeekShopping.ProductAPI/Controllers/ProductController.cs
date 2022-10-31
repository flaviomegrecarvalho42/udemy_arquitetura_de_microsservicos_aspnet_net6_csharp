using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetAll()
        {
            var productDtos = await _repository.FindAllAsync();

            return Ok(productDtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var product = await _repository.FindByIdAsync(id);

            if (product.Id <= 0)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var productDtoCreated = await _repository.CreateAsync(productDto);

            return Created("product", productDtoCreated);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Put(ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var productDtoUpdated = await _repository.UpdateAsync(productDto);

            return Ok(productDtoUpdated);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteAsync(id);

            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
