using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VODTask.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Films_FilmId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_FilmId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Directors");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmsId",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_FilmsId",
                table: "Directors",
                column: "FilmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Films_FilmsId",
                table: "Directors",
                column: "FilmsId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Films_FilmsId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_FilmsId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "FilmsId",
                table: "Directors");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Directors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_FilmId",
                table: "Directors",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Films_FilmId",
                table: "Directors",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
