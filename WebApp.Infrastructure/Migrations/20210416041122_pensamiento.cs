using Microsoft.EntityFrameworkCore.Migrations;

namespace EditorialMvc.DataAccess.Migrations
{
    public partial class pensamiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pensamiento_PensamientoId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pensamiento",
                table: "Pensamiento");

            migrationBuilder.RenameTable(
                name: "Pensamiento",
                newName: "Pensamientos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pensamientos",
                table: "Pensamientos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pensamientos_PensamientoId",
                table: "AspNetUsers",
                column: "PensamientoId",
                principalTable: "Pensamientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pensamientos_PensamientoId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pensamientos",
                table: "Pensamientos");

            migrationBuilder.RenameTable(
                name: "Pensamientos",
                newName: "Pensamiento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pensamiento",
                table: "Pensamiento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pensamiento_PensamientoId",
                table: "AspNetUsers",
                column: "PensamientoId",
                principalTable: "Pensamiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
