namespace backend;

using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //User
        CreateMap<UserCreateDto, User>();
        CreateMap<User, UserReadDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        CreateMap<UserUpdateDto, User>();

        //Product
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            // .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.))
        CreateMap<ProductUpdateDto, Product>();

        //Category
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<Category, CategoryReadDto>();
        CreateMap<CategoryUpdateDto, Category>();

        //Image
        CreateMap<ImageCreateDto, Image>();
        CreateMap<Image, ImageReadDto>();
        CreateMap<ImageUpdateDto, Image>();
    }
}
