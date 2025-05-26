using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi_5.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
        name: "Categories",
        columns: table => new
        {
            CategoryId = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            CategoryName = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Categories", x => x.CategoryId);
        });

    migrationBuilder.CreateTable(
        name: "Books",
        columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            Title = table.Column<string>(nullable: true),
            Author = table.Column<string>(nullable: true),
            Price = table.Column<decimal>(nullable: false),
            Description = table.Column<string>(nullable: true),
            Image = table.Column<string>(nullable: true),
            CategoryId = table.Column<int>(nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Books", x => x.Id);
            table.ForeignKey(
                name: "FK_Books_Categories_CategoryId",
                column: x => x.CategoryId,
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        });

    // Thêm dữ liệu mẫu
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
            { 1, "Cúc Sừng Rất Giòn Cúc Đời", "Hải Đồ", 61000m, "Mô tả sách", "path/to/image.jpg", 1 }
        });
}
    }
}
