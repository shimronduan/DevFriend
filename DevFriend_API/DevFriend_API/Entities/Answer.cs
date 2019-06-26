using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Solution { get; set; }
        public int Vote { get; set; }

    }
}
