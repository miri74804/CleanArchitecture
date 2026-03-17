using AutoMapper;
using clean.Core.DTOs;
using clean.Core.Entities;
using clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();

            CreateMap<TaskItem, TaskDto>().ReverseMap();
            CreateMap<TaskItem, TaskDetailsDto>().ReverseMap();

            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<UserProfile, ProfileDetailsDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();    
            CreateMap<Category,  CategoryDetailsDto>().ReverseMap();
        }
    }
}
