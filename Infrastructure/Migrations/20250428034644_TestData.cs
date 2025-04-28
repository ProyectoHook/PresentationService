using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Presentations_IdPresentation",
                table: "Slides");

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
                    { 2, "4", "¿Cuánto es 2 + 2?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta de aritmética simple", null, "Matemáticas básicas" },
                    { 3, "1492", "¿En qué año llegó Colón a América?", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregunta sobre eventos históricos", null, "Historia universal" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Presentations_IdPresentation",
                table: "Slides",
                column: "IdPresentation",
                principalTable: "Presentations",
                principalColumn: "IdPresentation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Presentations_IdPresentation",
                table: "Slides");

            migrationBuilder.DeleteData(
                table: "ContentTypes",
                keyColumn: "IdContentType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContentTypes",
                keyColumn: "IdContentType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContentTypes",
                keyColumn: "IdContentType",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContentTypes",
                keyColumn: "IdContentType",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "options",
                keyColumn: "IdOption",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "asks",
                keyColumn: "IdAsk",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "asks",
                keyColumn: "IdAsk",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "asks",
                keyColumn: "IdAsk",
                keyValue: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Presentations_IdPresentation",
                table: "Slides",
                column: "IdPresentation",
                principalTable: "Presentations",
                principalColumn: "IdPresentation",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
