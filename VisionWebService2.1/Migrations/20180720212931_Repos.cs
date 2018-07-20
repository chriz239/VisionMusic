using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionWebService.Migrations
{
    public partial class Repos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "RelativePath",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepositoryID",
                table: "Tracks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    RepositoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.RepositoryID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_RepositoryID",
                table: "Tracks",
                column: "RepositoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Key",
                table: "Settings",
                column: "Key",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Repositories_RepositoryID",
                table: "Tracks",
                column: "RepositoryID",
                principalTable: "Repositories",
                principalColumn: "RepositoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Repositories_RepositoryID",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Repositories");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_RepositoryID",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "RelativePath",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "RepositoryID",
                table: "Tracks");

            migrationBuilder.AddColumn<byte[]>(
                name: "HashedPassword",
                table: "Users",
                nullable: true);
        }
    }
}
