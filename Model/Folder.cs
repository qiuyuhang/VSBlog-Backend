using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace VSBlog_Backend.Model
{
    public class Folder
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public ICollection 
    }
}