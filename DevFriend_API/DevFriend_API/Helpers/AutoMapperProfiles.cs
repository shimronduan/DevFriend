using AutoMapper;
using DevFriend_API.dtos;
using DevFriend_API.dtos.TutorialDtos;
using DevFriend_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(src => Extensions.CalculateAge(src.DateOfBirth));
                });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(src => Extensions.CalculateAge(src.DateOfBirth));
                });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<AddQuestionDto, Question>();
            CreateMap<Question, AddQuestionDto>();
            CreateMap<Question, QuestionDetailDto>();
            CreateMap<UploadTutorialDto, Tutorial>();
            CreateMap<Tutorial, UploadTutorialDto>();


            //CreateMap<Photo, PhotoForReturnDto>();
            //CreateMap<PhotosForCreationDto, Photo>();

        }


    }
}
