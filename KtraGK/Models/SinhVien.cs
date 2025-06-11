using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace KtraGK.Models
{
    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; }

        [Required]
        public string HoTen { get; set; }

        public string GioiTinh { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        // ✅ Không required vì tự động lưu từ ảnh upload
        public string? Hinh { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public string MaNganh { get; set; }

        // ✅ Không bắt buộc binding
        [ForeignKey("MaNganh")]
        [BindNever] // <--- Thêm dòng này
        public NganhHoc? NganhHoc { get; set; }
    }
}
