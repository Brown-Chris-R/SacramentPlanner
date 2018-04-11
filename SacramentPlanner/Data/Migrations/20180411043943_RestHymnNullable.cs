using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner.Data.Migrations
{
    public partial class RestHymnNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IntermediateSongNumber",
                table: "SacramentMeeting",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IntermediateSongNumber",
                table: "SacramentMeeting",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
