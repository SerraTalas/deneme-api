using AutoMapper;
using DenemeAPI.Dto;
using DenemeAPI.Models;
using DenemeAPI.Request;
using DenemeAPI.Response;

namespace DenemeAPI.Helper
{
	public class MappingProfiles : Profile
	{
        public MappingProfiles()
        {
			CreateMap<Book, BookDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Book, GetBookDto>()
				.ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name)) 
			.ReverseMap();
			CreateMap<GetBookDto, GetBookResponse>();
			CreateMap<AddBookRequest, BookDto>().ReverseMap();
			CreateMap<BookDto, AddBookResponse>().ReverseMap();
			CreateMap<UpdateBookRequest, BookDto>().ReverseMap();	
			CreateMap<BookDto, UpdateBookResponse>().ReverseMap();
			CreateMap<AddCategoryRequest, CategoryDto>().ReverseMap();
			CreateMap<CategoryDto, AddCategoryResponse>().ReverseMap();
			CreateMap<UpdateCategoryRequest, CategoryDto>().ReverseMap();
			CreateMap<CategoryDto, UpdateCategoryResponse>().ReverseMap();
			CreateMap<CategoryDto, GetCategoryResponse>();
		}
    }
}
