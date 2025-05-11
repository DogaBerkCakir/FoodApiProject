using AutoMapper;
using FluentValidation;
using FoodApiService.Context;
using FoodApiService.Dtos.ProductDtos;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IValidator<Product> _productValidator;
        private readonly IMapper _mapper;
        public ProductsController(ApiContext context, IValidator<Product> productValidator, IMapper mapper)
        {
            _context = context;
            _productValidator = productValidator;
            _mapper = mapper;
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
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _productValidator.Validate(product);
            // bu şu anlama geliyor ->  sana gonderdigim nesneyi kontrol et 

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else 
            { 
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            return Ok(new {message = "Ürün ekleme işlemi başarılı.." , data= product}); // bu kullanım iyiymiş

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
        public IActionResult PostProduct(CreateProductDto createProductDto) 
        {
            var product = _mapper.Map<Product>(createProductDto);
            _context.Add(product);
            _context.SaveChanges();

            return Ok(new { message = "Ürün ekleme işlemi başarılı..", data = product }); // bu kullanım iyiymiş
        }




    }
}
