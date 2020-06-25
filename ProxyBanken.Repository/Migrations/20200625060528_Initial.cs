using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProxyProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    LastFetchOn = table.Column<DateTime>(nullable: true),
                    LastFetchProxyCount = table.Column<int>(nullable: true),
                    RowQuery = table.Column<string>(nullable: true),
                    IpQuery = table.Column<string>(nullable: true),
                    PortQuery = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProxyProvider", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Proxy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Anonymity = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LastFunctionalityTestDate = table.Column<DateTime>(nullable: true),
                    BaseUrlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proxy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proxy_ProxyProvider_BaseUrlId",
                        column: x => x.BaseUrlId,
                        principalTable: "ProxyProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProxyTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastSuccessDate = table.Column<DateTime>(nullable: true),
                    ProxyTestServerId = table.Column<int>(nullable: false),
                    ProxyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProxyTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProxyTest_Proxy_ProxyId",
                        column: x => x.ProxyId,
                        principalTable: "Proxy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProxyTest_ProxyTestServer_ProxyTestServerId",
                        column: x => x.ProxyTestServerId,
                        principalTable: "ProxyTestServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "ProxyUpdateInterval", "10" },
                    { 2, "ProxyDeleteInterval", "7" }
                });

            migrationBuilder.InsertData(
                table: "ProxyProvider",
                columns: new[] { "Id", "Exception", "IpQuery", "LastFetchOn", "LastFetchProxyCount", "PortQuery", "RowQuery", "Url" },
                values: new object[,]
                {
                    { 1, null, "//td[1]", null, null, "//td[2]", "//table[@id='proxylisttable']/tbody/tr", "https://free-proxy-list.net/" },
                    { 2, null, "//td[1]/abbr/script", null, null, "//td[2]", "//table/tbody/tr[@data-proxy-id]", "https://www.proxynova.com/proxy-server-list/" },
                    { 3, null, "//td[1]", null, null, "//td[2]", "//table/tbody/tr", "http://cn-proxy.com/archives/218" },
                    { 4, null, "//td[1]", null, null, "//td[2]", "//table/tbody/tr", "https://www.socks-proxy.net/" },
                    { 5, null, "//td[1]", null, null, "//td[3]", "(//div[contains(@class, 'table-responsive')])[2]/table/tbody/tr", "https://free-proxy-list.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Config_Key",
                table: "Config",
                column: "Key",
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Proxy_BaseUrlId",
                table: "Proxy",
                column: "BaseUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Proxy_Ip_Port",
                table: "Proxy",
                columns: new[] { "Ip", "Port" },
                unique: true,
                filter: "[Ip] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyId",
                table: "ProxyTest",
                column: "ProxyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyTestServerId",
                table: "ProxyTest",
                column: "ProxyTestServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "ProxyTest");

            migrationBuilder.DropTable(
                name: "Proxy");

            migrationBuilder.DropTable(
                name: "ProxyTestServer");

            migrationBuilder.DropTable(
                name: "ProxyProvider");
        }
    }
}
