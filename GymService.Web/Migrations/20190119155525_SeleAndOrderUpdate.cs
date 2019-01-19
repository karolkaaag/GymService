using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymService.Web.Migrations
{
    public partial class SeleAndOrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Orders_OrderId",
                table: "Sales",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
