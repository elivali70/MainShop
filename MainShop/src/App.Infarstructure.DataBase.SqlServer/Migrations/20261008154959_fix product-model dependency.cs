using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infarstructure.DataBase.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class fixproductmodeldependency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "ProductFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "FileTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Models",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Products_ProductId",
                table: "Models",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Products_ProductId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "ProductFiles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FileTypes");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }
    }
}
