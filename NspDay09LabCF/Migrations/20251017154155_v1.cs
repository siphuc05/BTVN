using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NspDay09LabCF.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NspLoai_San_Pham",
                columns: table => new
                {
                    nspId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nspMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nspTenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nspTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NspLoai_San_Pham", x => x.nspId);
                });

            migrationBuilder.CreateTable(
                name: "NspSan_Pham",
                columns: table => new
                {
                    nspId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nspMaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nspTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nspHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nspSoLuong = table.Column<int>(type: "int", nullable: false),
                    nspDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nspLoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false),
                    nspLoai_San_PhamnspId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NspSan_Pham", x => x.nspId);
                    table.ForeignKey(
                        name: "FK_NspSan_Pham_NspLoai_San_Pham_nspLoai_San_PhamnspId",
                        column: x => x.nspLoai_San_PhamnspId,
                        principalTable: "NspLoai_San_Pham",
                        principalColumn: "nspId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NspLoai_San_Pham_nspMaLoai",
                table: "NspLoai_San_Pham",
                column: "nspMaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NspSan_Pham_nspLoai_San_PhamnspId",
                table: "NspSan_Pham",
                column: "nspLoai_San_PhamnspId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NspSan_Pham");

            migrationBuilder.DropTable(
                name: "NspLoai_San_Pham");
        }
    }
}
