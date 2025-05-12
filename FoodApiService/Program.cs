using System.Reflection;
using FluentValidation;
using FoodApiService.Context;
using FoodApiService.Dtos.ProductDtos;
using FoodApiService.Entities;
using FoodApiService.Mapping;
using FoodApiService.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>(); // dependency injection i�lemi yap�yoruz validasyonlar�
builder.Services.AddScoped<IValidator<CreateByIdProductDto>, CreateByIdProductDtoValidator>(); // dependency injection i�lemi yap�yoruz validasyonlar�
//builder.Services.AddAutoMapper(typeof(GeneralMapping)); bunuda yazsan olur ama aras�ndaki farklar� arast�rabilirsin......
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
