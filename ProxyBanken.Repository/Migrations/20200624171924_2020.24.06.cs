using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _20202406 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_ProxyTestUrl_ProxyTestUrlId",
                table: "ProxyTest");

            migrationBuilder.DropTable(
                name: "ProxyTestUrl");

            migrationBuilder.DropIndex(
                name: "IX_ProxyTest_ProxyTestUrlId",
                table: "ProxyTest");

            migrationBuilder.DropColumn(
                name: "ProxyTestUrlId",
                table: "ProxyTest");

            migrationBuilder.AddColumn<int>(
                name: "ProxyTestServerId",
                table: "ProxyTest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProxyTestServer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProxyTestServer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyTestServerId",
                table: "ProxyTest",
                column: "ProxyTestServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProxyTest_ProxyTestServer_ProxyTestServerId",
                table: "ProxyTest",
                column: "ProxyTestServerId",
                principalTable: "ProxyTestServer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_ProxyTestServer_ProxyTestServerId",
                table: "ProxyTest");

            migrationBuilder.DropTable(
                name: "ProxyTestServer");

            migrationBuilder.DropIndex(
                name: "IX_ProxyTest_ProxyTestServerId",
                table: "ProxyTest");

            migrationBuilder.DropColumn(
                name: "ProxyTestServerId",
                table: "ProxyTest");

            migrationBuilder.AddColumn<int>(
                name: "ProxyTestUrlId",
                table: "ProxyTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProxyTestUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProxyTestUrl", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyTestUrlId",
                table: "ProxyTest",
                column: "ProxyTestUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProxyTest_ProxyTestUrl_ProxyTestUrlId",
                table: "ProxyTest",
                column: "ProxyTestUrlId",
                principalTable: "ProxyTestUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
