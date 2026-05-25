using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Kích hoạt Controller và Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// 1.5. KÍCH HOẠT CORS (Mở cửa cho ReactJS gọi vào)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Cho phép mọi tên miền (localhost:5173, ...)
              .AllowAnyMethod()  // Cho phép mọi hành động (GET, POST, PUT, DELETE)
              .AllowAnyHeader(); // Cho phép mọi header
    });
});

// 2. Kích hoạt kết nối SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3. Hiển thị giao diện Swagger trên trình duyệt
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4. SỬ DỤNG CORS (Lưu ý: Phải đặt TRƯỚC UseAuthorization)
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();