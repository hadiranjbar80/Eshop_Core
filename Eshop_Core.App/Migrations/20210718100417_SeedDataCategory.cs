using Microsoft.EntityFrameworkCore.Migrations;

namespace Eshop_Core.App.Migrations
{
    public partial class SeedDataCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Asp.Net Core 3", "Asp.Net Core" },
                    { 2, "گروه لباس ورزشی", "لباس ورزشی" },
                    { 3, "گروه ساعت مچی", "ساعت مچی" },
                    { 4, "گروه لوازم منزل", "لوازم منزل" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
