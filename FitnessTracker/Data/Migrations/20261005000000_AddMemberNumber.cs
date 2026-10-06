using FitnessTracker.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20261005000000_AddMemberNumber")]
    public partial class AddMemberNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberNumber",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            // Backfill existing users with 1001, 1002, ...
            migrationBuilder.Sql(
                "UPDATE AspNetUsers SET MemberNumber = 1000 + (SELECT COUNT(*) FROM AspNetUsers u2 WHERE u2.rowid <= AspNetUsers.rowid);");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MemberNumber",
                table: "AspNetUsers",
                column: "MemberNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MemberNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MemberNumber",
                table: "AspNetUsers");
        }
    }
}
