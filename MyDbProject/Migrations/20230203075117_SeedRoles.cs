using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyDbProject.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "User", "User".ToUpper(), Guid.NewGuid().ToString() },
                schema: "security"
                );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { "0c463d5d-2010-4472-98b9-36ab15c183ad", "Admin", "Admin".ToUpper(), "0c463d5d-2010-4472-98b9-36ab15c183ad" },
                schema: "security"
            );
        }
        //

        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.InsertData(
        //        table: "Roles",
        //       columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        //       values: new object[] { Guid.NewGuid().ToString(), "User", "User".ToUpper(), Guid.NewGuid().ToString() },
        //       schema: "security"
        //       );

        //    migrationBuilder.InsertData(
        //      table: "Roles",
        //      columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        //      values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() },
        //      schema: "security"
        //  );
        //}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Roles]");
        }
    }
}
