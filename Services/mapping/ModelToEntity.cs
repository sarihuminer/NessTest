using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dbo;
namespace Services.mapping
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<Models.Users, Users>();
        }


    }
}
