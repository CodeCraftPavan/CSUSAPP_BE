using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSUSAPP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class serviceStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sold_services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "sold_services");
        }
    }
}
