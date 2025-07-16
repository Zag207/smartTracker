using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTraсker.Data.Migrations
{
    /// <inheritdoc />
    public partial class requiredCreatedAtinWorkTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AuthorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_ExecutorId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "WorkTasks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ExecutorId",
                table: "WorkTasks",
                newName: "IX_WorkTasks_ExecutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AuthorId",
                table: "WorkTasks",
                newName: "IX_WorkTasks_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTasks",
                table: "WorkTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WorkTasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Users_AuthorId",
                table: "WorkTasks",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Users_ExecutorId",
                table: "WorkTasks",
                column: "ExecutorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WorkTasks_TaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Users_AuthorId",
                table: "WorkTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Users_ExecutorId",
                table: "WorkTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTasks",
                table: "WorkTasks");

            migrationBuilder.RenameTable(
                name: "WorkTasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTasks_ExecutorId",
                table: "Tasks",
                newName: "IX_Tasks_ExecutorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTasks_AuthorId",
                table: "Tasks",
                newName: "IX_Tasks_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_ExecutorId",
                table: "Tasks",
                column: "ExecutorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
