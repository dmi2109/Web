using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KtraGK.Models;
using KtraGK.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace KtraGK.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ISinhVienRepository _sinhVienRepo;
        private readonly INganhHocRepository _nganhHocRepo;

        public SinhVienController(ISinhVienRepository sinhVienRepo, INganhHocRepository nganhHocRepo)
        {
            _sinhVienRepo = sinhVienRepo;
            _nganhHocRepo = nganhHocRepo;
        }

        public async Task<IActionResult> Index()
        {
            var sinhViens = await _sinhVienRepo.GetAllAsync();
            return View(sinhViens);
        }

        public async Task<IActionResult> Details(string id)
        {
            var sv = await _sinhVienRepo.GetByIdAsync(id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.NganhList = new SelectList(await _nganhHocRepo.GetAllAsync(), "MaNganh", "TenNganh");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SinhVien sv, IFormFile UploadedImage)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(e => e.Errors))
                {
                    Console.WriteLine("⚠️ Model error: " + error.ErrorMessage);
                }

                ViewBag.NganhList = new SelectList(await _nganhHocRepo.GetAllAsync(), "MaNganh", "TenNganh", sv.MaNganh);
                return View(sv);
            }

            if (UploadedImage != null)
            {
                sv.Hinh = await SaveImage(UploadedImage);
            }

            await _sinhVienRepo.AddAsync(sv);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var sv = await _sinhVienRepo.GetByIdAsync(id);
            if (sv == null) return NotFound();

            ViewBag.NganhList = new SelectList(await _nganhHocRepo.GetAllAsync(), "MaNganh", "TenNganh", sv.MaNganh);
            return View(sv);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, SinhVien sv, IFormFile? UploadedImage)
        {
            if (id != sv.MaSV) return NotFound();

            // Không ràng buộc UploadedImage trong model => kiểm tra model sinh viên thôi
            if (!ModelState.IsValid)
            {
                ViewBag.NganhList = new SelectList(await _nganhHocRepo.GetAllAsync(), "MaNganh", "TenNganh", sv.MaNganh);
                return View(sv);
            }

            var existingSv = await _sinhVienRepo.GetByIdAsync(id);
            if (existingSv == null) return NotFound();

            // Cập nhật thông tin
            existingSv.HoTen = sv.HoTen;
            existingSv.GioiTinh = sv.GioiTinh;
            existingSv.NgaySinh = sv.NgaySinh;
            existingSv.MaNganh = sv.MaNganh;

            // ❗ Chỉ cập nhật ảnh nếu có file mới
            if (UploadedImage != null && UploadedImage.Length > 0)
            {
                existingSv.Hinh = await SaveImage(UploadedImage);
            }

            await _sinhVienRepo.UpdateAsync(existingSv);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(string id)
        {
            var sv = await _sinhVienRepo.GetByIdAsync(id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, IFormCollection _)
        {
            await _sinhVienRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "images");
            Directory.CreateDirectory(folderPath);

            var fileName = Path.GetFileName(file.FileName);
            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/Content/images/" + fileName;
        }
    }
}
