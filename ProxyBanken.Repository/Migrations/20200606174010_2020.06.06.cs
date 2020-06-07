using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProxyBanken.Repository.Migrations
{
    public partial class _20200606 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastSuccessDate",
                table: "ProxyTest",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastSuccessDate",
                table: "ProxyTest",
                type: "datetime2",
                nullable: false);
        }
    }
}
