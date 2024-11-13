using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppApi.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Influencer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Influencer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluencerId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoundsNELat = table.Column<double>(type: "float", nullable: true),
                    BoundsNELong = table.Column<double>(type: "float", nullable: true),
                    BoundsSWLat = table.Column<double>(type: "float", nullable: true),
                    BoundSWLong = table.Column<double>(type: "float", nullable: true),
                    ViewPortNELat = table.Column<double>(type: "float", nullable: true),
                    ViewPortNELong = table.Column<double>(type: "float", nullable: true),
                    ViewPortSWLat = table.Column<double>(type: "float", nullable: true),
                    ViewPortSWLong = table.Column<double>(type: "float", nullable: true),
                    LocationLat = table.Column<double>(type: "float", nullable: true),
                    LocationLong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Influencer_InfluencerId",
                        column: x => x.InfluencerId,
                        principalTable: "Influencer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluencerId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoundsNELat = table.Column<double>(type: "float", nullable: true),
                    BoundsNELong = table.Column<double>(type: "float", nullable: true),
                    BoundsSWLat = table.Column<double>(type: "float", nullable: true),
                    BoundSWLong = table.Column<double>(type: "float", nullable: true),
                    ViewPortNELat = table.Column<double>(type: "float", nullable: true),
                    ViewPortNELong = table.Column<double>(type: "float", nullable: true),
                    ViewPortSWLat = table.Column<double>(type: "float", nullable: true),
                    ViewPortSWLong = table.Column<double>(type: "float", nullable: true),
                    LocationLat = table.Column<double>(type: "float", nullable: true),
                    LocationLong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Influencer_InfluencerId",
                        column: x => x.InfluencerId,
                        principalTable: "Influencer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaceBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluencerId = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<long>(type: "bigint", nullable: false),
                    TalkingAbout = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceBook_Influencer_InfluencerId",
                        column: x => x.InfluencerId,
                        principalTable: "Influencer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instagram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluencerId = table.Column<int>(type: "int", nullable: false),
                    Followers = table.Column<long>(type: "bigint", nullable: true),
                    EngagementRate = table.Column<double>(type: "float", nullable: true),
                    AverageLikes = table.Column<long>(type: "bigint", nullable: true),
                    AverageComments = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instagram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instagram_Influencer_InfluencerId",
                        column: x => x.InfluencerId,
                        principalTable: "Influencer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YouTube",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluencerId = table.Column<int>(type: "int", nullable: false),
                    Subscribers = table.Column<long>(type: "bigint", nullable: false),
                    Views = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YouTube", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YouTube_Influencer_InfluencerId",
                        column: x => x.InfluencerId,
                        principalTable: "Influencer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_InfluencerId",
                table: "City",
                column: "InfluencerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_InfluencerId",
                table: "Country",
                column: "InfluencerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaceBook_InfluencerId",
                table: "FaceBook",
                column: "InfluencerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instagram_InfluencerId",
                table: "Instagram",
                column: "InfluencerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YouTube_InfluencerId",
                table: "YouTube",
                column: "InfluencerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "FaceBook");

            migrationBuilder.DropTable(
                name: "Instagram");

            migrationBuilder.DropTable(
                name: "YouTube");

            migrationBuilder.DropTable(
                name: "Influencer");
        }
    }
}
