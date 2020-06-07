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
    [Migration("20200606182719_2020.06.06-01")]
    partial class _2020060601
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.Proxy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BaseUrlId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastFunctionalityTestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseUrlId");

                    b.ToTable("Proxy");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("LastSuccessDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProxyId")
                        .HasColumnType("int");

                    b.Property<int?>("ProxyTestUrlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProxyId");

                    b.HasIndex("ProxyTestUrlId");

                    b.ToTable("ProxyTest");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyTestUrl", b =>
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

                    b.ToTable("ProxyTestUrl");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Map.ProxyProvider", b =>
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
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.Proxy", b =>
                {
                    b.HasOne("ProxyBanken.DataAccess.Map.ProxyProvider", "BaseUrl")
                        .WithMany("Proxies")
                        .HasForeignKey("BaseUrlId");
                });

            modelBuilder.Entity("ProxyBanken.DataAccess.Entity.ProxyTest", b =>
                {
                    b.HasOne("ProxyBanken.DataAccess.Entity.Proxy", "Proxy")
                        .WithMany()
                        .HasForeignKey("ProxyId");

                    b.HasOne("ProxyBanken.DataAccess.Entity.ProxyTestUrl", "ProxyTestUrl")
                        .WithMany()
                        .HasForeignKey("ProxyTestUrlId");
                });
#pragma warning restore 612, 618
        }
    }
}
