using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDatabase.BLOG.BLL.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
