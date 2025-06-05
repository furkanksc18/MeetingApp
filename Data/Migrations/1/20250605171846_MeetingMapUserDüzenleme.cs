using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingApp.Data.Migrations._1
{
    /// <inheritdoc />
    public partial class MeetingMapUserDüzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingMapUsers_MeetingId",
                table: "MeetingMapUsers");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMapUsers_MeetingId_UserId",
                table: "MeetingMapUsers",
                columns: new[] { "MeetingId", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingMapUsers_MeetingId_UserId",
                table: "MeetingMapUsers");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMapUsers_MeetingId",
                table: "MeetingMapUsers",
                column: "MeetingId");
        }
    }
}
