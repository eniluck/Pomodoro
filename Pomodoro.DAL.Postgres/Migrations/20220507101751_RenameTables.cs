using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.DAL.Postgres.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskCategories_CategoryId",
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

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroEstimation",
                table: "Task",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Task",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TaskCategory",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TaskCategories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroEstimation",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategories",
                table: "TaskCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskCategories_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id");
        }
    }
}
