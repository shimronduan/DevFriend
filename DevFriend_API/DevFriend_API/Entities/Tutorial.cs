﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.Entities
{
    public class Tutorial
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string tutorialUrl { get; set; }
        public string iconUrl { get; set; }
        public string description { get; set; }
        public ICollection<Tag> tags { get; set; }
        public Guid UserId { get; set; }

    }
    
}
