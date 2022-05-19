using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintedMedia.Migrations
{
    public partial class newUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "733e10a2-0d56-4272-9e0f-032b301ba0e0", 0, "3b5c5926-66f8-403f-a197-8c2d6cfe5c38", "admin@gmail.com", true, "Bob", "Hope", false, null, null, null, "AQAAAAEAACcQAAAAEOY7RFcOPNCSdA5F+60yQ8BvSS+DKag05iEN76uXEvMdNsCDzr+1rB6HVJXYzRuLUw==", null, false, "23aca608-866d-4ad5-9624-c005d709af32", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "733e10a2-0d56-4272-9e0f-032b301ba0e0");
        }
    }
}
