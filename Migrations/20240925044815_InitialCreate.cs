using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidroRoto.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Herrajes",
                columns: table => new
                {
                    IdHerraje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHerraje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herrajes", x => x.IdHerraje);
                });

            migrationBuilder.CreateTable(
                name: "Marcos",
                columns: table => new
                {
                    IdMarco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMarco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensiones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcos", x => x.IdMarco);
                });

            migrationBuilder.CreateTable(
                name: "Vidrios",
                columns: table => new
                {
                    IdVidrio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVidrio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grosor = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidrios", x => x.IdVidrio);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    IdCotizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdMarco = table.Column<int>(type: "int", nullable: false),
                    IdVidrio = table.Column<int>(type: "int", nullable: false),
                    IdHerraje = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.IdCotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Herrajes_IdHerraje",
                        column: x => x.IdHerraje,
                        principalTable: "Herrajes",
                        principalColumn: "IdHerraje",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Marcos_IdMarco",
                        column: x => x.IdMarco,
                        principalTable: "Marcos",
                        principalColumn: "IdMarco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Vidrios_IdVidrio",
                        column: x => x.IdVidrio,
                        principalTable: "Vidrios",
                        principalColumn: "IdVidrio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_IdCliente",
                table: "Cotizaciones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_IdHerraje",
                table: "Cotizaciones",
                column: "IdHerraje");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_IdMarco",
                table: "Cotizaciones",
                column: "IdMarco");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_IdVidrio",
                table: "Cotizaciones",
                column: "IdVidrio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Herrajes");

            migrationBuilder.DropTable(
                name: "Marcos");

            migrationBuilder.DropTable(
                name: "Vidrios");
        }
    }
}
