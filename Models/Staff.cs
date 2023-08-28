using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssignment.Models;

public class Staff{

    [Key]
    [Required]
    [RegularExpression(@"^e\d{5}$")]
    [MaxLength(6),MinLength(6)]
    public string StaffID {get;set;}

    [Required]
    [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
    [MaxLength(30)]
    public string FirstName{get;set;}

    [Required]
    [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
    [MaxLength(30)]
    public string LastName{get;set;}

    [Required]
    [EmailAddress]
    [MaxLength(320)]
    public string Email{get;set;}

    [RegularExpression(@"^04\d{8}$")]
    [MaxLength(10)]
    public string MobilePhone{get;set;}

    public virtual List<Booking> Bookings{get;set;}

}