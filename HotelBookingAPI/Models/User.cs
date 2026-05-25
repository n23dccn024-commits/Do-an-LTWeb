using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } // Dùng làm tài khoản đăng nhập

        [Required]
        public string PasswordHash { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Role { get; set; } // Sẽ lưu: "Admin" hoặc "HotelManager"

        public bool IsActive { get; set; } = true; // Dùng để khóa/mở tài khoản thay vì xóa hẳn
    }
}