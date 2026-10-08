using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infarstructure.DataBase.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Barnds_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Barnds_BrandId1",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Barnds_BrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barnds",
                table: "Barnds");

            migrationBuilder.RenameTable(
                name: "Barnds",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId1",
                table: "Models",
                column: "BrandId1",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId1",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Barnds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barnds",
                table: "Barnds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Barnds_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Barnds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Barnds_BrandId1",
                table: "Models",
                column: "BrandId1",
                principalTable: "Barnds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Barnds_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Barnds",
                principalColumn: "Id");
        }
    }
}
