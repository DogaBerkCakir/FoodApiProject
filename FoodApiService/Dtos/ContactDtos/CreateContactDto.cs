﻿namespace FoodApiService.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
    }
}
