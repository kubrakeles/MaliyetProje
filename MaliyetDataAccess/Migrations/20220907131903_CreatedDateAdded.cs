using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaliyetDataAccess.Migrations
{
    public partial class CreatedDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Units",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedEmail",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Units",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedEmail",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TenderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedEmail",
                table: "TenderTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TenderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedEmail",
                table: "TenderTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tenders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedEmail",
                table: "Tenders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Tenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Tenders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedEmail",
                table: "Tenders",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CreatedEmail",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UpdatedEmail",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TenderTypes");

            migrationBuilder.DropColumn(
                name: "CreatedEmail",
                table: "TenderTypes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TenderTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedEmail",
                table: "TenderTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "CreatedEmail",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "UpdatedEmail",
                table: "Tenders");

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
    }
}
