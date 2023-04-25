using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmss.Migrations
{
    public partial class Create_Table_DvnContList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DvnContList",
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
                    DevaningNo = table.Column<string>(maxLength: 50, nullable: true),
                    ContainerNo = table.Column<string>(maxLength: 50, nullable: true),
                    Renban = table.Column<string>(maxLength: 50, nullable: true),
                    SuppilerNo = table.Column<string>(maxLength: 50, nullable: true),
                    ShiftNo = table.Column<string>(maxLength: 20, nullable: true),
                    WorkingDate = table.Column<DateTime>(nullable: false),
                    PlanDevaningDate = table.Column<DateTime>(nullable: false),
                    ActDevaningDate = table.Column<DateTime>(nullable: false),
                    ActDevaningDateFinish = table.Column<DateTime>(nullable: false),
                    DevaningType = table.Column<string>(maxLength: 20, nullable: true),
                    DevaningStatus = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DvnContList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DvnContList");
        }
    }
}
