using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UdemProject.Data
{
    public class Category
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        [MaxLength(100 , ErrorMessage = "Is my error msg for Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(0,100 , ErrorMessage ="Is my error msg for Display order")]
        public int DisplayOrder { get; set; }
    }
}