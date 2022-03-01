using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public interface IUserRepository
    {
        List<Models.Users> getCustomers();
        List<Models.Users> getCustomers(int role,string name);
    }
}
