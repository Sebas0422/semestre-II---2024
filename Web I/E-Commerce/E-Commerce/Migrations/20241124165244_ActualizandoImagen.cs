using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class ActualizandoImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordes_Articles_ArticlesId",
                table: "Ordes");

            migrationBuilder.DropIndex(
                name: "IX_Ordes_ArticlesId",
                table: "Ordes");

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Path = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Temporal = table.Column<bool>(type: "bit", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImagenId",
                table: "Articles",
                column: "ImagenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImagenId",
                table: "Articles",
                column: "ImagenId",
                principalTable: "Images",
                principalColumn: "ImagenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImagenId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ImagenId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "Articles");

            migrationBuilder.CreateIndex(
                name: "IX_Ordes_ArticlesId",
                table: "Ordes",
                column: "ArticlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordes_Articles_ArticlesId",
                table: "Ordes",
                column: "ArticlesId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
