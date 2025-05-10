using AutoMapper;
using FluentValidation;
using FoodApiService.Context;
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





    }
}
