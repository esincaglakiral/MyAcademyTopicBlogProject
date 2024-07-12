using AutoMapper;
using Topic.DTOLayer.DTOs.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            //CreateMap<ResultBlogDto, Blog>().ReverseMap();
            CreateMap<ResultBlogDto, Blog>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
               .ReverseMap();
        }
    }
}
