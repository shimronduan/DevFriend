using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.dtos
{
    public class AnswerListDto
    {
        public Guid Id { get; set; }
        public string Solution { get; set; }
        public int Vote { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}
