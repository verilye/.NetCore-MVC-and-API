using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalAssignment.Models;
using FinalAssignment.Data;

namespace FinalAssignment.Controllers;

public class RoomController : Controller
{
    private readonly ILogger<RoomController> _logger;
    private readonly RoomBookingContext _context;

    public RoomController(ILogger<RoomController> logger, RoomBookingContext context)
    {
        _logger = logger;
        _context = context;
    }


    // GET
    public IActionResult Book()
    {
        // Return list of Rooms and Staff
        RoomBookingModel model = new RoomBookingModel();
        model.Rooms = _context.Rooms.ToList();
        model.Staff = _context.Staff.ToList();

        return View(model);
    }


    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Book([FromForm] Booking booking)
    {

        ModelState.Remove("booking.Room");
        ModelState.Remove("booking.Staff");

        booking.Room = _context.Rooms.Find(booking.RoomID);
        booking.Staff = _context.Staff.Find(booking.StaffID);

        var existingBooking = _context.Bookings
            .FirstOrDefault(b => b.RoomID == booking.RoomID && b.BookingDate == booking.BookingDate);

        if (existingBooking != null)
        {
            ModelState.AddModelError("booking.BookingDate", "This room is already booked on this day!");
            var roomBookingModel = new RoomBookingModel
            {
                Staff = _context.Staff.ToList(),
                Rooms = _context.Rooms.ToList(),
                Booking = booking
            };

            return View(roomBookingModel);
        }

        if (!ModelState.IsValid)
        {
            var roomBookingModel = new RoomBookingModel
            {
                Staff = _context.Staff.ToList(),
                Rooms = _context.Rooms.ToList(),
                Booking = booking
            };

            return View(roomBookingModel);
        }

        _context.Add(booking);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Staff");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
