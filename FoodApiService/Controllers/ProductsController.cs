using AutoMapper;
using FluentValidation;
using FoodApiService.Context;
using FoodApiService.Dtos.ProductDtos;
using FoodApiService.Entities;
using FoodApiService.ValidationRules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IValidator<Product> _productValidator;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateByIdProductDto> _createByIdProductDtoValidator;  
        public ProductsController(ApiContext context, IValidator<Product> productValidator, IMapper mapper , IValidator<CreateByIdProductDto> createByIdProductValidator)
        {
            _context = context;
            _productValidator = productValidator;
            _mapper = mapper;
            _createByIdProductDtoValidator = createByIdProductValidator;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateByIdProductDto createByIdProductDto)
        {
            var validationResult = _createByIdProductDtoValidator.Validate(createByIdProductDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else 
            {
                var product = _mapper.Map<Product>(createByIdProductDto);

                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(new { message = "Ürün ekleme işlemi başarılı..", data = product }); // bu kullanım iyiymiş

            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(new { message = "Ürün silme işlemi başarılı.." , product.ProductName });

        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            _context.Products.Update(existingProduct);
            _context.SaveChanges();
            return Ok(new { message = "Ürün güncelleme işlemi başarılı..", data = existingProduct });
        }

        [HttpPost("CategoryId")]
        public IActionResult PostProduct(CreateByIdProductDto createProductDto) 
        {
            var product = _mapper.Map<Product>(createProductDto);
            _context.Add(product);
            _context.SaveChanges();

            return Ok(new { message = "Ürün ekleme işlemi başarılı..", data = product }); // bu kullanım iyiymiş
        }


        //2 tablo arasındaki berabaer baglantları getir!!!!!!! joinleme veya dto olur mu?
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            if (products == null || !products.Any())
            {
                return NotFound();
            }

            // AutoMapper ile dönüşüm
            var result = _mapper.Map<List<ResultProductWithCategoryDto>>(products);
            return Ok(result);
        }



    }
}
