using Microsoft.AspNetCore.Mvc;
using KtraGK.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KtraGK.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly ISinhVienRepository _sinhVienRepo;

        public NguoiDungController(ISinhVienRepository sinhVienRepo)
        {
            _sinhVienRepo = sinhVienRepo;
        }

        // GET
        public IActionResult DangNhap()
        {
            return View();
        }

        // POST: /NguoiDung/DangNhap
        [HttpPost]
        public async Task<IActionResult> DangNhap(string maSV)
        {
            if (string.IsNullOrEmpty(maSV))
            {
                ModelState.AddModelError(string.Empty, "Vui lòng nhập mã sinh viên");
                return View();
            }

            var sv = await _sinhVienRepo.GetByIdAsync(maSV);
            if (sv == null)
            {
                ModelState.AddModelError(string.Empty, "Mã sinh viên không tồn tại");
                return View();
            }

            HttpContext.Session.SetString("MaSV", sv.MaSV);
            HttpContext.Session.SetString("HoTen", sv.HoTen);

            return RedirectToAction("Index", "SinhVien");
        }

        // POST: /NguoiDung/DangXuat
        [HttpPost]
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}
