using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Genres_GenId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GenId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GenId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenId",
                table: "Genres",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Genres",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Genres",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Genres",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenId",
                table: "Genres",
                column: "GenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Genres_GenId",
                table: "Genres",
                column: "GenId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
