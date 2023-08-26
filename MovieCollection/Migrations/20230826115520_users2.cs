using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieCollection.Migrations
{
    /// <inheritdoc />
    public partial class users2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d68313d-9fe5-4e36-bf83-065781ce3abd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ac24b2-f132-4978-90f8-d35c5f811507");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9caddc2a-970e-4190-9b0a-51f41c000fcc", "1", "Admin", "Admin" },
                    { "f7d7e69b-3680-42c6-98f9-47c19801048f", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9caddc2a-970e-4190-9b0a-51f41c000fcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7d7e69b-3680-42c6-98f9-47c19801048f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d68313d-9fe5-4e36-bf83-065781ce3abd", "2", "User", "User" },
                    { "35ac24b2-f132-4978-90f8-d35c5f811507", "1", "Admin", "Admin" }
                });
        }
    }
}
