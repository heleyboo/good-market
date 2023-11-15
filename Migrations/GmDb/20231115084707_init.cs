using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoodMarket.Migrations.GmDb
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrative_regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    name_en = table.Column<string>(type: "varchar", nullable: false),
                    code_name = table.Column<string>(type: "varchar", nullable: false),
                    code_name_en = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "administrative_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "varchar", nullable: false),
                    full_name_en = table.Column<string>(type: "varchar", nullable: false),
                    short_name = table.Column<string>(type: "varchar", nullable: false),
                    short_name_en = table.Column<string>(type: "varchar", nullable: false),
                    code_name = table.Column<string>(type: "varchar", nullable: false),
                    code_name_en = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    name_en = table.Column<string>(type: "varchar", nullable: false),
                    full_name = table.Column<string>(type: "varchar", nullable: false),
                    full_name_en = table.Column<string>(type: "varchar", nullable: false),
                    code_name = table.Column<string>(type: "varchar", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "integer", nullable: false),
                    administrative_region_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.code);
                    table.ForeignKey(
                        name: "FK_provinces_administrative_regions_administrative_region_id",
                        column: x => x.administrative_region_id,
                        principalTable: "administrative_regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_provinces_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: true),
                    FormId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Placeholder = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ApiUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FormId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormFields_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    name_en = table.Column<string>(type: "varchar", nullable: false),
                    full_name = table.Column<string>(type: "varchar", nullable: false),
                    full_name_en = table.Column<string>(type: "varchar", nullable: false),
                    code_name = table.Column<string>(type: "varchar", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "integer", nullable: false),
                    province_code = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.code);
                    table.ForeignKey(
                        name: "FK_districts_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_districts_provinces_province_code",
                        column: x => x.province_code,
                        principalTable: "provinces",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wards",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    name_en = table.Column<string>(type: "varchar", nullable: false),
                    full_name = table.Column<string>(type: "varchar", nullable: false),
                    full_name_en = table.Column<string>(type: "varchar", nullable: false),
                    code_name = table.Column<string>(type: "varchar", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "integer", nullable: false),
                    district_code = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wards", x => x.code);
                    table.ForeignKey(
                        name: "FK_wards_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wards_districts_district_code",
                        column: x => x.district_code,
                        principalTable: "districts",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FormId",
                table: "Categories",
                column: "FormId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_administrative_unit_id",
                table: "districts",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_province_code",
                table: "districts",
                column: "province_code");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_FormId",
                table: "FormFields",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_region_id",
                table: "provinces",
                column: "administrative_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_unit_id",
                table: "provinces",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_wards_administrative_unit_id",
                table: "wards",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_wards_district_code",
                table: "wards",
                column: "district_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "wards");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "administrative_regions");

            migrationBuilder.DropTable(
                name: "administrative_units");
        }
    }
}
