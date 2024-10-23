using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelediyeDataAccess.Migrations.Notification
{
    /// <inheritdoc />
    public partial class NotificationThird_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Notification",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Notification",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Notification",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
