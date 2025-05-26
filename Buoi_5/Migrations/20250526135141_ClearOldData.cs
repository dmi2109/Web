using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi_5.Migrations
{
    /// <inheritdoc />
    public partial class ClearOldData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DeleteData(
        table: "Books",
        keyColumn: "Id",
        keyValues: new object[] { 1, 2, 3 }); // Xóa các ID cụ thể nếu biết trước

    migrationBuilder.DeleteData(
        table: "Categories",
        keyColumn: "CategoryId",
        keyValues: new object[] { 1, 2, 3 }); // Xóa các ID cụ thể
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    // Thêm lại dữ liệu nếu cần rollback
    migrationBuilder.InsertData(
        table: "Categories",
        columns: new[] { "CategoryId", "CategoryName" },
        values: new object[,]
        {
            { 1, "Cúc sừng" },
            { 2, "Lập trình" },
            { 3, "Sức khỏe" }
        });
    migrationBuilder.InsertData(
        table: "Books",
        columns: new[] { "Id", "Title", "Author", "Price", "Description", "Image", "CategoryId" },
        values: new object[,]
        {
            { 1, "Cúc Sừng Rất Giòn Cúc Đời", "Hải Đồ", 61000m, "Mô tả sách", "/images/cuc-sung.jpg", 1 },
            { 2, "Core Java Fundamentals", "Cay Horstmann", 100000m, "Mô tả sách lập trình", "/images/core-java.jpg", 2 },
            { 3, "Sức Khỏe Rất Giòn", "Nguyễn Văn A", 80000m, "Mô tả sách sức khỏe", "/images/suc-khoe.jpg", 3 }
        });
}
    }
}
