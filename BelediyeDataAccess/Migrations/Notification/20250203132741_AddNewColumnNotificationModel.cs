using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelediyeDataAccess.Migrations.Notification
{
    /// <inheritdoc />
    public partial class AddNewColumnNotificationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userID",
                table: "Notification");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Notification");

            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
