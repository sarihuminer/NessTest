using AutoMapper;
using DataAccess;
using Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ISessionFactoryHelper _sessionFactoryHelper;
        private readonly IMapper _mapper;
        public RoleRepository(ISessionFactoryHelper sessionFactoryHelper, IMapper mapper)
        {
            this._mapper = mapper;
            this._sessionFactoryHelper = sessionFactoryHelper;
        }
        public List<Roles> getRoles()
        {
            List<Entities.Lookup.Role> roles = new List<Entities.Lookup.Role>();
            // Get the session
            ISession session = _sessionFactoryHelper.GetSession();
            // Load the order from the database
            ICriteria criteria = session.CreateCriteria(typeof(Entities.Lookup.Role));
            criteria.List(roles);
            List<Roles> list = _mapper.Map<List<Entities.Lookup.Role>, List<Roles>>(roles);
            return list;
        }
    }
}
