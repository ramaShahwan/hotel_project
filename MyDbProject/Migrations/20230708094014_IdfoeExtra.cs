using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDbProject.Migrations
{
    public partial class IdfoeExtra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Extras_Extra_Services_Extra_ServicesEntityId",
                table: "Hotel_Extras");

            migrationBuilder.DropColumn(
                name: "Extra_ServiceEntityId",
                table: "Hotel_Extras");

            migrationBuilder.AlterColumn<int>(
                name: "Extra_ServicesEntityId",
                table: "Hotel_Extras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotel_Extras",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Extras_Extra_Services_Extra_ServicesEntityId",
                table: "Hotel_Extras",
                column: "Extra_ServicesEntityId",
                principalTable: "Extra_Services",
                principalColumn: "Extra_ServicesEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Extras_Extra_Services_Extra_ServicesEntityId",
                table: "Hotel_Extras");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotel_Extras");

            migrationBuilder.AlterColumn<int>(
                name: "Extra_ServicesEntityId",
                table: "Hotel_Extras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Extra_ServiceEntityId",
                table: "Hotel_Extras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Extras_Extra_Services_Extra_ServicesEntityId",
                table: "Hotel_Extras",
                column: "Extra_ServicesEntityId",
                principalTable: "Extra_Services",
                principalColumn: "Extra_ServicesEntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
