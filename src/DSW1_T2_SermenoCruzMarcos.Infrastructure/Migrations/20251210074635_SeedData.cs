using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedAt", "ISBN", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "Gabriel García Márquez", new DateTime(2025, 12, 10, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9266), "978-0307474728", 5, "Cien años de soledad" },
                    { 2, "J.R.R. Tolkien", new DateTime(2025, 12, 10, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9283), "978-0618260234", 10, "El Señor de los Anillos" },
                    { 3, "Gabriel García Márquez", new DateTime(2025, 12, 10, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9284), "978-0307474729", 2, "Crónica de una muerte anunciada" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "CreatedAt", "LoanDate", "ReturnDate", "Status", "StudentName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 12, 5, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9410), new DateTime(2025, 12, 5, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9402), null, "Active", "Marcos Cruz" },
                    { 2, 2, new DateTime(2025, 11, 30, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9415), new DateTime(2025, 11, 30, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9411), new DateTime(2025, 12, 2, 2, 46, 35, 252, DateTimeKind.Local).AddTicks(9411), "Returned", "Ana Gutiérrez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
