using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDatabase.BLOG.BLL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
