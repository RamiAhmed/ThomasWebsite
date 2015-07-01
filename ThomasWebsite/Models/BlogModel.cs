using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ThomasWebsite.Models
{
    public class BlogModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [Required]
        [StringLength(64)]
        public string Author { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Contents { get; set; }

        [Required]
        public bool IsPublished { get; set; }
    }

    public class BlogContext : DbContext
    {
        public DbSet<BlogModel> Blogs { get; set; }

        public BlogContext()
            : base("DefaultConnection")
        {
        }
    }
}