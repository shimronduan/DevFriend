using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Repository
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        private IMongoContext _context;
        public AnswerRepository(IMongoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAnswersByQuestionId(Guid id)
        {
            var list = (await _context.GetCollection<Answer>("Answer").FindAsync(m => m.QuestionId == id)).ToList();
            return list;
        }
    }
}
