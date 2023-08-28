using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.Models;


[PrimaryKey(nameof(RoomID), nameof(StaffID))]
public class Booking{

    // Composite Primary Key
    [Key]
    [Required]
    public string RoomID{get;set;}

    // Composite Primary Key
    [Required]
    [DataType(DataType.Date)]
    public DateTime BookingDate{get;set;}

    [Required]
    public string StaffID{get;set;}

    public Room Room {get;set;}
    public Staff Staff{get;set;}


}