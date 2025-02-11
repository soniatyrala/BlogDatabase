﻿
namespace BlogDatabase.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
