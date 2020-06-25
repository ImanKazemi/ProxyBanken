using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _20200625 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseTime",
                table: "ProxyTest",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.InsertData(
                table: "ProxyTestServer",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 2, "Bing", "https://www.bing.com" });

            migrationBuilder.InsertData(
                table: "ProxyTestServer",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 3, "Duck Duck Go", "https://duckduckgo.com/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProxyTestServer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProxyTestServer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProxyTestServer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ResponseTime",
                table: "ProxyTest");
        }
    }
}
