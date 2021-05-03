﻿using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace CertificateService.Web.API.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class DbRelationsRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentDatas_StudentDataId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTickets_StudentTicketId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentTicketId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentDataId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentDatas_StudentDataId",
                table: "Students",
                column: "StudentDataId",
                principalTable: "StudentDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTickets_StudentTicketId",
                table: "Students",
                column: "StudentTicketId",
                principalTable: "StudentTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentDatas_StudentDataId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTickets_StudentTicketId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentTicketId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentDataId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentDatas_StudentDataId",
                table: "Students",
                column: "StudentDataId",
                principalTable: "StudentDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTickets_StudentTicketId",
                table: "Students",
                column: "StudentTicketId",
                principalTable: "StudentTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
