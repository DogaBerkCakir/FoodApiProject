using AutoMapper;
using FoodApiService.Dtos.FeatureDtos;
using FoodApiService.Dtos.MessageDtos;
using FoodApiService.Dtos.ProductDtos;
using FoodApiService.Entities;

namespace FoodApiService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature , ResultFeatureDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            CreateMap<Feature , CreateFeatureDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            CreateMap<Feature , UpdateFeatureDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            CreateMap<Feature , GetByIdFeatureDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            
            CreateMap<Message , ResultMessageDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            CreateMap<Message , GetByIdMessageDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            CreateMap<Message , CreateMessageDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar
            CreateMap<Message , UpdateMessageDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar

            CreateMap<Product, CreateProductDto>().ReverseMap(); // tam tersi de maplensin yazmamıza gerek kalmadı tekrar

        }
    }
}
