using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner.Data.Migrations
{
    public partial class AddSpeakingSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeakingSequence",
                table: "SpeakingAssignment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpeakingSequence",
                table: "SpeakingAssignment");
        }
    }
}
