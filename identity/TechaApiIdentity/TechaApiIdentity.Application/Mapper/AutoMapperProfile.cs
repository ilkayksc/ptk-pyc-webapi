using AutoMapper;
using System;
using System.Text.RegularExpressions;
using TechaApiIdentity.Data;

namespace TechaApiIdentity.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Category service
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedById, opt => opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());


            // Post Service
            CreateMap<Post, PostDto>()
                .ForMember(x => x.Category, opt => opt.MapFrom<Category>(c => c.Category))
                .ForMember(x => x.PlainContent, opt => opt.MapFrom(s => RemoveHTMLTags(s.Content)));
            CreateMap<PostDto, Post>()
                .ForMember(x => x.Category, opt => opt.MapFrom<CategoryDto>(c => c.Category));

            CreateMap<CreatePostDto, Post>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedById, opt => opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.Ignore());

            CreateMap<UpdatePostDto, Post>()
                .ForMember(x => x.Id, opt => opt.UseDestinationValue())
                .ForMember(x => x.CreatedDate, opt => opt.UseDestinationValue())
                .ForMember(x => x.CreatedBy, opt => opt.UseDestinationValue())
                .ForMember(x => x.CreatedById, opt => opt.UseDestinationValue())
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(s => DateTime.UtcNow));
        }
        private string RemoveHTMLTags(string HTMLCode)
        {
            return Regex.Replace(HTMLCode, @"<[^>]*>", String.Empty);
        }
    }
}
