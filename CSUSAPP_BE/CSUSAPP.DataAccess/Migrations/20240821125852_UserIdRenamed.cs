using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSUSAPP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserIdRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_details",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_details",
                newName: "Id");
        }
    }
}
