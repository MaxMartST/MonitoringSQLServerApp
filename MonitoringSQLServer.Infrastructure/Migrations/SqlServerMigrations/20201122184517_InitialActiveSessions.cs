using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringSQLServer.Infrastructure.Migrations.SqlServerMigrations
{
    public partial class InitialActiveSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveSessions",
                columns: table => new
                {
                    SPID = table.Column<int>(nullable: false),
                    BlkBy = table.Column<int>(nullable: false),
                    ElapsedMS = table.Column<int>(nullable: false),
                    CPU = table.Column<int>(nullable: false),
                    IOReads = table.Column<long>(nullable: false),
                    IOWrites = table.Column<long>(nullable: false),
                    Executions = table.Column<int>(nullable: false),
                    CommandType = table.Column<string>(nullable: true),
                    SQLStatement = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    DBName = table.Column<string>(nullable: true),
                    LastWaitType = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Protocol = table.Column<string>(nullable: true),
                    TransactionIsolation = table.Column<string>(nullable: true),
                    ConnectionWrites = table.Column<int>(nullable: false),
                    ConnectionReads = table.Column<int>(nullable: false),
                    ClientAddress = table.Column<string>(nullable: true),
                    Authentication = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Blocking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DBName = table.Column<string>(nullable: true),
                    RequestSessionId = table.Column<int>(nullable: false),
                    BlockingSessionId = table.Column<int>(nullable: false),
                    BlockedObjectName = table.Column<string>(nullable: true),
                    ResourceType = table.Column<string>(nullable: true),
                    RequestingText = table.Column<string>(nullable: true),
                    BlockingTest = table.Column<string>(nullable: true),
                    RequestMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPID = table.Column<int>(nullable: false),
                    BlkBy = table.Column<int>(nullable: false),
                    ElapsedMS = table.Column<int>(nullable: false),
                    CPU = table.Column<int>(nullable: false),
                    IOReads = table.Column<long>(nullable: false),
                    IOWrites = table.Column<long>(nullable: false),
                    Executions = table.Column<int>(nullable: false),
                    CommandType = table.Column<string>(nullable: true),
                    SQLStatement = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    DBName = table.Column<string>(nullable: true),
                    LastWaitType = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Protocol = table.Column<string>(nullable: true),
                    TransactionIsolation = table.Column<string>(nullable: true),
                    ConnectionWrites = table.Column<int>(nullable: false),
                    ConnectionReads = table.Column<int>(nullable: false),
                    ClientAddress = table.Column<string>(nullable: true),
                    Authentication = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroup",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroup", x => new { x.RoleId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_RoleGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleGroup_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_Users_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroup_GroupId",
                table: "RoleGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveSessions");

            migrationBuilder.DropTable(
                name: "Blocking");

            migrationBuilder.DropTable(
                name: "RoleGroup");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
