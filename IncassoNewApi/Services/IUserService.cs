using IncassoNewApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncassoNewApi.Services
{
    interface IUserService
    {
        Inc_User Authenticate(string username, string password);
        IEnumerable<Inc_User> GetAll();
    }
}
