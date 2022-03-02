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

            //role
            CreateMap<Models.Roles, Role>();
            CreateMap<Models.Roles, Role>()
       .ForMember(opt => opt.Code, mod => mod.MapFrom(src => src.Code))
       .ForMember(opt => opt.Description, mod => mod.MapFrom(src => src.Description));

            //Organizationlevels
            CreateMap<Models.Organizationlevels, Organizationlevels>();
            CreateMap<Models.Organizationlevels, Organizationlevels>()
                 .ForMember(opt => opt.Id, mod => mod.MapFrom(src => src.Id))
                 .ForMember(opt => opt.ParentId, mod => mod.MapFrom(src => src.ParentId))
                 .ForMember(opt => opt.Name, mod => mod.MapFrom(src => src.Name))
       .ForMember(opt => opt.IsRowDeleted, mod => mod.MapFrom(src => src.IsRowDeleted));

            //users
            CreateMap<Models.Users, Users>();
            CreateMap<Models.Users, Users>()
       .ForMember(opt => opt.Id, mod => mod.MapFrom(src => src.Id))
       .ForMember(opt => opt.Username, mod => mod.MapFrom(src => src.Username))
       .ForPath(opt => opt.Role.Code, mod => mod.MapFrom(src => src.RoleCode))
       .ForPath(opt => opt.Role.Description, mod => mod.MapFrom(src => src.RoleDescribtion))
       .ForMember(opt => opt.Email, mod => mod.MapFrom(src => src.Email))
       .ForMember(opt => opt.Phone, mod => mod.MapFrom(src => src.Phone))
       .ForMember(opt => opt.Managerid, mod => mod.MapFrom(src => src.Managerid))
       .ForMember(opt => opt.Password, mod => mod.MapFrom(src => src.Password))
       .ForMember(opt => opt.Salt, mod => mod.MapFrom(src => src.Salt))
       .ForMember(opt => opt.IsTemporaryPassword, mod => mod.MapFrom(src => src.IsTemporaryPassword))
       .ForMember(opt => opt.IsActive, mod => mod.MapFrom(src => src.IsActive))
       .ForMember(opt => opt.CreateDate, mod => mod.MapFrom(src => src.CreateDate))
       .ForPath(opt => opt.Organizationlevels.Id, mod => mod.MapFrom(src => src.OrganizationlevelsId))
       .ForMember(opt => opt.LastUpdateDate, mod => mod.MapFrom(src => src.LastUpdateDate));



        }


    }
}
