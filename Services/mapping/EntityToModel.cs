using AutoMapper;
using Entities.Dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.mapping
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Users, Models.Users>();
            CreateMap<Users, Models.Users>()
       .ForMember(opt => opt.Id, mod => mod.MapFrom(src => src.Id))
       .ForMember(opt => opt.Username, mod => mod.MapFrom(src => src.Username))
       .ForMember(opt => opt.Email, mod => mod.MapFrom(src => src.Email))
       .ForMember(opt => opt.Phone, mod => mod.MapFrom(src => src.Phone))
       .ForMember(opt => opt.Managerid, mod => mod.MapFrom(src => src.Managerid))
       .ForMember(opt => opt.Password, mod => mod.MapFrom(src => src.Password))
       .ForMember(opt => opt.Salt, mod => mod.MapFrom(src => src.Salt))
       .ForMember(opt => opt.IsTemporaryPassword, mod => mod.MapFrom(src => src.IsTemporaryPassword))
       .ForMember(opt => opt.IsActive, mod => mod.MapFrom(src => src.IsActive))
       .ForMember(opt => opt.CreateDate, mod => mod.MapFrom(src => src.CreateDate))
       .ForMember(opt => opt.OrganizationlevelsId, mod => mod.MapFrom(src => src.Organizationlevels))
       .ForMember(opt => opt.LastUpdateDate, mod => mod.MapFrom(src => src.LastUpdateDate));

        }
    }
}
