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
                keyValue: new Guid("0ab89bb9-6680-463c-b3be-ff46d35c61d3"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("1367c7e1-0b32-41c1-ac42-5810d58c97f4"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("1b04a8d3-7343-46b2-9103-9c777958ea6b"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("2629dde7-e150-41c8-985b-51997d106ae6"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("30c27f26-1984-46f5-86e3-8a8c5e59949a"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("9fa3f1c4-e077-4858-a061-e3da2ffa7aae"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("a71dc0c6-f89a-486f-b169-b0b3c985af17"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("afd3da66-220c-4423-be70-bbe5da5ff9c6"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b713d4bb-b4ad-44b7-8bb7-220c047aed3a"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("c4da5406-4a9b-41da-9989-44d18696bc0c"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("d551203e-ef54-48ff-8807-c9e2839ebae1"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("f2e8f4d9-60ed-4de7-a036-8760003214c9"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2bd32c0-d75e-4966-8274-758e273da3fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aadea458-77e8-4a1d-b158-85bb1da80d71", "AQAAAAIAAYagAAAAEPJVW/qjZZqjKrbSEDEQ3D9qvD+HCiPTlVu7PfZpJ6JUrQ8KHmAyNZuNZ5bdkIGNfQ==" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("06d92bfd-6bd8-44be-8246-ab6df218da24"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y1", "SN246810", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("0e4a97e9-0d0d-4ef5-a418-2ec4d50fa7fe"), new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, false, "Mobile Phone M1", "SN789012", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("24def009-1f00-484d-8da5-246e1dcd7a24"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X2", "SN789012", new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662") },
                    { new Guid("3ad0c4ff-b918-4cea-a592-6d1d13382509"), new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, false, "Mobile Phone M2", "SN456789", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("4ea5279f-5d0a-4191-b341-84639f62fd45"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X3", "SN345678", new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662") },
                    { new Guid("7766401a-0891-4409-a4fa-5682b0dcad37"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y3", "SN112233", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("b2719efd-4bea-4cc2-84c3-4400e838a545"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X1", "SN123456", new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662") },
                    { new Guid("b714a553-b91f-4acc-b791-d510fb4b327b"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, false, "Printer Z2", "SN456789", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("c655db0d-7a7c-4d3c-85bd-87e6b89050c3"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y2", "SN567890", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("c8357b30-923c-4bc4-9413-8e51a9216c28"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, false, "Printer Z1", "SN987654", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("cc73f4c5-2fd8-40fc-bb78-e73cb9c41121"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, false, "Mobile Phone M3", "SN135790", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("eba952db-addc-414b-bb9d-a8503dcdb3f3"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, false, "Printer Z3", "SN135790", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeNumber", "FirstName", "LastName", "Position" },
                values: new object[,]
                {
                    { new Guid("07d7fa03-5520-40cc-8c79-36a19801c0fe"), "jane.smith@example.com", "EMP002", "Jane", "Smith", "Project Manager" },
                    { new Guid("41d13230-f49c-46ad-bfba-de7b87bc0551"), "alice.johnson@example.com", "EMP003", "Alice", "Johnson", "HR Coordinator" },
                    { new Guid("7f8ba2f9-3462-4d1e-9dbc-eacab5de0bef"), "john.doe@example.com", "EMP001", "John", "Doe", "Software Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("1fe78363-8333-4168-8dd7-532dcb58de42"), "Building 1, Floor 2", "Office A" },
                    { new Guid("36221a12-b058-49d7-9192-22f1dd012385"), "Building 3, Floor 3", "Office C" },
                    { new Guid("516d490a-073d-4c1d-a375-78be4378128d"), "Building 2, Floor 1", "Office B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("06d92bfd-6bd8-44be-8246-ab6df218da24"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0e4a97e9-0d0d-4ef5-a418-2ec4d50fa7fe"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("24def009-1f00-484d-8da5-246e1dcd7a24"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("3ad0c4ff-b918-4cea-a592-6d1d13382509"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("4ea5279f-5d0a-4191-b341-84639f62fd45"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("7766401a-0891-4409-a4fa-5682b0dcad37"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b2719efd-4bea-4cc2-84c3-4400e838a545"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b714a553-b91f-4acc-b791-d510fb4b327b"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("c655db0d-7a7c-4d3c-85bd-87e6b89050c3"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("c8357b30-923c-4bc4-9413-8e51a9216c28"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("cc73f4c5-2fd8-40fc-bb78-e73cb9c41121"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("eba952db-addc-414b-bb9d-a8503dcdb3f3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("07d7fa03-5520-40cc-8c79-36a19801c0fe"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("41d13230-f49c-46ad-bfba-de7b87bc0551"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7f8ba2f9-3462-4d1e-9dbc-eacab5de0bef"));

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("1fe78363-8333-4168-8dd7-532dcb58de42"));

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("36221a12-b058-49d7-9192-22f1dd012385"));

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("516d490a-073d-4c1d-a375-78be4378128d"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2bd32c0-d75e-4966-8274-758e273da3fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ea1f06e-4dac-4f46-b643-af163fd55fde", "AQAAAAIAAYagAAAAEEnIReNKuUfjZhAJIM6RCa3YuOvnFkgJAlhroO7w7p90k7KQ+xPQ4fP9mGzd3uZlvA==" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BrandId", "CategoryId", "IsAvailable", "IsFaulty", "Name", "SerialNumber", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("0ab89bb9-6680-463c-b3be-ff46d35c61d3"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y1", "SN246810", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("1367c7e1-0b32-41c1-ac42-5810d58c97f4"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y3", "SN112233", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("1b04a8d3-7343-46b2-9103-9c777958ea6b"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X1", "SN123456", new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662") },
                    { new Guid("2629dde7-e150-41c8-985b-51997d106ae6"), new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"), new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"), true, false, "Desktop Y2", "SN567890", new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0") },
                    { new Guid("30c27f26-1984-46f5-86e3-8a8c5e59949a"), new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, false, "Mobile Phone M1", "SN789012", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("9fa3f1c4-e077-4858-a061-e3da2ffa7aae"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, false, "Printer Z1", "SN987654", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("a71dc0c6-f89a-486f-b169-b0b3c985af17"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, false, "Mobile Phone M3", "SN135790", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("afd3da66-220c-4423-be70-bbe5da5ff9c6"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X2", "SN789012", new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662") },
                    { new Guid("b713d4bb-b4ad-44b7-8bb7-220c047aed3a"), new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"), new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"), true, false, "Laptop X3", "SN345678", new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662") },
                    { new Guid("c4da5406-4a9b-41da-9989-44d18696bc0c"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, false, "Printer Z2", "SN456789", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("d551203e-ef54-48ff-8807-c9e2839ebae1"), new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"), new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"), true, false, "Printer Z3", "SN135790", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") },
                    { new Guid("f2e8f4d9-60ed-4de7-a036-8760003214c9"), new Guid("302a431a-2f54-4768-8a34-b6414f3909df"), new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"), true, false, "Mobile Phone M2", "SN456789", new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8") }
                });
        }
    }
}
