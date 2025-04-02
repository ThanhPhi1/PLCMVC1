using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PLC.Data; // Giả sử DbContext của bạn nằm trong namespace plc.Data
using PLC.Data;
using System;
using System.Linq;

namespace plc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PLCContext( // Thay MVCBooksContext bằng plcContext
                serviceProvider.GetRequiredService<
                    DbContextOptions<PLCContext>>())) // Thay MVCBooksContext bằng plcContext
            {
                // Kiểm tra thông tin cá đã tồn tại hay chưa
                if (context.plCa.Any())
                {
                    return;   // Không thêm nếu cá đã tồn tại trong DB
                }

                context.plCa.AddRange(
                    new plCa
                    {
                        TenCa = "Cá Betta",
                        MoTa = "Loài cá cảnh phổ biến với nhiều màu sắc sặc sỡ.",
                        DanhGia = 4.5,
                        LoaiNuoc = "Nước ngọt",
                        KichThuoc = 6.0,
                        MauSac = "Đỏ, xanh, vàng, tím...",
                        ThoiGianSinhTon = 3
                    },
                    new plCa
                    {
                        TenCa = "Cá Vàng",
                        MoTa = "Loài cá vàng quen thuộc, dễ nuôi.",
                        DanhGia = 4.0,
                        LoaiNuoc = "Nước ngọt",
                        KichThuoc = 10.0,
                        MauSac = "Vàng, cam, trắng...",
                        ThoiGianSinhTon = 5
                    },
                    new plCa
                    {
                        TenCa = "Cá Nemo",
                        MoTa = "Loài cá hề nổi tiếng trong phim hoạt hình.",
                        DanhGia = 4.8,
                        LoaiNuoc = "Nước mặn",
                        KichThuoc = 8.0,
                        MauSac = "Cam, trắng, đen...",
                        ThoiGianSinhTon = 6
                    }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}