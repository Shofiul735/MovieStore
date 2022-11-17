using System.ComponentModel.DataAnnotations;

namespace VidlyWeb.Models
{
    public class Genre
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
    }
}
