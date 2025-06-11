// Controllers/GioHangController.cs
using Microsoft.AspNetCore.Mvc;
using KtraGK.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KtraGK.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GioHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        private const string CART_KEY = "GioHang";

        public IActionResult GioHang()
        {
            var cart = GetCart();
            ViewBag.SoLuong = cart.Count;
            ViewBag.TongTinChi = cart.Sum(x => x.SoTinChi);
            return View(cart);
        }

        public IActionResult ThemVaoGio(string maHP)
        {
            var hp = _context.HocPhans.FirstOrDefault(h => h.MaHP == maHP);
            if (hp == null || hp.Soluong <= 0) return RedirectToAction("ListHP", "HocPhan");

            var cart = GetCart();
            if (!cart.Any(x => x.MaHP == maHP))
                cart.Add(hp);

            SaveCart(cart);
            return RedirectToAction("GioHang");
        }


        public IActionResult XoaKhoiGio(string maHP)
        {
            var cart = GetCart();
            var hp = cart.FirstOrDefault(x => x.MaHP == maHP);
            if (hp != null) cart.Remove(hp);
            SaveCart(cart);
            return RedirectToAction("GioHang");
        }

        public IActionResult XoaTatCa()
        {
            SaveCart(new List<HocPhan>());
            return RedirectToAction("GioHang");
        }

        public IActionResult DatHang()
        {
            var maSV = HttpContext.Session.GetString("MaSV");
            if (string.IsNullOrEmpty(maSV)) return RedirectToAction("DangNhap", "NguoiDung");

            var sv = _context.SinhViens.Include(s => s.NganhHoc).FirstOrDefault(s => s.MaSV == maSV);
            ViewBag.SinhVien = sv;
            ViewBag.GioHang = GetCart();
            ViewBag.TongTinChi = GetCart().Sum(hp => hp.SoTinChi);

            return View();
        }

        public IActionResult LuuDangKy()
        {
            var maSV = HttpContext.Session.GetString("MaSV");
            if (string.IsNullOrEmpty(maSV)) return RedirectToAction("DangNhap", "NguoiDung");

            var dk = new DangKy { MaSV = maSV, NgayDK = DateTime.Now };
            _context.DangKys.Add(dk);
            _context.SaveChanges();

            foreach (var hp in GetCart())
            {
                var ctdk = new ChiTietDangKy { MaDK = dk.MaDK, MaHP = hp.MaHP };
                _context.ChiTietDangKys.Add(ctdk);

                // Giảm số lượng dự kiến
                var hocPhanDb = _context.HocPhans.FirstOrDefault(h => h.MaHP == hp.MaHP);
                if (hocPhanDb != null && hocPhanDb.Soluong > 0)
                {
                    hocPhanDb.Soluong--;
                    _context.HocPhans.Update(hocPhanDb);
                }
            }


            _context.SaveChanges();
            XoaTatCa();
            return RedirectToAction("XacNhanDonHang");
        }

        public IActionResult XacNhanDonHang()
        {
            return View();
        }

        private List<HocPhan> GetCart()
        {
            var session = HttpContext.Session.GetString(CART_KEY);
            if (string.IsNullOrEmpty(session)) return new List<HocPhan>();
            return JsonSerializer.Deserialize<List<HocPhan>>(session);
        }

        private void SaveCart(List<HocPhan> cart)
        {
            HttpContext.Session.SetString(CART_KEY, JsonSerializer.Serialize(cart));
        }
    }
}