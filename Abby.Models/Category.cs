using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1,1010,ErrorMessage = "The number have to be between 1-100")]
        public int DisplayOrder { get; set; }
        
    }
}
