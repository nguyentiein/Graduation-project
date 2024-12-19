using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPM.Core.Migrations
{
    public partial class update_relation_userRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_User_role");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblPreproduction_segment",
                type: "longtext",
                maxLength: 4000,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "tbl_Video",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "tbl_User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "verificationCode",
                table: "tbl_User",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tbl_User",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbl_User",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "tbl_User",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "tbl_User",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "tbl_User",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_RoleId",
                table: "tbl_User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User",
                table: "tbl_User",
                column: "RoleId",
                principalTable: "TBL_Role",
                principalColumn: "Role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_User",
                table: "tbl_User");

            migrationBuilder.DropIndex(
                name: "IX_tbl_User_RoleId",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblPreproduction_segment");

            migrationBuilder.DropColumn(
                name: "No",
                table: "tbl_Video");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "verificationCode",
                table: "tbl_User");

            migrationBuilder.CreateTable(
                name: "TBL_User_role",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_User_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_TBL_User_role_TBL_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "TBL_Role",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_User_role_tbl_User_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TBL_User_role",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 2 },
                    { 2, 3 },
                    { 4, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_User_role_role_id",
                table: "TBL_User_role",
                column: "role_id");
        }
    }
}
