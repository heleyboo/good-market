﻿// <auto-generated />
using System;
using GoodMarket.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoodMarket.Migrations.GmDb
{
    [DbContext(typeof(GmDbContext))]
    [Migration("20231115084707_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoodMarket.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FormId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("FormId")
                        .IsUnique();

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Forms", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.FormField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApiUrl")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("FormId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Label")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Placeholder")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormFields", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name");

                    b.Property<string>("CodeNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name_en");

                    b.HasKey("Id");

                    b.ToTable("administrative_regions", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name");

                    b.Property<string>("CodeNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name_en");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name_en");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("short_name");

                    b.Property<string>("ShortNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("short_name_en");

                    b.HasKey("Id");

                    b.ToTable("administrative_units", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.District", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar")
                        .HasColumnName("code");

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_unit_id");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name_en");

                    b.Property<string>("ProvinceCode")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("province_code");

                    b.HasKey("Code");

                    b.HasIndex("AdministrativeUnitId");

                    b.HasIndex("ProvinceCode");

                    b.ToTable("districts", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.Province", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar")
                        .HasColumnName("code");

                    b.Property<int>("AdministrativeRegionId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_region_id");

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_unit_id");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name_en");

                    b.HasKey("Code");

                    b.HasIndex("AdministrativeRegionId");

                    b.HasIndex("AdministrativeUnitId");

                    b.ToTable("provinces", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.Ward", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar")
                        .HasColumnName("code");

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("administrative_unit_id");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("code_name");

                    b.Property<string>("DistrictCode")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("district_code");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name_en");

                    b.HasKey("Code");

                    b.HasIndex("AdministrativeUnitId");

                    b.HasIndex("DistrictCode");

                    b.ToTable("wards", (string)null);
                });

            modelBuilder.Entity("GoodMarket.Models.Category", b =>
                {
                    b.HasOne("GoodMarket.Models.Form", "Form")
                        .WithOne("Category")
                        .HasForeignKey("GoodMarket.Models.Category", "FormId");

                    b.HasOne("GoodMarket.Models.Category", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("Form");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("GoodMarket.Models.FormField", b =>
                {
                    b.HasOne("GoodMarket.Models.Form", "Form")
                        .WithMany("FormFields")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.District", b =>
                {
                    b.HasOne("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany("Districts")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodMarket.Models.VietnameseAdministrativeUnits.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdministrativeUnit");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.Province", b =>
                {
                    b.HasOne("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeRegion", "AdministrativeRegion")
                        .WithMany("Provinces")
                        .HasForeignKey("AdministrativeRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany("Provinces")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdministrativeRegion");

                    b.Navigation("AdministrativeUnit");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.Ward", b =>
                {
                    b.HasOne("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany("Wards")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodMarket.Models.VietnameseAdministrativeUnits.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdministrativeUnit");

                    b.Navigation("District");
                });

            modelBuilder.Entity("GoodMarket.Models.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("GoodMarket.Models.Form", b =>
                {
                    b.Navigation("Category")
                        .IsRequired();

                    b.Navigation("FormFields");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeRegion", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.AdministrativeUnit", b =>
                {
                    b.Navigation("Districts");

                    b.Navigation("Provinces");

                    b.Navigation("Wards");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.District", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("GoodMarket.Models.VietnameseAdministrativeUnits.Province", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}