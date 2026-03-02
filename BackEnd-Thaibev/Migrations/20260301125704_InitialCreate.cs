using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEnd_Thaibev.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_msg",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    msg_code = table.Column<string>(type: "text", nullable: true),
                    msg_desc = table.Column<string>(type: "text", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_msg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_choice_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ref_question_id = table.Column<int>(type: "integer", nullable: true),
                    choice_text = table.Column<string>(type: "text", nullable: true),
                    is_correct = table.Column<string>(type: "text", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_choice_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_question",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "text", nullable: true),
                    answer = table.Column<string>(type: "text", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_question", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_msg");

            migrationBuilder.DropTable(
                name: "tb_t_choice_items");

            migrationBuilder.DropTable(
                name: "tb_t_question");
        }
    }
}
