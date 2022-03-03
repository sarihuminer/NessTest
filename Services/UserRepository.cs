using AutoMapper;
using DataAccess;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ISessionFactoryHelper _sessionFactoryHelper;
        private readonly IMapper _mapper;
        public UserRepository(ISessionFactoryHelper sessionFactoryHelper, IMapper mapper)
        {
            this._mapper = mapper;
            this._sessionFactoryHelper = sessionFactoryHelper;
        }
        public List<Models.Users> getUsers()
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
        public List<Models.Users> getUsers(int role, string name)
        {
            List<Entities.Dbo.Users> users = new List<Entities.Dbo.Users>();

            // Get the session
            ISession session = _sessionFactoryHelper.GetSession();
            // Load the order from the database
              IQuery query = session.CreateQuery("from Users where Username= '" + name + "'");
            try
            {
                //IQuery query = session.CreateQuery("select u from Users as u,INNER JOIN OrganizationLevels as o" +
                //    "on u.OrganizationLevelID=o.ID where u.Username= '" + name + "' and o.ID='"+role+"'");

                //IQuery query = session.CreateQuery("from Users where Username= '"+name+ "' Role.Code='" + role+"'");
                users = query.List<Entities.Dbo.Users>() as List<Entities.Dbo.Users>;
                List<Models.Users> list = _mapper.Map<List<Entities.Dbo.Users>, List<Models.Users>>(users);
                return list;
            }
            catch (Exception e)
            {

                return null;
            }
           
        }
        public Models.Users getUser(string id)
        {
            Entities.Dbo.Users user = new Entities.Dbo.Users();

            // Get the session
            ISession session = _sessionFactoryHelper.GetSession();
            // Load the order from the database
            IQuery query = session.CreateQuery("from Users where Id= '" + id + "'");
            //IQuery query = session.CreateQuery("from Users where Username= '"+name+ "' Role.Code='" + role+"'");
            user = query.UniqueResult<Entities.Dbo.Users>();
            Models.Users userM = _mapper.Map<Entities.Dbo.Users, Models.Users>(user);
            return userM;
        }
        public bool createUser(Models.Users user)
        {

            // Get the session
            ISession session = _sessionFactoryHelper.GetSession();

            using (session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Entities.Dbo.Users userD = _mapper.Map<Models.Users, Entities.Dbo.Users>(user);

                        userD.Password = "123456";
                        userD.Salt = "";
                        userD.IsTemporaryPassword = true;
                        userD.CreateDate = DateTime.Now;
                        userD.LastUpdateDate= DateTime.Now;

                        //relation ship 
                        userD.Organizationlevels.Name = "";
                        userD.Organizationlevels.IsRowDeleted = false;
                        Entities.Dbo.Users userS = session.Load<Entities.Dbo.Users>(userD.Id);

                        if (userS.Id == userD.Id)
                            session.Evict(userS);
                        session.SaveOrUpdate(userD);
                        //Thread.Sleep(1000);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        //public bool createUser(Models.Users user)
        //{

        //    // Get the session
        //    ISession session = _sessionFactoryHelper.GetSession();
        //    // Load the order from the database
        //    var q = session.CreateSQLQuery("insert into Users(ID,OrganizationlevelsID," +
        //        "UserName,RoleCode,Email,Phone,Managerid,Password,Salt,IsTemporaryPassword," +
        //        "IsActive,CreateDate,LastUpdateDate)" +
        //        " values(:Id," +
        //        " :OrganizationlevelsID,:UserName,:RoleCode,:Email,:Phone," +
        //        ":Managerid,:Password,:Salt,:IsTemporaryPassword,:IsActive,:CreateDate,:LastUpdateDate)");
        //    q.SetParameter("Id", user.Id);
        //    q.SetParameter("OrganizationlevelsID", user.OrganizationlevelsId);
        //    q.SetParameter("UserName", user.Username);
        //    q.SetParameter("RoleCode", user.RoleCode);
        //    q.SetParameter("Email", user.Email);
        //    q.SetParameter("Phone", user.Phone);
        //    q.SetParameter("Managerid", user.Managerid);
        //    q.SetParameter("Password", user.Password);
        //    q.SetParameter("Salt", user.Salt);
        //    q.SetParameter("IsTemporaryPassword", user.IsTemporaryPassword);
        //    q.SetParameter("IsActive", user.IsActive);
        //    q.SetParameter("CreateDate", user.CreateDate);
        //    q.SetParameter("LastUpdateDate", user.LastUpdateDate);
        //    int d = q.ExecuteUpdate();
        //    if (d > 0)
        //        return true;
        //    return false;
        //}
    }
}
