using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _2020062501 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ResponseTime",
                table: "ProxyTest",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "ProxyTest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "ProxyTest");

            migrationBuilder.AlterColumn<int>(
                name: "ResponseTime",
                table: "ProxyTest",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
