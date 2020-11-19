using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringSQLServer.Infrastructure.Migrations.SqlServerMigrations
{
    public partial class InitialActiveSessions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SPID",
                table: "ActiveSessions",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "SPID",
                table: "ActiveSessions",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
