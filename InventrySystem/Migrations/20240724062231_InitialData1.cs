using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventrySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("3cffec65-6a2c-460c-8072-60cfe692c19d"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b764457b-84c1-46d0-8e84-42782c0f7355"));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cfa9978f-2afd-4786-9cf9-97b4493f4d34", "a2bd32c0-d75e-4966-8274-758e273da3fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2bd32c0-d75e-4966-8274-758e273da3fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c19978e-d60e-411b-a239-c4b75b55772c", "AQAAAAIAAYagAAAAEIVqPxFzNE5xilE7ywTUVt4wz1wi1Cv41ioUY2LgsFcImTLGeIy6L3qvTxMmIaVXJQ==" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("3cce8fb2-3102-4b91-b937-66bdd3aea592"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("4681a7c2-1e61-492a-9b24-d65d968a8e0e"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cfa9978f-2afd-4786-9cf9-97b4493f4d34", "a2bd32c0-d75e-4966-8274-758e273da3fb" });

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("3cce8fb2-3102-4b91-b937-66bdd3aea592"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("4681a7c2-1e61-492a-9b24-d65d968a8e0e"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2bd32c0-d75e-4966-8274-758e273da3fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73a311cb-57c1-4802-8db7-f0a637971240", "AQAAAAIAAYagAAAAEOZ76Qz6saa60jCZtKwlNkVeF0YmeA6gR7Sv5AY2AeSlHEa7L5hg+2tk/4aG0edcog==" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("3cffec65-6a2c-460c-8072-60cfe692c19d"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("b764457b-84c1-46d0-8e84-42782c0f7355"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") }
                });
        }
    }
}
