using System.Linq;
using AutoMapper;
using Portal.Api.Dtos;
using Portal.Api.Models;

namespace Portal.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(src =>src.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDto>()                
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(src =>src.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}