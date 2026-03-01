using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jeremy_Sanchez_AP1_P1.Migrations
{
    /// <inheritdoc />
    public partial class DetalleV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEntrada",
                table: "EntradasHuacales",
                newName: "EntradaId");

            migrationBuilder.CreateTable(
                name: "DetallesEntradas",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesEntradas", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DetallesEntradas_EntradasHuacales_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "EntradasHuacales",
                        principalColumn: "EntradaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEntradas_EntradaId",
                table: "DetallesEntradas",
                column: "EntradaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesEntradas");

            migrationBuilder.RenameColumn(
                name: "EntradaId",
                table: "EntradasHuacales",
                newName: "IdEntrada");
        }
    }
}
