using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalApiRealState.Migrations
{
    /// <inheritdoc />
    public partial class PropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CreationDate", "Description", "IsActive", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("6f8561e6-54c6-42b5-8a56-b605a4bb26d8"), new DateTimeOffset(new DateTime(2023, 10, 4, 13, 38, 19, 830, DateTimeKind.Unspecified).AddTicks(3689), new TimeSpan(0, 0, 0, 0, 0)), "Descripción test 1", true, "Cartagena", "Casa las palmas" },
                    { new Guid("92e2db3d-aceb-496a-b57e-0d0cf2eae202"), new DateTimeOffset(new DateTime(2023, 10, 4, 13, 38, 19, 830, DateTimeKind.Unspecified).AddTicks(3702), new TimeSpan(0, 0, 0, 0, 0)), "Descripción test 4", true, "Medellín", "Casa El Poblado" },
                    { new Guid("b6a1923b-b82a-48a3-9a39-bce1caf99cef"), new DateTimeOffset(new DateTime(2023, 10, 4, 13, 38, 19, 830, DateTimeKind.Unspecified).AddTicks(3695), new TimeSpan(0, 0, 0, 0, 0)), "Descripción test 2", true, "Barranquilla", "Casa Concorde" },
                    { new Guid("bf54fca7-df09-42dd-a6df-c5da8c7fecfd"), new DateTimeOffset(new DateTime(2023, 10, 4, 13, 38, 19, 830, DateTimeKind.Unspecified).AddTicks(3699), new TimeSpan(0, 0, 0, 0, 0)), "Descripción test 3", false, "Bogotá", "Casa Centro Bogotá" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
