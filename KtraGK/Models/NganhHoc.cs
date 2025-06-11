using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KtraGK.Models
{
    [Table("NganhHoc")]
    public class NganhHoc
    {
        [Key]
        public string MaNganh { get; set; }

        [Required]
        public string TenNganh { get; set; }

        public ICollection<SinhVien> SinhViens { get; set; }
    }
}
