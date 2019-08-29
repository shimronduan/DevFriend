using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Repository
{
    public class TutorialRepository : BaseRepository<Tutorial>, ITutorialRepository
    {
        private IMongoContext _context;
        public TutorialRepository(IMongoContext context) : base(context)
        {
            _context = context;
        }
    }
}
