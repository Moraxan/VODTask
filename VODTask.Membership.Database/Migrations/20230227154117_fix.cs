using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VODTask.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Films_FilmsId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_FilmsId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "FilmsId",
                table: "Directors");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId1",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId1",
                table: "Films",
                column: "DirectorId1",
                unique: true,
                filter: "[DirectorId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId1",
                table: "Films",
                column: "DirectorId1",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId1",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_DirectorId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_DirectorId1",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DirectorId1",
                table: "Films");

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
    }
}
