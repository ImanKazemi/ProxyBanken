using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _2020060702 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_Proxy_ProxyId",
                table: "ProxyTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_ProxyTestUrl_ProxyTestUrlId",
                table: "ProxyTest");

            migrationBuilder.DropIndex(
                name: "IX_ProxyTest_ProxyId",
                table: "ProxyTest");

            migrationBuilder.DropIndex(
                name: "IX_ProxyTest_ProxyTestUrlId",
                table: "ProxyTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyId",
                table: "ProxyTest",
                column: "ProxyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyTestUrlId",
                table: "ProxyTest",
                column: "ProxyTestUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProxyTest_Proxy_ProxyId",
                table: "ProxyTest",
                column: "ProxyId",
                principalTable: "Proxy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
