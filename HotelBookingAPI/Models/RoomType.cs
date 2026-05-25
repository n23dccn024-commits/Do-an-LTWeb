using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } // VD: Phòng Standard, Deluxe, Suite

        [Required]
        public decimal Price { get; set; } // Phục vụ filter: Tìm theo khoảng giá

        // --- Các thông tin chi tiết theo yêu cầu (b) ---
        public string BedType { get; set; } // VD: 1 Giường đôi, 2 Giường đơn
        public string RoomView { get; set; } // Hướng phòng: Hướng biển, hướng phố
        public bool HasBathtub { get; set; } // Bồn tắm
        public string Amenities { get; set; } // Các tiện ích khác (Wifi, Tivi...)
        public string ImageUrl { get; set; } // Đường dẫn hình ảnh

        // 1 Loại phòng có nhiều phòng vật lý và nhiều đơn đặt phòng
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}