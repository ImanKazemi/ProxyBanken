using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _2020060601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_TestUrl_TestUrlId",
                table: "ProxyTest");

            migrationBuilder.DropTable(
                name: "TestUrl");

            migrationBuilder.DropIndex(
                name: "IX_ProxyTest_TestUrlId",
                table: "ProxyTest");

            migrationBuilder.DropColumn(
                name: "TestUrlId",
                table: "ProxyTest");

            migrationBuilder.AddColumn<int>(
                name: "ProxyTestUrlId",
                table: "ProxyTest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProxyTestUrl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TestUrlId",
                table: "ProxyTest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUrl", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_TestUrlId",
                table: "ProxyTest",
                column: "TestUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProxyTest_TestUrl_TestUrlId",
                table: "ProxyTest",
                column: "TestUrlId",
                principalTable: "TestUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
