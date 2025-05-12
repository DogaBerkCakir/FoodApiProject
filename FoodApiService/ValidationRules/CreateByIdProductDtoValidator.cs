using FluentValidation;
using FoodApiService.Dtos.ProductDtos;

namespace FoodApiService.ValidationRules
{
    public class CreateByIdProductDtoValidator : AbstractValidator<CreateByIdProductDto>
    {
        public CreateByIdProductDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MinimumLength(2).WithMessage("En az 2 karakter giriniz.")
                .MaximumLength(50).WithMessage("En fazla 50 karakter giriniz.");

        }
    }
   
}
