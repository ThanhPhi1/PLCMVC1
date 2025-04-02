using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLC.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToPlCa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "HinhAnh",
                table: "plCa",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "plCa");
        }
    }
}
