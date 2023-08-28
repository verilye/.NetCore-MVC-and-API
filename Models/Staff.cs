using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssignment.Models
{
    public class Staff
    {
        [Key]
        [Required(ErrorMessage = "Staff ID is required.")]
        [RegularExpression(@"^e\d{5}$", ErrorMessage = "Staff ID must start with 'e' followed by 5 digits.")]
        [MaxLength(6), MinLength(6)]
        public string StaffID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "First name should start with an uppercase letter and only contain letters.")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Last name should start with an uppercase letter and only contain letters.")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(320)]
        public string Email { get; set; }

        [RegularExpression(@"^04\d{8}$", ErrorMessage = "Mobile phone must start with '04' followed by 8 digits.")]
        [MaxLength(10)]
        public string? MobilePhone { get; set; }
        
        public virtual List<Booking> Bookings { get; set; }
    }
}
