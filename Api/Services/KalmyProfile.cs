using Api.Data.Dto;
using Api.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class KalmyProfile: Profile
    {
        public KalmyProfile()
        {
            CreateMap<Car, CarDto>()
                .ReverseMap();


        }
    }
}
