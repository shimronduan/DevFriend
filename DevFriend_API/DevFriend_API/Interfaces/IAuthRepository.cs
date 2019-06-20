using DevFriend_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Interfaces
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<User> GetUserByName(string name);
    }
}
