using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmss.Migrations
{
    public partial class update_Part_and_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnpackingNo",
                table: "Part");

            migrationBuilder.AddColumn<string>(
                name: "ModuleNo",
                table: "Part",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "Part",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Renban",
                table: "Part",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Part",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Part",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleStatus",
                table: "LupContModule",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActUnpackingDate",
                table: "LupContModule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActUnpackingDateFinish",
                table: "LupContModule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanUnpackingDate",
                table: "LupContModule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Renban",
                table: "LupContModule",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "LupContModule",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleNo",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PartName",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Renban",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ActUnpackingDate",
                table: "LupContModule");

            migrationBuilder.DropColumn(
                name: "ActUnpackingDateFinish",
                table: "LupContModule");

            migrationBuilder.DropColumn(
                name: "PlanUnpackingDate",
                table: "LupContModule");

            migrationBuilder.DropColumn(
                name: "Renban",
                table: "LupContModule");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "LupContModule");

            migrationBuilder.AddColumn<string>(
                name: "UnpackingNo",
                table: "Part",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleStatus",
                table: "LupContModule",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
