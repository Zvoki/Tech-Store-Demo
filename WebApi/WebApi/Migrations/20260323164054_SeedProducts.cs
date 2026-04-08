using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Smartphones and futuristic mobile devices", "Mobile" },
                    { 2, "Laptops and portable computers", "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "ImageUrl", "Name", "Price", "PublishDate", "Sku" },
                values: new object[,]
                {
                    { 1, null, 1, null, "/img/1mobil.webp", "Futuristic Smartphone 1", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa001" },
                    { 2, null, 1, null, "/img/2mobil.webp", "Futuristic Smartphone 2", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa002" },
                    { 3, null, 1, null, "/img/3mobil.webp", "Futuristic Smartphone 3", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa003" },
                    { 4, null, 1, null, "/img/4mobil.webp", "Futuristic Smartphone 4", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa004" },
                    { 5, null, 1, null, "/img/5mobil.webp", "Futuristic Smartphone 5", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa005" },
                    { 6, null, 1, null, "/img/6mobil.webp", "Futuristic Smartphone 6", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa006" },
                    { 7, null, 1, null, "/img/7mobil.webp", "Futuristic Smartphone 7", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa007" },
                    { 8, null, 1, null, "/img/8mobil.webp", "Futuristic Smartphone 8", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa008" },
                    { 9, null, 1, null, "/img/9mobil.webp", "Futuristic Smartphone 9", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa009" },
                    { 10, null, 1, null, "/img/10mobil.webp", "Futuristic Smartphone 10", 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa010" },
                    { 11, null, 2, null, "/img/1laptop.webp", "Gaming Laptop 1", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb001" },
                    { 12, null, 2, null, "/img/2laptop.webp", "Gaming Laptop 2", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb002" },
                    { 13, null, 2, null, "/img/3laptop.webp", "Gaming Laptop 3", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb003" },
                    { 14, null, 2, null, "/img/4laptop.webp", "Gaming Laptop 4", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb004" },
                    { 15, null, 2, null, "/img/5laptop.webp", "Gaming Laptop 5", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb005" },
                    { 16, null, 2, null, "/img/6laptop.webp", "Gaming Laptop 6", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb006" },
                    { 17, null, 2, null, "/img/7laptop.webp", "Gaming Laptop 7", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb007" },
                    { 18, null, 2, null, "/img/8laptop.webp", "Gaming Laptop 8", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb008" },
                    { 19, null, 2, null, "/img/9laptop.webp", "Gaming Laptop 9", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb009" },
                    { 20, null, 2, null, "/img/10laptop.webp", "Gaming Laptop 10", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb010" },
                    { 21, null, 2, null, "/img/11laptop.webp", "Gaming Laptop 11", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb011" },
                    { 22, null, 2, null, "/img/12laptop.webp", "Gaming Laptop 12", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb012" },
                    { 23, null, 2, null, "/img/13laptop.webp", "Gaming Laptop 13", 2000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbb013" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
