using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventrySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d6aca4f-d7cf-499b-be6a-fbb368246e38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe2a2529-02ac-4fc7-9ff1-6be59d283e51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11761a83-c5e7-4b38-95f7-3e716b3e0d70", null, "Admin", "ADMIN" },
                    { "74c233b9-427c-4f2d-a7a8-f2b5a803f63d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14c1b3fb-57d0-48f5-aa4a-130a1ab629c0"), "Dell" },
                    { new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), "Samsung" },
                    { new Guid("38fe8b3c-1f86-424a-857f-28b3d200adc3"), "Cisco" },
                    { new Guid("742229d4-eb49-4ded-8fc3-ee1fdf7d4157"), "Google" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Microsoft" },
                    { new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), "Lenovo" },
                    { new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), "Apple" },
                    { new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), "HP" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3ae0f960-57a5-40b3-a1b6-b21e89b037f0"), "Keyboards" },
                    { new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), "Printers" },
                    { new Guid("4b8fa9a2-f4ec-46d3-80e3-b0e6c0cc0fca"), "Mice" },
                    { new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), "Laptops" },
                    { new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), "Desktops" },
                    { new Guid("d3d0e04f-640e-42bc-8f47-6c65362b0905"), "Servers" },
                    { new Guid("f26edf00-3045-400e-94b4-95c1537adfc9"), "Monitors" },
                    { new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), "Routers" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "ContactInfo", "Name" },
                values: new object[,]
                {
                    { new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"), "Contact info for Omega IT", "Omega IT Eswatini" },
                    { new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"), "Contact info for CompuParts", "CompuParts Eswatini" },
                    { new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9"), "Contact info for Vuna Technologies", "Vuna Technologies" },
                    { new Guid("915d6ff3-f98f-4430-9bdd-dd8f23107670"), "Contact info for TelPro", "TelPro Eswatini" },
                    { new Guid("d699d296-11ea-490f-af70-925cb1859a57"), "Contact info for Cortex Technologies", "Cortex Technologies Eswatini" },
                    { new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"), "Contact info for DataNet", "DataNet Eswatini" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("3d7081f8-6731-47c1-9668-d22e16426e39"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") },
                    { new Guid("66cf9338-f525-492b-9c65-05f8af912a70"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11761a83-c5e7-4b38-95f7-3e716b3e0d70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74c233b9-427c-4f2d-a7a8-f2b5a803f63d");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("14c1b3fb-57d0-48f5-aa4a-130a1ab629c0"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("302a431a-2f54-4768-8a34-b6414f3909df"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("38fe8b3c-1f86-424a-857f-28b3d200adc3"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("742229d4-eb49-4ded-8fc3-ee1fdf7d4157"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3ae0f960-57a5-40b3-a1b6-b21e89b037f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b8fa9a2-f4ec-46d3-80e3-b0e6c0cc0fca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3d0e04f-640e-42bc-8f47-6c65362b0905"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f26edf00-3045-400e-94b4-95c1537adfc9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("3d7081f8-6731-47c1-9668-d22e16426e39"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("66cf9338-f525-492b-9c65-05f8af912a70"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("915d6ff3-f98f-4430-9bdd-dd8f23107670"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("d699d296-11ea-490f-af70-925cb1859a57"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d6aca4f-d7cf-499b-be6a-fbb368246e38", null, "Admin", "ADMIN" },
                    { "fe2a2529-02ac-4fc7-9ff1-6be59d283e51", null, "User", "USER" }
                });
        }
    }
}
