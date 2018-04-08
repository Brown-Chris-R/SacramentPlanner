using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "SacramentMeeting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClosingPrayerName = table.Column<string>(nullable: true),
                    ClosingSongNumber = table.Column<int>(nullable: false),
                    ClosingSongTitle = table.Column<string>(nullable: true),
                    ConductorName = table.Column<string>(nullable: true),
                    IntermediateSongNumber = table.Column<int>(nullable: false),
                    IntermediateSongTitle = table.Column<string>(nullable: true),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    OpeningPrayerName = table.Column<string>(nullable: true),
                    OpeningSongNumber = table.Column<int>(nullable: false),
                    OpeningSongTitle = table.Column<string>(nullable: true),
                    SacramentSongNumber = table.Column<int>(nullable: false),
                    SacramentSongTitle = table.Column<string>(nullable: true),
                    SpecialNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeeting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingAssignment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedOnDate = table.Column<DateTime>(nullable: false),
                    AssignedTopic = table.Column<string>(nullable: true),
                    SacramentMeetingID = table.Column<int>(nullable: false),
                    SpeakerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingAssignment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpeakingAssignment_SacramentMeeting_SacramentMeetingID",
                        column: x => x.SacramentMeetingID,
                        principalTable: "SacramentMeeting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingAssignment_SacramentMeetingID",
                table: "SpeakingAssignment",
                column: "SacramentMeetingID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SpeakingAssignment");

            migrationBuilder.DropTable(
                name: "SacramentMeeting");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
