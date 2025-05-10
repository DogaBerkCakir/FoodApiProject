using FoodApiService.Context;
using FoodApiService.Dtos.ContactDtos;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();


            // bu amelelik :D  manuel mapleme işlemlerini yapıyoruz !
            // AutoMapper kullanalım DAHA KOLAY OLUR :d
            contact.OpenHours=createContactDto.OpenHours;
            contact.Address = createContactDto.Address;
            contact.MapLocation = createContactDto.MapLocation;
            contact.Email = createContactDto.Email;
            contact.PhoneNumber = createContactDto.PhoneNumber;
            // 3 farklı yontem var bunların hepsini görecegiz.....
           

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return Ok("Ekleme işlemi başarılı.....");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound("Böyle bir kayıt bulunamadı");
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetContactId")]
        public IActionResult GetContact(int ContactId)
        {
            var contact = _context.Contacts.Find(ContactId);
            if (contact == null)
            {
                return NotFound("Böyle bir kayıt bulunamadı");
            }
            return Ok(contact);
        }


        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {

            Contact contact = new Contact();
            
            contact.OpenHours = updateContactDto.OpenHours;
            contact.Address = updateContactDto.Address;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Email = updateContactDto.Email;
            contact.PhoneNumber = updateContactDto.PhoneNumber;
            contact.ContactId = updateContactDto.ContactId;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }




    }
}
