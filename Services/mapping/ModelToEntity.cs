using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dbo;
using Entities.Lookup;

namespace Services.mapping
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<Models.Users, Users>();
            CreateMap<Models.Roles,Role >();
            CreateMap<Models.Users,Users >()
       .ForMember(opt => opt.Id, mod => mod.MapFrom(src => src.Id))
       .ForMember(opt => opt.Username, mod => mod.MapFrom(src => src.Username))
       .ForMember(opt => opt.Role, mod => mod.MapFrom(src => src.RoleCode))
       .ForMember(opt => opt.Email, mod => mod.MapFrom(src => src.Email))
       .ForMember(opt => opt.Phone, mod => mod.MapFrom(src => src.Phone))
       .ForMember(opt => opt.Managerid, mod => mod.MapFrom(src => src.Managerid))
       .ForMember(opt => opt.Password, mod => mod.MapFrom(src => src.Password))
       .ForMember(opt => opt.Salt, mod => mod.MapFrom(src => src.Salt))
       .ForMember(opt => opt.IsTemporaryPassword, mod => mod.MapFrom(src => src.IsTemporaryPassword))
       .ForMember(opt => opt.IsActive, mod => mod.MapFrom(src => src.IsActive))
       .ForMember(opt => opt.CreateDate, mod => mod.MapFrom(src => src.CreateDate))
       .ForMember(opt => opt.Organizationlevels, mod => mod.MapFrom(src => src.OrganizationlevelsId))
       .ForMember(opt => opt.LastUpdateDate, mod => mod.MapFrom(src => src.LastUpdateDate));

            //roles

            CreateMap<Models.Roles,Role>();
            CreateMap< Models.Roles,Role>()
       .ForMember(opt => opt.Code, mod => mod.MapFrom(src => src.Code))
       .ForMember(opt => opt.Description, mod => mod.MapFrom(src => src.Description));
        }


    }
}
