using Microsoft.EntityFrameworkCore;

namespace KtraGK.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<NganhHoc> NganhHocs { get; set; }
        public DbSet<HocPhan> HocPhans { get; set; }
        public DbSet<DangKy> DangKys { get; set; }
        public DbSet<ChiTietDangKy> ChiTietDangKys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đảm bảo EF dùng đúng tên bảng
            modelBuilder.Entity<SinhVien>().ToTable("SinhVien");
            modelBuilder.Entity<NganhHoc>().ToTable("NganhHoc");
            modelBuilder.Entity<HocPhan>().ToTable("HocPhan");
            modelBuilder.Entity<DangKy>().ToTable("DangKy");

            modelBuilder.Entity<ChiTietDangKy>()
                .ToTable("ChiTietDangKy") // ✅ sửa tên bảng
                .HasKey(ct => new { ct.MaDK, ct.MaHP }); // Composite key

            modelBuilder.Entity<ChiTietDangKy>()
                .HasOne(ct => ct.DangKy)
                .WithMany(d => d.ChiTietDangKys)
                .HasForeignKey(ct => ct.MaDK);

            modelBuilder.Entity<ChiTietDangKy>()
                .HasOne(ct => ct.HocPhan)
                .WithMany()
                .HasForeignKey(ct => ct.MaHP);
        }
    }
}
