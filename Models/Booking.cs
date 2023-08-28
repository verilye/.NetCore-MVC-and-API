using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.Models;


[PrimaryKey(nameof(RoomID), nameof(StaffID))]
public class Booking{

    // Composite Primary Key
    [Key]
    [Required(ErrorMessage = "Room ID is required.")]
    public string RoomID{get;set;}
    
    // Composite Primary Key
    [Key]
    [Required(ErrorMessage = "Booking date is required.")]
    [DataType(DataType.Date)]
    public DateTime BookingDate{get;set;}

    
    [Required(ErrorMessage = "Staff ID is required.")]
    public string StaffID{get;set;}

    public virtual Room Room {get;set;}

    public virtual Staff Staff{get;set;}


}