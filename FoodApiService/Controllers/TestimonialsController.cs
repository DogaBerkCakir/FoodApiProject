using FoodApiService.Context;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiTestimonial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;

        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTestimonial()
        {
            var services = _context.Testimonials.ToList();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var service = _context.Testimonials.Find(id);
            if (service == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateTestimonials(Testimonial service)
        {
            _context.Testimonials.Add(service);
            _context.SaveChanges();
            return Ok("Referans başarıyla eklendi.");
        }


        [HttpDelete]
        public IActionResult DeleteTestimonials(int id)
        {
            var service = _context.Testimonials.Find(id);
            if (service == null)
            {
                return NotFound("Referans bulunamadı.");
            }
            _context.Testimonials.Remove(service);
            _context.SaveChanges();
            return Ok("Referans başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateTestimonials(Testimonial service)
        {
            _context.Testimonials.Update(service);
            _context.SaveChanges();
            return Ok("Referans başarıyla güncellendi.");
        }
    }

}

