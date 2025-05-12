using FoodApiService.Context;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        
        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetService()
        {
            var services = _context.Services.ToList();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateServices(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Kategori başarıyla eklendi.");
        }


        [HttpDelete]
        public IActionResult DeleteServices(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateServices(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi.");
        }
    }
    
}
