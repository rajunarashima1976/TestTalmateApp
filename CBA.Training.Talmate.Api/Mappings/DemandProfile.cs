using AutoMapper;
using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Api.Mappings
{
    public class DemandProfile : Profile
    {
        public DemandProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Demand, DemandDTO>();
        }
    }
}
