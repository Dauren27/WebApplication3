using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTypesInProjects2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "ProjectManager",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectManager",
                table: "Project");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectManagerId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
