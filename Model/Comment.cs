using System;
using System.ComponentModel.DataAnnotations;

namespace VSBlog_Backend.Model
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Content { get; set; }

        public DateTime Time { get; set; }

        public int UpCount { get; set; } = 0;
        public int DownCount { get; set; } = 0;


        public int? UserId { get; set; }
        public int BlogId { get; set; }

        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
    }
}