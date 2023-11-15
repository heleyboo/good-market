using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoodMarket.Migrations.GmDb
{
    /// <inheritdoc />
    public partial class attribute_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeGroupId = table.Column<int>(type: "integer", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    MaxCharacters = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    ValidationRegexp = table.Column<string>(type: "text", nullable: false),
                    WysiwygEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    NumberMin = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberMax = table.Column<decimal>(type: "numeric", nullable: false),
                    DecimalAllowed = table.Column<bool>(type: "boolean", nullable: false),
                    NegativeAllowed = table.Column<bool>(type: "boolean", nullable: false),
                    MinDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MaxDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MaxFileSize = table.Column<decimal>(type: "numeric", nullable: false),
                    AllowedExtensions = table.Column<string>(type: "text", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsUnique = table.Column<bool>(type: "boolean", nullable: false),
                    Placeholder = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    BackendType = table.Column<string>(type: "text", nullable: false),
                    Properties = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attribute_AttributeGroup_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    AttributeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOption_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryAttribute",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    AttributeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttribute", x => new { x.CategoryId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_CategoryAttribute_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryAttribute_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_AttributeGroupId",
                table: "Attribute",
                column: "AttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Code",
                table: "Attribute",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeGroup_Code",
                table: "AttributeGroup",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOption_AttributeId",
                table: "AttributeOption",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOption_Code",
                table: "AttributeOption",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttribute_AttributeId",
                table: "CategoryAttribute",
                column: "AttributeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeOption");

            migrationBuilder.DropTable(
                name: "CategoryAttribute");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "AttributeGroup");
        }
    }
}
