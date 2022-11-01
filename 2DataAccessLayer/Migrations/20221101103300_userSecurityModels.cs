using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2DataAccessLayer.Migrations
{
    public partial class userSecurityModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemActions",
                columns: table => new
                {
                    SystemActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemActions", x => x.SystemActionID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserAccountID);
                });

            migrationBuilder.CreateTable(
                name: "SystemActionUserAccount",
                columns: table => new
                {
                    SystemActionsSystemActionID = table.Column<int>(type: "int", nullable: false),
                    UserAccountsUserAccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemActionUserAccount", x => new { x.SystemActionsSystemActionID, x.UserAccountsUserAccountID });
                    table.ForeignKey(
                        name: "FK_SystemActionUserAccount_SystemActions_SystemActionsSystemActionID",
                        column: x => x.SystemActionsSystemActionID,
                        principalTable: "SystemActions",
                        principalColumn: "SystemActionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemActionUserAccount_UserAccounts_UserAccountsUserAccountID",
                        column: x => x.UserAccountsUserAccountID,
                        principalTable: "UserAccounts",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemActionUserAccount_UserAccountsUserAccountID",
                table: "SystemActionUserAccount",
                column: "UserAccountsUserAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemActionUserAccount");

            migrationBuilder.DropTable(
                name: "SystemActions");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
