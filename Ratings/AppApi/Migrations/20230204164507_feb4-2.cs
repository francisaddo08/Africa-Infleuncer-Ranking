using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppApi.Migrations
{
    /// <inheritdoc />
    public partial class feb42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ISInstagram",
                table: "Influencer",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFaceBook",
                table: "Influencer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTwitter",
                table: "Influencer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsYouTube",
                table: "Influencer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Twitter_InfluencerId",
                table: "Twitter",
                column: "InfluencerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Twitter_Influencer_InfluencerId",
                table: "Twitter",
                column: "InfluencerId",
                principalTable: "Influencer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Twitter_Influencer_InfluencerId",
                table: "Twitter");

            migrationBuilder.DropIndex(
                name: "IX_Twitter_InfluencerId",
                table: "Twitter");

            migrationBuilder.DropColumn(
                name: "ISInstagram",
                table: "Influencer");

            migrationBuilder.DropColumn(
                name: "IsFaceBook",
                table: "Influencer");

            migrationBuilder.DropColumn(
                name: "IsTwitter",
                table: "Influencer");

            migrationBuilder.DropColumn(
                name: "IsYouTube",
                table: "Influencer");
        }
    }
}
