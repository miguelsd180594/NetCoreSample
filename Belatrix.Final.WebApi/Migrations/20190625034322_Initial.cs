using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.Final.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("artist_id_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_name = table.Column<string>(maxLength: 20, nullable: false),
                    first_name = table.Column<string>(maxLength: 20, nullable: false),
                    title = table.Column<string>(maxLength: 30, nullable: true),
                    reports_to_id = table.Column<int>(nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    hire_date = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(maxLength: 70, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    state = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "employee__reference_employee__fkey",
                        column: x => x.reports_to_id,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre_id_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "media_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("media_type_id_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "playlist",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_id_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(maxLength: 160, nullable: true),
                    artist_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("album_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "album__reference_artist_id__fkey",
                        column: x => x.artist_id,
                        principalTable: "artist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 40, nullable: false),
                    last_name = table.Column<string>(maxLength: 20, nullable: false),
                    company = table.Column<string>(maxLength: 80, nullable: true),
                    address = table.Column<string>(maxLength: 70, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    state = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: false),
                    support_rep_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "customer__reference_employee__fkey",
                        column: x => x.support_rep_id,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "track",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: false),
                    composer = table.Column<string>(maxLength: 220, nullable: true),
                    milli_seconds = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    album_id = table.Column<int>(nullable: false),
                    media_type_id = table.Column<int>(nullable: false),
                    genre_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("track_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "track__reference_album_id_fkey",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "track__reference_genre_id_fkey",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "track__reference_media_type_id_fkey",
                        column: x => x.media_type_id,
                        principalTable: "media_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(nullable: false),
                    invoice_date = table.Column<DateTime>(type: "date", nullable: false),
                    billing_address = table.Column<string>(maxLength: 70, nullable: true),
                    billing_city = table.Column<string>(maxLength: 40, nullable: true),
                    billing_state = table.Column<string>(maxLength: 40, nullable: true),
                    billing_country = table.Column<string>(maxLength: 40, nullable: true),
                    billing_postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "invoice__reference_customer_id__fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlist_track",
                columns: table => new
                {
                    playlist_id = table.Column<int>(nullable: false),
                    track_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_track_id_pkey", x => new { x.playlist_id, x.track_id });
                    table.ForeignKey(
                        name: "playlist_track__reference_playlist__fkey",
                        column: x => x.playlist_id,
                        principalTable: "playlist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "playlist_track__reference_track__fkey",
                        column: x => x.track_id,
                        principalTable: "track",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_line",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    track_id = table.Column<int>(nullable: false),
                    invoice_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_line_id_pkey", x => x.id);
                    table.ForeignKey(
                        name: "invoice_line__reference_invoice_id__fkey",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "invoice_line__reference_track_id__fkey",
                        column: x => x.track_id,
                        principalTable: "track",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "album_artist_idx",
                table: "album",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_support_rep_id",
                table: "customer",
                column: "support_rep_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_reports_to_id",
                table: "employee",
                column: "reports_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_customer_id",
                table: "invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_line_invoice_id",
                table: "invoice_line",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_line_track_id",
                table: "invoice_line",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_playlist_track_track_id",
                table: "playlist_track",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_track_album_id",
                table: "track",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_track_genre_id",
                table: "track",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_track_media_type_id",
                table: "track",
                column: "media_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_line");

            migrationBuilder.DropTable(
                name: "playlist_track");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "playlist");

            migrationBuilder.DropTable(
                name: "track");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "media_type");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "artist");
        }
    }
}
