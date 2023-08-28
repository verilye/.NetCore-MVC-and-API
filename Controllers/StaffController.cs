using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalAssignment.Models;
using FinalAssignment.Data;

namespace FinalAssignment.Controllers;

public class StaffController : Controller
{
    private readonly ILogger<StaffController> _logger;
    private readonly RoomBookingContext _context;

    public StaffController(ILogger<StaffController> logger, RoomBookingContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {

        // Get list of staff and return it to the view 

        List<Staff> staff = _context.Staff.ToList();

        return View(staff);
    }

    // GET
    public IActionResult Create()
    {
        return View();
    }


    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StaffID, FirstName, LastName, Email, MobilePhone")] Staff staff)
    {

        if (_context.Staff.Any(s => s.StaffID == staff.StaffID))
        {
            ModelState.AddModelError("StaffID", "Staff ID already exists in the database.");
        }

        if (!ModelState.IsValid)
        {
            return View(staff);
        }

        _context.Add(staff);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}