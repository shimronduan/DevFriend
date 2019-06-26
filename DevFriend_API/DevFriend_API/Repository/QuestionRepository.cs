using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private IMongoContext _context;
        public QuestionRepository(IMongoContext context) : base(context)
        {
            _context = context;
        }
    }
}
