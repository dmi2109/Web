using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi_5.Migrations
{
    /// <inheritdoc />
    public partial class AddRealBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thêm thể loại
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
            { 1, "Lập trình" },
            { 2, "Văn học" },
            { 3, "Phát triển bản thân" }
                });

            // Thêm sách
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "Author", "Price", "Description", "Image", "CategoryId" },
                values: new object[,]
                {
            { 1, "Clean Code: A Handbook of Agile Software Craftsmanship", "Robert C. Martin", 500000m, "Hướng dẫn viết mã sạch và bền vững.", "/images/clean-code.jpg", 1 },
            { 2, "You Don't Know JS (Up & Going)", "Kyle Simpson", 300000m, "Cơ bản về JavaScript cho người mới bắt đầu.", "/images/you-dont-know-js.jpg", 1 },
            { 3, "To Kill a Mockingbird", "Harper Lee", 200000m, "Tiểu thuyết kinh điển về công lý và lòng trắc ẩn.", "/images/to-kill-a-mockingbird.jpg", 2 },
            { 4, "The Great Gatsby", "F. Scott Fitzgerald", 180000m, "Câu chuyện về giấc mơ Mỹ và tình yêu.", "/images/great-gatsby.jpg", 2 },
            { 5, "Atomic Habits", "James Clear", 250000m, "Hướng dẫn xây dựng thói quen hiệu quả.", "/images/atomic-habits.jpg", 3 },
            { 6, "The Power of Now", "Eckhart Tolle", 220000m, "Sống trọn vẹn trong hiện tại.", "/images/power-of-now.jpg", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
