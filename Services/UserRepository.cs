using AutoMapper;
using DataAccess;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserRepository:IUserRepository
    {
        private readonly ISessionFactoryHelper _sessionFactoryHelper;
        private readonly IMapper _mapper;
        public UserRepository(ISessionFactoryHelper sessionFactoryHelper, IMapper mapper)
        {
            this._mapper = mapper;
            this._sessionFactoryHelper = sessionFactoryHelper;
        }
        public  List<Models.Users> getProductOrdersForCustomer()
        {
            List<Entities.Dbo.Users> users = new List<Entities.Dbo.Users>();

            // Get the session
            ISession session = _sessionFactoryHelper.GetSession();

            // Load the order from the database
            ICriteria criteria = session.CreateCriteria(typeof(Entities.Dbo.Users));
            criteria.List(users);


            List<Models.Users> list = _mapper.Map<List<Entities.Dbo.Users>, List<Models.Users>>(users);
            return list;
        }
    }
}
