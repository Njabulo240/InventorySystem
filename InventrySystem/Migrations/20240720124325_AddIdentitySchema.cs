using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventrySystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "412e5a6b-7f1a-48d3-8143-269a55983c90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2b335b5-c74f-42fd-b912-21cf4ce14d3b");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("26de0309-bf74-4691-a693-98412c21b1a5"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("575fc099-9a72-437f-a24e-7575b9611ce0"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("6b03e338-ca4d-4f2e-bbe8-0796355867e8"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") },
                    { new Guid("acb697c9-d9c9-4238-97b3-df0af9da7729"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc25c816-00b1-4135-b2a0-f1ce7a6ae38b", null, "User", "USER" },
                    { "bd74eb9b-06a7-43a4-bb3d-82383e31752b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("6b03e338-ca4d-4f2e-bbe8-0796355867e8"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("acb697c9-d9c9-4238-97b3-df0af9da7729"));

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "412e5a6b-7f1a-48d3-8143-269a55983c90", null, "User", "USER" },
                    { "b2b335b5-c74f-42fd-b912-21cf4ce14d3b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("26de0309-bf74-4691-a693-98412c21b1a5"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), false, "Desktop Y2", "SN654321", new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9") },
                    { new Guid("575fc099-9a72-437f-a24e-7575b9611ce0"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), false, "Laptop X1", "SN123456", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") }
                });
        }
    }
}
