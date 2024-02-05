using System.ComponentModel.DataAnnotations;

namespace LibraryIMS.Models
{
    public class Magazine
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Publishar { get; set; }
       

    }
}
