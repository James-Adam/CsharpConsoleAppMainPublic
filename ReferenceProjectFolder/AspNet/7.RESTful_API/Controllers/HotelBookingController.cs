using _7.RESTful_API.Data;
using _7.RESTful_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace _7.RESTful_API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HotelBookingController : ControllerBase
{
    private readonly ApiContext _context;

    public HotelBookingController(ApiContext context)
    {
        _context = context;
    }

    // Create/Edit
    [HttpPost]
    public JsonResult CreateEdit(HotelBooking booking)
    {
        if (booking.Id == 0)
        {
            _ = _context.Bookings.Add(booking);
        }
        else
        {
            HotelBooking? bookingInDb = _context.Bookings.Find(booking.Id);

            if (bookingInDb == null)
            {
                return new JsonResult(NotFound());
            }
        }

        _ = _context.SaveChanges();

        return new JsonResult(Ok(booking));
    }

    // Get
    [HttpGet]
    public JsonResult Get(int id)
    {
        HotelBooking? result = _context.Bookings.Find(id);

        return result == null ? new JsonResult(NotFound()) : new JsonResult(Ok(result));
    }

    // Delete
    [HttpDelete]
    public JsonResult Delete(int id)
    {
        HotelBooking? result = _context.Bookings.Find(id);

        if (result == null)
        {
            return new JsonResult(NotFound());
        }

        _ = _context.Bookings.Remove(result);
        _ = _context.SaveChanges();

        return new JsonResult(NoContent());
    }

    // Get all
    [HttpGet]
    public JsonResult GetAll()
    {
        List<HotelBooking> result = _context.Bookings.ToList();

        return new JsonResult(Ok(result));
    }
}