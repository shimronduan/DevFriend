using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Repository
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        private IMongoContext _context;
        public AuthRepository(IMongoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByName(string name)
        {
            try
            {
                var obj = await _context.GetCollection<User>("User").Find(m => m.Username == name).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
