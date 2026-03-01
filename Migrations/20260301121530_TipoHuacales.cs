using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jeremy_Sanchez_AP1_P1.Migrations
{
    /// <inheritdoc />
    public partial class TipoHuacales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Huacales Verdes", 0 },
                    { 2, "Huacales Rojos", 0 },
                    { 3, "Huacales Amarillos", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEntradas_TipoId",
                table: "DetallesEntradas",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEntradas_TiposHuacales_TipoId",
                table: "DetallesEntradas",
                column: "TipoId",
                principalTable: "TiposHuacales",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEntradas_TiposHuacales_TipoId",
                table: "DetallesEntradas");

            migrationBuilder.DropTable(
                name: "TiposHuacales");

            migrationBuilder.DropIndex(
                name: "IX_DetallesEntradas_TipoId",
                table: "DetallesEntradas");
        }
    }
}
