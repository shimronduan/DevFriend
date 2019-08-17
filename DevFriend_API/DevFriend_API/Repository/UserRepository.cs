using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private IMongoContext _context;
        public UserRepository(IMongoContext context) : base(context)
        {
            _context = context;
        }
    }
}
