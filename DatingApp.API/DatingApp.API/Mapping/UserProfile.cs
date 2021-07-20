using AutoMapper;
using DatingApp.API.DTO;
using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Extentions;
namespace DatingApp.API.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserListDto>()
                .ForMember(des => des.Age, source => source.MapFrom(a => a.DateOfBirth.CalcuateAge()))
                .ForMember(des => des.PhotoUrl, source => source.MapFrom(a => a.Photos.FirstOrDefault().Url));
                
            CreateMap<AppUser, UserListDetailsDto>()
                .ForMember(des => des.Age, source => source.MapFrom(a => a.DateOfBirth.CalcuateAge()))
                .ForMember(des => des.PhotoUrl, source => source.MapFrom(a => a.Photos.FirstOrDefault().Url));

            CreateMap<Photo, PhotoDetailsDto>();
        }
    }
}
