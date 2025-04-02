using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plCa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanhGia = table.Column<double>(type: "float", nullable: false),
                    LoaiNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KichThuoc = table.Column<double>(type: "float", nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianSinhTon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plCa", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plCa");
        }
    }
}
