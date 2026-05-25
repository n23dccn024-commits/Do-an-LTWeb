using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Kích hoạt Controller và Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

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

app.UseAuthorization();
app.MapControllers();
app.Run();