﻿using DevFriend_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.dtos
{
    public class QuestionListDto
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Resolved { get; set; }
    }
}
