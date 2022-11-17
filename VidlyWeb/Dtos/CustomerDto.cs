using System.ComponentModel.DataAnnotations;
using VidlyWeb.Models;

namespace VidlyWeb.Dtos
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty and length can't be more than 64")]
        [StringLength(64)]
        public string Name { get; set; }
        [Display(Name = "Subscribe to our newsletters")]
        public bool IsSubscribeToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
