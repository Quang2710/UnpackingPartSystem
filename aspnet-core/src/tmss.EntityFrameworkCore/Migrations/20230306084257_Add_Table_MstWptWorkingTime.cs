using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmss.Migrations
{
    public partial class Add_Table_MstWptWorkingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstWptWorkingTime",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ShiftNo = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WorkingType = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    PatternHId = table.Column<int>(nullable: false),
                    SeasonType = table.Column<string>(maxLength: 10, nullable: true),
                    DayOfWeek = table.Column<string>(maxLength: 100, nullable: true),
                    WeekWorkingDays = table.Column<int>(nullable: false),
                    IsActive = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstWptWorkingTime", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstWptWorkingTime");
        }
    }
}
