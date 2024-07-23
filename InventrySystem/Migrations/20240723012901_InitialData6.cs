using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventrySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialData6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("6922c3dc-cc77-4d7a-8cc5-86dc1ff81578"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("8eb564aa-b306-47e0-8862-9d3ba01cbf5b"));

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "83fec35f-6fa1-44ed-8aa3-20669add2419");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b3a67e44-c954-4b08-97eb-7d9917f307a4");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("6922c3dc-cc77-4d7a-8cc5-86dc1ff81578"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") },
                    { new Guid("8eb564aa-b306-47e0-8862-9d3ba01cbf5b"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83fec35f-6fa1-44ed-8aa3-20669add2419", null, "Admin", "ADMIN" },
                    { "b3a67e44-c954-4b08-97eb-7d9917f307a4", null, "User", "USER" }
                });
        }
    }
}
