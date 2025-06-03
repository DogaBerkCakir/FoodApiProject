using AutoMapper;
using FoodApiService.Context;
using FoodApiService.Dtos.CategoryDtos;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);
            if (result == null)
            {
                return BadRequest("Kategori oluşturulamadı.");
            }
            _context.Categories.Add(result);
            _context.SaveChanges();

            return Ok("Kategori başarıyla eklendi.");
        }


        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            var category = _context.Categories.Find(dto.Id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            category.CategoryName = dto.CategoryName;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi.");
        }

    }
}
