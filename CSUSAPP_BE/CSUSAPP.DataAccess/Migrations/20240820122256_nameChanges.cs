using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSUSAPP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersData",
                table: "UsersData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.RenameTable(
                name: "UsersData",
                newName: "user_details");

            migrationBuilder.RenameTable(
                name: "LoginDetails",
                newName: "session_info");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_details",
                newName: "ExtUserId");

            migrationBuilder.RenameColumn(
                name: "LogInId",
                table: "session_info",
                newName: "ExtLogInId");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "user_details",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "session_info",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_details",
                table: "user_details",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_session_info",
                table: "session_info",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_details",
                table: "user_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_session_info",
                table: "session_info");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "user_details");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "session_info");

            migrationBuilder.RenameTable(
                name: "user_details",
                newName: "UsersData");

            migrationBuilder.RenameTable(
                name: "session_info",
                newName: "LoginDetails");

            migrationBuilder.RenameColumn(
                name: "ExtUserId",
                table: "UsersData",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ExtLogInId",
                table: "LoginDetails",
                newName: "LogInId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersData",
                table: "UsersData",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "LogInId");
        }
    }
}
