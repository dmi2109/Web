using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KtraGK.Models
{
    [Table("DangKy")]
    public class DangKy
    {
        [Key]
        public int MaDK { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayDK { get; set; } = DateTime.Now;

        public string MaSV { get; set; }

        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }

        public List<ChiTietDangKy> ChiTietDangKys { get; set; }
    }
}
