﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDatabase.BLOG.BLL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
