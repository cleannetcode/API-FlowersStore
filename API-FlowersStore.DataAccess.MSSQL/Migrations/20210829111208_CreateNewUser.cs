using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FlowersStore.DataAccess.MSSQL.Migrations
{
    public partial class CreateNewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 29, 16, 12, 8, 457, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "Name" },
                values: new object[] { new DateTime(2021, 8, 29, 16, 12, 8, 458, DateTimeKind.Local).AddTicks(8633), "FlowersProvider@gmail.com", "FlowersProvider" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Email", "Name", "Role" },
                values: new object[] { new DateTime(2021, 8, 29, 16, 12, 8, 458, DateTimeKind.Local).AddTicks(8650), "BouqsCustomer@gmail.com", "BouqsCustomer", "Customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 8, 29, 16, 12, 8, 458, DateTimeKind.Local).AddTicks(8653), "RomanCustomer@gmail.com", "RomanCustomer", "123", "Customer" },
                    { 5, new DateTime(2021, 8, 29, 16, 12, 8, 458, DateTimeKind.Local).AddTicks(8655), "RomanProvider@gmail.com", "RomanProvider", "123", "Provider" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 29, 4, 2, 10, 951, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "Name" },
                values: new object[] { new DateTime(2021, 8, 29, 4, 2, 10, 952, DateTimeKind.Local).AddTicks(5744), "1-800-Flowers@gmail.com", "1800Flowers" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Email", "Name", "Role" },
                values: new object[] { new DateTime(2021, 8, 29, 4, 2, 10, 952, DateTimeKind.Local).AddTicks(5760), "TheBouqs@gmail.com", "TheBouqs", "Provider" });
        }
    }
}
