using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.DataAccess.Migrations
{
    public partial class SeagregacolumnaOfficeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Admins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_OfficeId",
                table: "Admins",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Officess_OfficeId",
                table: "Admins",
                column: "OfficeId",
                principalTable: "Officess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Officess_OfficeId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_OfficeId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Admins");
        }
    }
}
