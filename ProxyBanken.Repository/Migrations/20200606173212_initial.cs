using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProxyBanken.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TestUrl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUrl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proxy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
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
                    ProxyId = table.Column<int>(nullable: true),
                    TestUrlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProxyTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProxyTest_Proxy_ProxyId",
                        column: x => x.ProxyId,
                        principalTable: "Proxy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProxyTest_TestUrl_TestUrlId",
                        column: x => x.TestUrlId,
                        principalTable: "TestUrl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proxy_BaseUrlId",
                table: "Proxy",
                column: "BaseUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_ProxyId",
                table: "ProxyTest",
                column: "ProxyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProxyTest_TestUrlId",
                table: "ProxyTest",
                column: "TestUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProxyTest");

            migrationBuilder.DropTable(
                name: "Proxy");

            migrationBuilder.DropTable(
                name: "TestUrl");

            migrationBuilder.DropTable(
                name: "ProxyProvider");
        }
    }
}
