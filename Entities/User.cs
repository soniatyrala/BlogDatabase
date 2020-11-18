using System.Collections.Generic;

namespace BlogDatabase.Entities
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
