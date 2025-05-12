using FluentValidation;
using FoodApiService.Dtos.ProductDtos;
using FoodApiService.Entities;

namespace FoodApiService.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product> // bu fluent validation sadece product entity için bunlar daha fazla yazılabilir
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Urun Adi Bos Olamaz...");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("En az 2 karakter girisi yapiniz...");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz....");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Bos Olamaz...");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır...");
            RuleFor(x => x.Price).LessThan(1000).WithMessage("Fiyat 1000'den küçük olmalıdır...");
            
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Urun Aciklamasi Bos Olamaz...");
        }


    }
}
