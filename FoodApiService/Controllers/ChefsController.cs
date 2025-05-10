using FoodApiService.Context;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChefs()
        {
            var chefs = _context.Chefs.ToList();
            return Ok(chefs);
        }

        [HttpGet("{id}")]
        public IActionResult GetChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound();
            }
            return Ok(chef);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            if (chef == null)
            {
                return BadRequest();
            }
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef sisteme başarılı bir şekilde eklendi....");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound();
            }
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Şef silindi....");
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
           _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef güncellendi....");
        }
    }
}
