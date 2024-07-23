using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventrySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialData7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("43231dcd-43e0-4678-ad6a-e296a9c02044"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("f0ecb5b3-2147-41b7-95b8-4d6ef98cb9f1"));

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "23801bc4-1706-4cb2-9590-6afc62a67291");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8aeaba44-b317-4005-8c2f-60e7f2522917");

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("0747748a-ba1d-4e41-9c94-c97b331d5fc5"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") },
                    { new Guid("f8765986-7833-4d9c-a544-f11844f1ea1e"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2400d517-2f6f-4a93-82d4-34d586ce011c", null, "User", "USER" },
                    { "c29f9f14-550c-4ebb-bbea-a44af7a1567d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0747748a-ba1d-4e41-9c94-c97b331d5fc5"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("f8765986-7833-4d9c-a544-f11844f1ea1e"));

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2400d517-2f6f-4a93-82d4-34d586ce011c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c29f9f14-550c-4ebb-bbea-a44af7a1567d");

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("43231dcd-43e0-4678-ad6a-e296a9c02044"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), false, false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") },
                    { new Guid("f0ecb5b3-2147-41b7-95b8-4d6ef98cb9f1"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), false, false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23801bc4-1706-4cb2-9590-6afc62a67291", null, "Admin", "ADMIN" },
                    { "8aeaba44-b317-4005-8c2f-60e7f2522917", null, "User", "USER" }
                });
        }
    }
}
