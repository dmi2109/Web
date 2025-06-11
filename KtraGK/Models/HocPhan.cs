using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KtraGK.Models
{
    [Table("HocPhan")] // đúng tên bảng trong SQL
    public class HocPhan
    {
        [Key]
        public string MaHP { get; set; }

        [Required]
        public string TenHP { get; set; }

        [Display(Name = "Số Tín Chỉ")]
        public int SoTinChi { get; set; }
        public int Soluong { get; set; } 
    }
}
