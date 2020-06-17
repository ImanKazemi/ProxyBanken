using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProxyProvider",
                columns: new[] { "Id", "Exception", "IpQuery", "LastFetchOn", "LastFetchProxyCount", "PortQuery", "RowQuery", "Url" },
                values: new object[] { 1, null, "//td[1]", null, null, "//td[2]", "//table[@id='proxylisttable']/tbody/tr", "https://free-proxy-list.net/" });

            migrationBuilder.InsertData(
                table: "ProxyProvider",
                columns: new[] { "Id", "Exception", "IpQuery", "LastFetchOn", "LastFetchProxyCount", "PortQuery", "RowQuery", "Url" },
                values: new object[] { 2, null, "//td[1]/abbr/script", null, null, "//td[2]", "//table/tbody/tr[@data-proxy-id]", "https://www.proxynova.com/proxy-server-list/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProxyProvider",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProxyProvider",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
