using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string City { get; set; } // Phục vụ filter: Tìm kiếm theo thành phố

        [Required]
        public string Address { get; set; }

        public string Description { get; set; }

        // 1 Khách sạn có nhiều loại phòng
        public ICollection<RoomType> RoomTypes { get; set; }
    }
}