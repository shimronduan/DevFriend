using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private IMongoContext _context;
        public TagRepository(IMongoContext context) : base(context)
        {
            _context = context;
        }
    }
}
