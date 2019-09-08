using DevFriend_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAnswersByQuestionId(Guid id);
    }
}
