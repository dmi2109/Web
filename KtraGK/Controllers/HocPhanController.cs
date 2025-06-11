using Microsoft.AspNetCore.Mvc;
using KtraGK.Models;
using KtraGK.Repositories;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KtraGK.Controllers
{
    public class HocPhanController : Controller
    {
        private readonly IHocPhanRepository _hocPhanRepo;
        //private readonly IDangKyRepository _dangKyRepo;

        public HocPhanController(IHocPhanRepository hocPhanRepo)
        {
            _hocPhanRepo = hocPhanRepo;
            //_dangKyRepo = dangKyRepo;
        }

        // Hiển thị danh sách học phần
        public async Task<IActionResult> ListHP()
        {
            var maSV = HttpContext.Session.GetString("MaSV");
            if (maSV == null)
                return RedirectToAction("DangNhap", "NguoiDung");

            var hocPhans = await _hocPhanRepo.GetAllAsync();
            return View(hocPhans);
        }

        // // Đăng ký học phần
        // [HttpPost]
        // public async Task<IActionResult> DangKy(string maHP)
        // {
        //     var maSV = HttpContext.Session.GetString("MaSV");
        //     if (maSV == null)
        //         return RedirectToAction("DangNhap", "NguoiDung");

        //     await _dangKyRepo.AddAsync(maSV, maHP);
        //     return RedirectToAction("ListHP");
        // }
    }
}
