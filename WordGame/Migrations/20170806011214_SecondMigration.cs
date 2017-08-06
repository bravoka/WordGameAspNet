using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordGame.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Users_UserId1",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_UserId1",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "GameResults");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GameResults",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_UserId",
                table: "GameResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Users_UserId",
                table: "GameResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Users_UserId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_UserId",
                table: "GameResults");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GameResults",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "GameResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_UserId1",
                table: "GameResults",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Users_UserId1",
                table: "GameResults",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
