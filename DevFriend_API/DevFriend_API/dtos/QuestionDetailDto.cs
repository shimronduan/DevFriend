using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFriend_API.Entities;

namespace DevFriend_API.dtos
{
    public class QuestionDetailDto
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Resolved { get; set; }
    }
}
