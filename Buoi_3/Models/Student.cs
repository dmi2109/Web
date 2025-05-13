using System.ComponentModel.DataAnnotations;

namespace BT3.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Vui lòng nhập Mã số sinh viên")]
        [Display(Name = "Mã số sinh viên")]
        public string? MSSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ tên")]
        [Display(Name = "Họ tên")]
        public string? HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Điểm trung bình")]
        [Display(Name = "Điểm Trung bình")]
        [Range(0, 10, ErrorMessage = "Điểm trung bình phải từ 0 đến 10")]
        public double DiemTB { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Chuyên ngành")]
        [Display(Name = "Chuyên ngành")]
        public string? ChuyenNganh { get; set; }
    }
}
