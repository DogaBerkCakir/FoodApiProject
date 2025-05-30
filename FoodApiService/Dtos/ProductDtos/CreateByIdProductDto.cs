﻿using FoodApiService.Entities;

namespace FoodApiService.Dtos.ProductDtos
{
    public class CreateByIdProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; } //kategorisiz urun olabilir?
    }
}
