using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDbProject.Migrations
{
    public partial class servEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Extras_Extra_Services_Extra_ServicesEntityId",
                table: "Hotel_Extras");

            migrationBuilder.DropTable(
                name: "Extra_Services");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_Extras_Extra_ServicesEntityId",
                table: "Hotel_Extras");

            migrationBuilder.DropColumn(
                name: "Extra_ServicesEntityId",
                table: "Hotel_Extras");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotel_Extras",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extra_ServicesName",
                table: "Hotel_Extras",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Extra_ServicesPicture",
                table: "Hotel_Extras",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extra_ServicesName",
                table: "Hotel_Extras");

            migrationBuilder.DropColumn(
                name: "Extra_ServicesPicture",
                table: "Hotel_Extras");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotel_Extras",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Extra_ServicesEntityId",
                table: "Hotel_Extras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Extra_Services",
                columns: table => new
                {
                    Extra_ServicesEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Extra_ServicesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Extra_ServicesPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra_Services", x => x.Extra_ServicesEntityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Extras_Extra_ServicesEntityId",
                table: "Hotel_Extras",
                column: "Extra_ServicesEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Extras_Extra_Services_Extra_ServicesEntityId",
                table: "Hotel_Extras",
                column: "Extra_ServicesEntityId",
                principalTable: "Extra_Services",
                principalColumn: "Extra_ServicesEntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
