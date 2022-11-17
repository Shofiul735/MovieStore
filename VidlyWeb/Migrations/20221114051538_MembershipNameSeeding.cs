using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyWeb.Migrations
{
    /// <inheritdoc />
    public partial class MembershipNameSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipTypes SET MembershipTypeName='As per as go' WHERE Id=1");
            migrationBuilder.Sql("UPDATE MembershipTypes SET MembershipTypeName='Monthly' WHERE Id=2");
            migrationBuilder.Sql("UPDATE MembershipTypes SET MembershipTypeName='Quarterly' WHERE Id=3");
            migrationBuilder.Sql("UPDATE MembershipTypes SET MembershipTypeName='Yearly' WHERE Id=4");
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
