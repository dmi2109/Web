using System.ComponentModel.DataAnnotations.Schema;

namespace KtraGK.Models
{
   public class ChiTietDangKy
{
    public int MaDK { get; set; }
    public string MaHP { get; set; }

    // Navigation properties (tuỳ chọn)
    public DangKy DangKy { get; set; }
    public HocPhan HocPhan { get; set; }
}

}
