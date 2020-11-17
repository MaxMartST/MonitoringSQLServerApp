using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringSQLServer.Infrastructure.Migrations.SqlServerMigrations
{
    public partial class InitialStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "database_id",
                table: "Statistics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "database_id",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(short));
        }
    }
}
