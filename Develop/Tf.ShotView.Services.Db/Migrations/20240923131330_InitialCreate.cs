using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tf.ShotView.Services.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawShots",
                columns: table => new
                {
                    ShootId = table.Column<string>(type: "TEXT", nullable: false),
                    PasseId = table.Column<string>(type: "TEXT", nullable: false),
                    Anlage = table.Column<string>(type: "TEXT", nullable: true),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    StartNr = table.Column<int>(type: "INTEGER", nullable: false),
                    PrimaryScore = table.Column<double>(type: "REAL", nullable: false),
                    Schussart = table.Column<int>(type: "INTEGER", nullable: false),
                    BahnNr = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondaryScore = table.Column<double>(type: "REAL", nullable: false),
                    Teiler = table.Column<int>(type: "INTEGER", nullable: false),
                    Zeit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Mouche = table.Column<int>(type: "INTEGER", nullable: false),
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false),
                    InTime = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeSinceChange = table.Column<double>(type: "REAL", nullable: false),
                    SweepDirection = table.Column<int>(type: "INTEGER", nullable: false),
                    Demonstration = table.Column<int>(type: "INTEGER", nullable: false),
                    Match = table.Column<int>(type: "INTEGER", nullable: false),
                    Stich = table.Column<int>(type: "INTEGER", nullable: false),
                    InsDel = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalArt = table.Column<int>(type: "INTEGER", nullable: false),
                    Gruppe = table.Column<int>(type: "INTEGER", nullable: false),
                    Feuerart = table.Column<int>(type: "INTEGER", nullable: false),
                    LogEvent = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTyp = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStamp = table.Column<long>(type: "INTEGER", nullable: false),
                    Ablösung = table.Column<int>(type: "INTEGER", nullable: false),
                    Waffe = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    TargetID = table.Column<string>(type: "TEXT", nullable: true),
                    ExterneNummer = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawShots", x => x.ShootId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawShots");
        }
    }
}
