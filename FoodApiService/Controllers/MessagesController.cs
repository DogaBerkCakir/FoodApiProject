using AutoMapper;
using FoodApiService.Context;
using FoodApiService.Dtos.MessageDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ResultMessageDto>(value));
        }

        [HttpPost]
        public IActionResult AddMessage(CreateMessageDto message)
        {
            var value = _mapper.Map<Entities.Message>(message);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Eklendii....");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto message)
        {
            var value = _mapper.Map<Entities.Message>(message);
            if (value == null)
            {
                return NotFound();
            }
            _context.Update(value);
            _context.SaveChanges();
            return Ok("Güncellendi....");
        }

        [HttpDelete] //delete işlemlerinded map leme yapılmazz zaten delete nin dto su olmaz
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Silindi....");
        }






    }
}
