using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Coensio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coding_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    text = table.Column<string>(type: "text", nullable: false),
                    unit_tests = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coding_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "free_text_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    text = table.Column<string>(type: "text", nullable: false),
                    sample_answer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_free_text_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "multiple_choice_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    text = table.Column<string>(type: "text", nullable: false),
                    answer = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_multiple_choice_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_email = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coding_question_test",
                columns: table => new
                {
                    coding_questions_id = table.Column<int>(type: "integer", nullable: false),
                    tests_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coding_question_test", x => new { x.coding_questions_id, x.tests_id });
                    table.ForeignKey(
                        name: "fk_coding_question_test_coding_questions_coding_questions_id",
                        column: x => x.coding_questions_id,
                        principalTable: "coding_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_coding_question_test_tests_tests_id",
                        column: x => x.tests_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coding_question_user_answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    test_id = table.Column<int>(type: "integer", nullable: false),
                    coding_question_id = table.Column<int>(type: "integer", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: true),
                    score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coding_question_user_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_coding_question_user_answers_coding_questions_coding_questi",
                        column: x => x.coding_question_id,
                        principalTable: "coding_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_coding_question_user_answers_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "free_text_question_test",
                columns: table => new
                {
                    free_text_questions_id = table.Column<int>(type: "integer", nullable: false),
                    tests_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_free_text_question_test", x => new { x.free_text_questions_id, x.tests_id });
                    table.ForeignKey(
                        name: "fk_free_text_question_test_free_text_questions_free_text_quest",
                        column: x => x.free_text_questions_id,
                        principalTable: "free_text_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_free_text_question_test_tests_tests_id",
                        column: x => x.tests_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "free_text_question_user_answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    test_id = table.Column<int>(type: "integer", nullable: false),
                    free_text_question_id = table.Column<int>(type: "integer", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: true),
                    score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_free_text_question_user_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_free_text_question_user_answers_free_text_questions_free_te",
                        column: x => x.free_text_question_id,
                        principalTable: "free_text_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_free_text_question_user_answers_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mcq_user_answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    test_id = table.Column<int>(type: "integer", nullable: false),
                    multiple_choice_question_id = table.Column<int>(type: "integer", nullable: false),
                    answer = table.Column<char>(type: "character(1)", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mcq_user_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_mcq_user_answers_multiple_choice_questions_multiple_choice_",
                        column: x => x.multiple_choice_question_id,
                        principalTable: "multiple_choice_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mcq_user_answers_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "multiple_choice_question_test",
                columns: table => new
                {
                    multiple_choice_questions_id = table.Column<int>(type: "integer", nullable: false),
                    tests_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_multiple_choice_question_test", x => new { x.multiple_choice_questions_id, x.tests_id });
                    table.ForeignKey(
                        name: "fk_multiple_choice_question_test_multiple_choice_questions_mul",
                        column: x => x.multiple_choice_questions_id,
                        principalTable: "multiple_choice_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_multiple_choice_question_test_tests_tests_id",
                        column: x => x.tests_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_coding_question_test_tests_id",
                table: "coding_question_test",
                column: "tests_id");

            migrationBuilder.CreateIndex(
                name: "ix_coding_question_user_answers_coding_question_id",
                table: "coding_question_user_answers",
                column: "coding_question_id");

            migrationBuilder.CreateIndex(
                name: "ix_coding_question_user_answers_test_id",
                table: "coding_question_user_answers",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "ix_free_text_question_test_tests_id",
                table: "free_text_question_test",
                column: "tests_id");

            migrationBuilder.CreateIndex(
                name: "ix_free_text_question_user_answers_free_text_question_id",
                table: "free_text_question_user_answers",
                column: "free_text_question_id");

            migrationBuilder.CreateIndex(
                name: "ix_free_text_question_user_answers_test_id",
                table: "free_text_question_user_answers",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "ix_mcq_user_answers_multiple_choice_question_id",
                table: "mcq_user_answers",
                column: "multiple_choice_question_id");

            migrationBuilder.CreateIndex(
                name: "ix_mcq_user_answers_test_id",
                table: "mcq_user_answers",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "ix_multiple_choice_question_test_tests_id",
                table: "multiple_choice_question_test",
                column: "tests_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coding_question_test");

            migrationBuilder.DropTable(
                name: "coding_question_user_answers");

            migrationBuilder.DropTable(
                name: "free_text_question_test");

            migrationBuilder.DropTable(
                name: "free_text_question_user_answers");

            migrationBuilder.DropTable(
                name: "mcq_user_answers");

            migrationBuilder.DropTable(
                name: "multiple_choice_question_test");

            migrationBuilder.DropTable(
                name: "coding_questions");

            migrationBuilder.DropTable(
                name: "free_text_questions");

            migrationBuilder.DropTable(
                name: "multiple_choice_questions");

            migrationBuilder.DropTable(
                name: "tests");
        }
    }
}
