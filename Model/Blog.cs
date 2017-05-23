using System.ComponentModel.DataAnnotations;

namespace VSBlog_Backend.Model
{
    public class Blog
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(40)]
        public string Title { get; set; }
        
        public string Content { get; set; }

        public int ReadCount { get; set; } = 0;
        
        public int ReadCount1 { get; set; }

        public bool Draft { get; set; } = true;
    }
}