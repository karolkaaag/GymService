using AutoMapper;
using GymService.Core.Entities;
using GymService.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymService.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            }).CreateMapper();
    }
}
