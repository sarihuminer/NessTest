using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserRepository
    {
        List<Models.Users> getUsers();
        List<Models.Users> getUsers(int role, string name);
        Models.Users getUser(string id);
        bool createUser(Models.Users user);

    }
}
