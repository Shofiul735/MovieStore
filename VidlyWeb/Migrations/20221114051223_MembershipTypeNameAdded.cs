using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyWeb.Migrations
{
    /// <inheritdoc />
    public partial class MembershipTypeNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MembershipTypeName",
                table: "MembershipTypes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipTypeName",
                table: "MembershipTypes");
        }
    }
}
