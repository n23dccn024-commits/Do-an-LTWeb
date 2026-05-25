using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Data;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor: Yêu cầu lấy kết nối Database (AppDbContext) đưa vào đây
        public HotelsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. API Lấy danh sách khách sạn (GET: api/Hotels)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        // 2. API Thêm một khách sạn mới (POST: api/Hotels)
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotels", new { id = hotel.Id }, hotel);
        }
    }
}