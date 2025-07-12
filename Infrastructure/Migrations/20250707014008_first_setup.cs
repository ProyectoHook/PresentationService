using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first_setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    IdPresentation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
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
                name: "Slides",
                columns: table => new
                {
                    IdSlide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPresentation = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.IdSlide);
                    table.ForeignKey(
                        name: "FK_Slides_Presentations_IdPresentation",
                        column: x => x.IdPresentation,
                        principalTable: "Presentations",
                        principalColumn: "IdPresentation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asks",
                columns: table => new
                {
                    IdAsk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AskText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdSlide = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asks", x => x.IdAsk);
                    table.ForeignKey(
                        name: "FK_Asks_Slides_IdSlide",
                        column: x => x.IdSlide,
                        principalTable: "Slides",
                        principalColumn: "IdSlide",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    IdOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IdAsk = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.IdOption);
                    table.ForeignKey(
                        name: "FK_Options_Asks_IdAsk",
                        column: x => x.IdAsk,
                        principalTable: "Asks",
                        principalColumn: "IdAsk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Presentations",
                columns: new[] { "IdPresentation", "ActivityStatus", "CreatedAt", "IdUserCreat", "ModifiedAt", "Title" },
                values: new object[] { 1, true, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-2222-3333-4444-555555555555"), null, "Presentación SLIDE‑X" });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "IdSlide", "BackgroundColor", "Content", "CreateAt", "IdPresentation", "ModifiedAt", "Position", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "#FFFFFF", "¡Bienvenidos a SlideX!", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 0, "Portada", "https://i.ibb.co/VZKC6GW/1.jpg" },
                    { 2, "#FDE68A", "", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 1, "¿Cómo funciona?1", "https://i.ibb.co/bg8yWmgV/2.jpg" },
                    { 3, "#BFDBFE", "¿A quien está dirigido?", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 2, "Contenido", "https://i.ibb.co/35PGPbnC/3.jpg" },
                    { 4, "#FCA5A5", "", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 3, "Sobre nosotros", "https://i.ibb.co/ZpKkWjR5/4.jpg" },
                    { 5, "#D9F99D", "¡Gracias por participar!", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 4, "¡Fin!", "https://i.ibb.co/993nxTdF/5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Asks",
                columns: new[] { "IdAsk", "AskText", "CreatedAt", "Description", "IdSlide", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, "¿Para que sirve SLIDE-X?", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Que cosas son posibles con slide-x", 2, null, "Pregunta 1" },
                    { 2, "¿Cómo nos llamamos?", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Pregunta sobre nosotros", 4, null, "Preugunta 2" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "IdOption", "CreatedAt", "IdAsk", "IsCorrect", "ModifiedAt", "OptionText" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, true, null, "Para hacer presentaciones en vivo" },
                    { 2, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, "Para hacer llamadas online" },
                    { 3, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, "Chat virtual" },
                    { 4, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, "Para jugar en linea" },
                    { 5, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, true, null, "Ctrl c + Ctrl v" },
                    { 6, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, null, "GPTECH" },
                    { 7, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, null, "ChatGptLovers" },
                    { 8, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, false, null, "PlotTECH" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asks_IdSlide",
                table: "Asks",
                column: "IdSlide",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_IdAsk",
                table: "Options",
                column: "IdAsk");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_IdPresentation",
                table: "Slides",
                column: "IdPresentation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Asks");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Presentations");
        }
    }
}
