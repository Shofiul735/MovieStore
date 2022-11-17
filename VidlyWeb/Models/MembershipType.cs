using System.ComponentModel.DataAnnotations;

namespace VidlyWeb.Models
{
    public class MembershipType
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        public short SignupFee { get; set; }
        [Required]
        [StringLength(64)]
        public string MembershipTypeName { get; set; }
        [Required]
        [Range(0,12)]
        public byte DurationInMonths { get; set; }
        [Required]
        public byte DiscountRate { get; set; }
    }
}
