using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roulette.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payouts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpinId = table.Column<long>(type: "INTEGER", nullable: false),
                    Wager = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpinResultNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StraightBets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlacedBet = table.Column<int>(type: "INTEGER", nullable: false),
                    SpinEntityId = table.Column<long>(type: "INTEGER", nullable: true),
                    SpinId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    Wager = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StraightBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StraightBets_Spins_SpinEntityId",
                        column: x => x.SpinEntityId,
                        principalTable: "Spins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StraightBets_SpinEntityId",
                table: "StraightBets",
                column: "SpinEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payouts");

            migrationBuilder.DropTable(
                name: "StraightBets");

            migrationBuilder.DropTable(
                name: "Spins");
        }
    }
}
