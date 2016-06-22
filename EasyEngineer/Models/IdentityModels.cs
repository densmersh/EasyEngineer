using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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
        [MaxLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Как это работает?")]
        [MaxLength(10000, ErrorMessage = "Описание должно быть меньше 10000 символов")]
        public string Text { get; set; }

        public string Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Date_pub { get; set; }
        [Required]
        [Display(Name = "Теги")]
        [MaxLength(20, ErrorMessage = "Тег должен состоять не более чем из 20 символов")]
        public string Tag { get; set; }
        public int Likes { get; set; }
        public News()
        {
            NewsCommentss = new List<NewsComments>();
         }
        public virtual ICollection<NewsComments> NewsCommentss { get; set; }

    }

    public class NewsComments
    {
        [Key]
        public int NewsCommentId { get; set; }
        [Required]
        [Display(Name = "Добавить комментарий")]
        [MaxLength(100, ErrorMessage = "Слишком длинный комментарий")]
        public string Text { get; set; }

        public string Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DatePub { get; set; }
        public int Likes { get; set; }
        public int NewsId { get; set; }
        [ForeignKey("NewsId")]
        public virtual News News { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<News> Newss { get; set; }
        public DbSet<NewsComments> NewsCommentss { get; set; }
    }
}