using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringSQLServer.Infrastructure.Migrations.SqlServerMigrations
{
    public partial class InitialActiveSessions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Authentication",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientAddress",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectionReads",
                table: "ActiveSessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConnectionWrites",
                table: "ActiveSessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DBName",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastWaitType",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Protocol",
                table: "ActiveSessions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ActiveSessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransactionIsolation",
                table: "ActiveSessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authentication",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "ClientAddress",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "ConnectionReads",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "ConnectionWrites",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "DBName",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "HostName",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "LastWaitType",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "Protocol",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ActiveSessions");

            migrationBuilder.DropColumn(
                name: "TransactionIsolation",
                table: "ActiveSessions");
        }
    }
}
