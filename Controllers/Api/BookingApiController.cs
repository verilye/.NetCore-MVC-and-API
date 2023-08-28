using Microsoft.AspNetCore.Mvc;
using FinalAssignment.Models;
using FinalAssignment.Data;

[ApiController]
[Route("api/bookings")]

public class BookingApiController : ControllerBase{
    private readonly RoomBookingContext _context;

    public BookingApiController (RoomBookingContext context){
        _context = context;
    }

    // GET: api/bookings
    [HttpGet]
    public IEnumerable<Booking> Get(){

        return _context.Bookings.ToList();

    }
}