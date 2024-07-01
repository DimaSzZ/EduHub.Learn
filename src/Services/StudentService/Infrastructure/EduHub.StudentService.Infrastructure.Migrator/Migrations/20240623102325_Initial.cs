﻿using System;
using EduHub.StudentService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHub.StudentService.Infrastructure.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender", "default,man,woman");

            migrationBuilder.CreateTable(
                name: "Educators",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    years_experience = table.Column<int>(type: "integer", nullable: false),
                    date_employment = table.Column<DateOnly>(type: "date", nullable: false),
                    first_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    surname = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    gender = table.Column<Gender>(type: "gender", nullable: false, defaultValue: Gender.Default),
                    phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educators", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    number_house = table.Column<int>(type: "integer", nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    surname = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    gender = table.Column<Gender>(type: "gender", nullable: false, defaultValue: Gender.Default),
                    phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    educator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Educators_educator_id",
                        column: x => x.educator_id,
                        principalTable: "Educators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enrollment_date = table.Column<DateOnly>(type: "date", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_course_id",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_educator_id",
                table: "Courses",
                column: "educator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Educator_Phone",
                table: "Educators",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_course_id",
                table: "Enrollments",
                column: "course_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_student_id",
                table: "Enrollments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Email",
                table: "Students",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Student_Phone",
                table: "Students",
                column: "phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Educators");
        }
    }
}
