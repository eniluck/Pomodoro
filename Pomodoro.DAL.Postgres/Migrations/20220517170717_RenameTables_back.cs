using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.DAL.Postgres.Migrations
{
    public partial class RenameTables_back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskCategory_CategoryId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCategory",
                table: "TaskCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "TaskCategory",
                newName: "TaskCategories");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CategoryId",
                table: "Tasks",
                newName: "IX_Tasks_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategories",
                table: "TaskCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskCategories_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskCategories_CategoryId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCategories",
                table: "TaskCategories");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "TaskCategories",
                newName: "TaskCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CategoryId",
                table: "Task",
                newName: "IX_Task_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategory",
                table: "TaskCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskCategory_CategoryId",
                table: "Task",
                column: "CategoryId",
                principalTable: "TaskCategory",
                principalColumn: "Id");
        }
    }
}
