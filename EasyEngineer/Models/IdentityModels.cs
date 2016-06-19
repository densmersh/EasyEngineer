using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace EasyEngineer.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class News
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название топика")]
        [MaxLength(50, ErrorMessage = "Название слишком длинное")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Как это работает?")]
        [MaxLength(10000, ErrorMessage = "Краткость - сестра таланта!")]
        public string Text { get; set; }

        public string Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Date_pub { get; set; }
        [Required]
        [Display(Name = "Теги")]
        [MaxLength(10, ErrorMessage = "Краткость - сестра таланта!")]

        public int Like { get; set; }
        public int Dislike { get; set; }
        public string Tag { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<News> Newss { get; set; }
    }
}