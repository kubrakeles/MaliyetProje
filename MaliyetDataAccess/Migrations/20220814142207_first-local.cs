using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaliyetDataAccess.Migrations
{
    public partial class firstlocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderTypeId = table.Column<int>(type: "int", nullable: false),
                    TenderingProcedure = table.Column<int>(type: "int", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    TenderRegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTypeWorkLoad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpproximateCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnalysisRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoseRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketResearchRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousOpproximateCoast = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousOCTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousConractPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousCPTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherFoundationContractPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpproximateCostAfterTender = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Contratprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KirimRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TendererProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnthusiastFoundation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceDifference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherExplanation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenders_TenderTypes_TenderTypeId",
                        column: x => x.TenderTypeId,
                        principalTable: "TenderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenders_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_TenderTypeId",
                table: "Tenders",
                column: "TenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_UnitId",
                table: "Tenders",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaim");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TenderTypes");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
