using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.DAL.Postgres.Migrations
{
    public partial class ChangeTaskEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_CategoryId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskCategories_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskCategories_CategoryId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
