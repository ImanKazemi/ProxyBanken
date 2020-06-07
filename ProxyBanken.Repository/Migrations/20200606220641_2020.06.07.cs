using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _20200607 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_Proxy_ProxyId",
                table: "ProxyTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_ProxyTestUrl_ProxyTestUrlId",
                table: "ProxyTest");

            migrationBuilder.AlterColumn<int>(
                name: "ProxyTestUrlId",
                table: "ProxyTest",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProxyId",
                table: "ProxyTest",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_Proxy_ProxyId",
                table: "ProxyTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProxyTest_ProxyTestUrl_ProxyTestUrlId",
                table: "ProxyTest");

            migrationBuilder.AlterColumn<int>(
                name: "ProxyTestUrlId",
                table: "ProxyTest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProxyId",
                table: "ProxyTest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProxyTest_Proxy_ProxyId",
                table: "ProxyTest",
                column: "ProxyId",
                principalTable: "Proxy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProxyTest_ProxyTestUrl_ProxyTestUrlId",
                table: "ProxyTest",
                column: "ProxyTestUrlId",
                principalTable: "ProxyTestUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
