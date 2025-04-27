using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asks",
                columns: table => new
                {
                    IdAsk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    AskText = table.Column<string>(type: "varchar(100)", nullable: false),
                    Answer = table.Column<string>(type: "varchar(100)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asks", x => x.IdAsk);
                });

            migrationBuilder.CreateTable(
                name: "ContentTypes",
                columns: table => new
                {
                    IdContentType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTypeName = table.Column<string>(type: "varchar(50)", nullable: false),
                    url = table.Column<string>(type: "varchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTypes", x => x.IdContentType);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    IdPresentation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    ActivityStatus = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdUserCreat = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.IdPresentation);
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    IdOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdAsk = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.IdOption);
                    table.ForeignKey(
                        name: "FK_options_asks_IdAsk",
                        column: x => x.IdAsk,
                        principalTable: "asks",
                        principalColumn: "IdAsk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    IdSlide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPresentation = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    BackgroundColor = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdAsk = table.Column<int>(type: "int", nullable: false),
                    IdContentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.IdSlide);
                    table.ForeignKey(
                        name: "FK_Slides_ContentTypes_IdContentType",
                        column: x => x.IdContentType,
                        principalTable: "ContentTypes",
                        principalColumn: "IdContentType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slides_Presentations_IdPresentation",
                        column: x => x.IdPresentation,
                        principalTable: "Presentations",
                        principalColumn: "IdPresentation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slides_asks_IdAsk",
                        column: x => x.IdAsk,
                        principalTable: "asks",
                        principalColumn: "IdAsk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_options_IdAsk",
                table: "options",
                column: "IdAsk");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_IdAsk",
                table: "Slides",
                column: "IdAsk");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_IdContentType",
                table: "Slides",
                column: "IdContentType");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_IdPresentation",
                table: "Slides",
                column: "IdPresentation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "ContentTypes");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "asks");
        }
    }
}
