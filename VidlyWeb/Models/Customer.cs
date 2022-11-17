using System.ComponentModel.DataAnnotations;

namespace VidlyWeb.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty and length can't be more than 64")]
        [StringLength(64)]
        public string Name { get; set; }
        [Display(Name="Subscribe to our newsletters")]
        public bool IsSubscribeToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name="Birthdate")]
        public DateTime? BirthDate { get; set; }

    }
}
