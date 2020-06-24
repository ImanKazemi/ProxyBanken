﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProxyBanken.Repository;

namespace ProxyBanken.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200624171924_2020.24.06")]
    partial class _20202406
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique()
                        .HasFilter("[Key] IS NOT NULL");

                    b.ToTable("Config");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "ProxyUpdateInterval",
                            Value = "10"
                        },
                        new
                        {
                            Id = 2,
                            Key = "ProxyDeleteInterval",
                            Value = "7"
                        });
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.Proxy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anonymity")
                        .HasColumnType("int");

                    b.Property<int?>("BaseUrlId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastFunctionalityTestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseUrlId");

                    b.HasIndex("Ip", "Port")
                        .IsUnique()
                        .HasFilter("[Ip] IS NOT NULL");

                    b.ToTable("Proxy");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpQuery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastFetchOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastFetchProxyCount")
                        .HasColumnType("int");

                    b.Property<string>("PortQuery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RowQuery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProxyProvider");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IpQuery = "//td[1]",
                            PortQuery = "//td[2]",
                            RowQuery = "//table[@id='proxylisttable']/tbody/tr",
                            Url = "https://free-proxy-list.net/"
                        },
                        new
                        {
                            Id = 2,
                            IpQuery = "//td[1]/abbr/script",
                            PortQuery = "//td[2]",
                            RowQuery = "//table/tbody/tr[@data-proxy-id]",
                            Url = "https://www.proxynova.com/proxy-server-list/"
                        });
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("LastSuccessDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProxyId")
                        .HasColumnType("int");

                    b.Property<int>("ProxyTestServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProxyId");

                    b.HasIndex("ProxyTestServerId");

                    b.ToTable("ProxyTest");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyTestServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProxyTestServer");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.Proxy", b =>
                {
                    b.HasOne("ProxyBanken.DataAccess.Entity.ProxyProvider", "BaseUrl")
                        .WithMany("Proxies")
                        .HasForeignKey("BaseUrlId");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyTest", b =>
                {
                    b.HasOne("ProxyBanken.DataAccess.Entity.Proxy", "Proxy")
                        .WithMany()
                        .HasForeignKey("ProxyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProxyBanken.DataAccess.Entity.ProxyTestServer", "ProxyTestServer")
                        .WithMany()
                        .HasForeignKey("ProxyTestServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}