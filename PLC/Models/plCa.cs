using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plc.Models
{
    public class plCa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên cá là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên cá không được vượt quá 100 ký tự.")]
        [Display(Name = "Tên Cá")]
        public string TenCa { get; set; }

        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [Range(0, 5, ErrorMessage = "Đánh giá phải từ 0 đến 5.")]
        [Display(Name = "Đánh Giá")]
        public double DanhGia { get; set; }

        [Required(ErrorMessage = "Loại nước là bắt buộc.")]
        [Display(Name = "Loại Nước")]
        public string LoaiNuoc { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Kích thước phải lớn hơn 0.")]
        [Display(Name = "Kích Thước (cm)")]
        public double KichThuoc { get; set; }

        [Display(Name = "Màu Sắc")]
        public string MauSac { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Thời gian sống phải lớn hơn 0.")]
        [Display(Name = "Thời Gian Sống (năm)")]
        public int ThoiGianSinhTon { get; set; }

        // 🌟 Lưu URL của hình ảnh thay vì lưu dữ liệu ảnh trực tiếp
        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
    }
}
