using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssignment.Models;

public class Room{

    [Key]
    [Required]
    [RegularExpression(@"^\d{2}\.\d{2}\.\d{2}$")]
    [MaxLength(8),MinLength(8)]
    public string RoomID{get;set;}

    [Required]
    [Range(2,300, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Capacity{get;set;}

    [Required]
    [Column(TypeName = "bit")]
    public bool HasProjector{get;set;}
    public virtual List<Booking> Bookings{get;set;}

}