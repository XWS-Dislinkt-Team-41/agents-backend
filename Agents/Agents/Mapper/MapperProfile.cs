﻿using Agents.DTO;
using Agents.Model;
using AutoMapper;

namespace Agents.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
