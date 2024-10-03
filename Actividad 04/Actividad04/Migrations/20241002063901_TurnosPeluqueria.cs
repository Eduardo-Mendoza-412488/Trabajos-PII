using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad04.Migrations
{
    /// <inheritdoc />
    public partial class TurnosPeluqueria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetallesTurno",
                columns: table => new
                {
                    id_turno = table.Column<int>(type: "int", nullable: false),
                    id_servicio = table.Column<int>(type: "int", nullable: false),
                    observaciones = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesTurno", x => new { x.id_turno, x.id_servicio });
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    costo = table.Column<int>(type: "int", nullable: false),
                    Promocion = table.Column<bool>(type: "bit", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 10, nullable: false),
                    hora = table.Column<TimeSpan>(type: "time", unicode: false, maxLength: 5, nullable: false),
                    cliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cancelacion = table.Column<bool>(type: "bit", nullable: false),
                    motivo_cancelacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesTurno");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Turnos");
        }
    }
}
