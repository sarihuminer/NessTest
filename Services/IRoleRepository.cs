using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IRoleRepository
    {
        List<Models.Roles> getRoles();
    }
}
