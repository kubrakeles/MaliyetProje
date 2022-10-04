using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaliyetDataAccess.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedEmail",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedEmail",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OperationClaim");

            migrationBuilder.DropColumn(
                name: "CreatedEmail",
                table: "OperationClaim");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "OperationClaim");

            migrationBuilder.DropColumn(
                name: "UpdatedEmail",
                table: "OperationClaim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserOperationClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedEmail",
                table: "UserOperationClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "UserOperationClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedEmail",
                table: "UserOperationClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OperationClaim",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedEmail",
                table: "OperationClaim",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "OperationClaim",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedEmail",
                table: "OperationClaim",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
