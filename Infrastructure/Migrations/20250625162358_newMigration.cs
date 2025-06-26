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
                name: "ContentType",
                columns: table => new
                {
                    IdContentType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTypeName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentType", x => x.IdContentType);
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
                name: "Slides",
                columns: table => new
                {
                    IdSlide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPresentation = table.Column<int>(type: "int", nullable: false),
                    IdContentType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asks",
                columns: table => new
                {
                    IdAsk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AskText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSlide = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asks", x => x.IdAsk);
                    table.ForeignKey(
                        name: "FK_asks_Slides_IdSlide",
                        column: x => x.IdSlide,
                        principalTable: "Slides",
                        principalColumn: "IdSlide",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentTypeSlide",
                columns: table => new
                {
                    ContentTypesIdContentType = table.Column<int>(type: "int", nullable: false),
                    slidesIdSlide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTypeSlide", x => new { x.ContentTypesIdContentType, x.slidesIdSlide });
                    table.ForeignKey(
                        name: "FK_ContentTypeSlide_ContentType_ContentTypesIdContentType",
                        column: x => x.ContentTypesIdContentType,
                        principalTable: "ContentType",
                        principalColumn: "IdContentType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentTypeSlide_Slides_slidesIdSlide",
                        column: x => x.slidesIdSlide,
                        principalTable: "Slides",
                        principalColumn: "IdSlide",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    IdOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IdAsk = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.IdOption);
                    table.ForeignKey(
                        name: "FK_options_asks_IdAsk",
                        column: x => x.IdAsk,
                        principalTable: "asks",
                        principalColumn: "IdAsk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContentType",
                columns: new[] { "IdContentType", "ContentTypeName" },
                values: new object[,]
                {
                    { 1, "Texto" },
                    { 2, "Imagen" },
                    { 4, "Pregunta" }
                });

            migrationBuilder.InsertData(
                table: "Presentations",
                columns: new[] { "IdPresentation", "ActivityStatus", "CreatedAt", "IdUserCreat", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Presentacion de prueba completa" },
                    { 2, true, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michidemo full" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "IdSlide", "BackgroundColor", "Content", "CreateAt", "IdContentType", "IdPresentation", "ModifiedAt", "Position", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "black", "Descripcion de imagen", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Michidemo Slides (pos 1)", "https://i.pinimg.com/474x/f6/c4/de/f6c4dea389511b32e9688b108e78fe4c.jpg" },
                    { 2, "black", null, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Michidemo Slides (pos 2)", "https://i.pinimg.com/474x/c2/6e/9a/c26e9ad4e2125917d5965700e2a87635.jpg" },
                    { 3, "black", "Descripcion de imagen", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Michidemo Slides (pos 3)", "https://i.pinimg.com/474x/34/a2/33/34a2331d5748b45f3b1ca5de1fda77a8.jpg" },
                    { 4, "black", null, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Michidemo Slides (pos 4)", "https://i.pinimg.com/474x/7a/e1/cf/7ae1cfe11811aa7ae62a375d59247cd1.jpg" },
                    { 5, "black", null, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Michidemo Slides (pos 6)", "https://i.pinimg.com/474x/6f/ee/72/6fee72bad31ef67ddceb000a22836538.jpg" },
                    { 6, "black", "Descripcion de imagen", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Michidemo Slides (pos 5)", "https://i.pinimg.com/474x/9c/89/66/9c8966f0b1e1062367310236244b45e9.jpg" },
                    { 7, "#FFFFFF", "Este es el texto introductorio de la presentacion", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Primer Slide (pos 1)", "https://ejemplo.com/slide1" },
                    { 8, "#FFEEAA", "bla bla bla ....", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Segundo Slide (pos 2)", "https://ejemplo.com/slide2" },
                    { 9, "#DDEEFF", "Fin de la presentacion. Muchas gracias.", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Tercer Slide (pos 3)", "https://ejemplo.com/slide3" },
                    { 10, "#FFFFFF", "Este es el texto introductorio de la presentacion", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Pregunta 1 (pos 5)", "https://ejemplo.com/slide1" },
                    { 11, "#FFEEAA", "bla bla bla ....", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pregunta 2 (pos 6)", "https://ejemplo.com/slide2" },
                    { 12, "#DDEEFF", "Fin de la presentacion. Muchas gracias.", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Pregunta 3 (pos 4)", "https://ejemplo.com/slide3" }
                });

            migrationBuilder.InsertData(
                table: "asks",
                columns: new[] { "IdAsk", "AskText", "CreatedAt", "Description", "IdSlide", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, "¿Cuál es la capital de Francia?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta sencilla", 10, null, "Pregunta Slide 1" },
                    { 2, "¿Cuál es el río más largo del mundo?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta sobre geografía", 11, null, "Pregunta Slide 2" },
                    { 3, "¿Cuál es el planeta más grande del Sistema Solar?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta general", 12, null, "Pregunta Slide 3" }
                });

            migrationBuilder.InsertData(
                table: "options",
                columns: new[] { "IdOption", "CreatedAt", "IdAsk", "IsCorrect", "ModifiedAt", "OptionText" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "París" },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Londres" },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madrid" },
                    { 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazonas" },
                    { 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nilo" },
                    { 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yangtsé" },
                    { 7, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturno" },
                    { 8, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Júpiter" },
                    { 9, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neptuno" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_asks_IdSlide",
                table: "asks",
                column: "IdSlide",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentTypeSlide_slidesIdSlide",
                table: "ContentTypeSlide",
                column: "slidesIdSlide");

            migrationBuilder.CreateIndex(
                name: "IX_options_IdAsk",
                table: "options",
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
                name: "ContentTypeSlide");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "ContentType");

            migrationBuilder.DropTable(
                name: "asks");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Presentations");
        }
    }
}
