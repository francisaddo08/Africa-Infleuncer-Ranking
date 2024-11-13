using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppApi.Migrations
{
    /// <inheritdoc />
    public partial class feb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISInstagram",
                table: "Influencer",
                newName: "IsInstagram");

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "YouTube",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "Twitter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "Instagram",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Influencer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "FaceBook",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "YouTube");

            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "Twitter");

            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "Instagram");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Influencer");

            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "FaceBook");

            migrationBuilder.RenameColumn(
                name: "IsInstagram",
                table: "Influencer",
                newName: "ISInstagram");
        }
    }
}
