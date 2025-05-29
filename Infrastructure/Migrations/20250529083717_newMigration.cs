using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
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
                    IdAsk = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "IdAsk");
                });

            migrationBuilder.InsertData(
                table: "ContentTypes",
                columns: new[] { "IdContentType", "ContentTypeName", "CreatedAt", "ModifiedAt", "url" },
                values: new object[,]
                {
                    { 1, "Texto", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "text-content" },
                    { 2, "Imagen", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "image-content" },
                    { 3, "Video", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "video-content" },
                    { 4, "Pregunta", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "question-content" }
                });

            migrationBuilder.InsertData(
                table: "asks",
                columns: new[] { "IdAsk", "Answer", "AskText", "CreatedAt", "Description", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, "París", "¿Cuál es la capital de Francia?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta sobre geografía europea", null, "Capital de Francia" },
                    { 2, "París", "¿Cuál es la capital de Francia?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta sobre geografía europea", null, "Capital de Francia" },
                    { 3, "4", "¿Cuánto es 2 + 2?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta de aritmética simple", null, "Matemáticas básicas" },
                    { 4, "1492", "¿En qué año llegó Colón a América?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta sobre eventos históricos", null, "Historia universal" }
                });

            migrationBuilder.InsertData(
                table: "options",
                columns: new[] { "IdOption", "CreatedAt", "IdAsk", "ModifiedAt", "OptionText" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Madrid" },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "París" },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Berlín" },
                    { 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "3" },
                    { 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "4" },
                    { 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "5" },
                    { 7, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "1492" },
                    { 8, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "1501" },
                    { 9, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "1600" }
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
