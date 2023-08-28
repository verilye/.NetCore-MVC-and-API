using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers;

public class BookingController : Controller
{
    private readonly ILogger<BookingController> _logger;

    private readonly IHttpClientFactory _clientFactory;
    private HttpClient Client =>_clientFactory.CreateClient();

    public BookingController(ILogger<BookingController> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        //Call api with http service
        var response = await Client.GetAsync("api/bookings");

        if(!response.IsSuccessStatusCode)
            throw new Exception();

        var result = await response.Content.ReadAsStringAsync();

        List<Booking> bookings = JsonConvert.DeserializeObject<List<Booking>>(result);

        //Return results serialised to a list of objects
        return View(bookings);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}