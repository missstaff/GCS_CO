using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCS_CO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GCS");

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                schema: "GCS",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.AddressTypeId);
                    table.UniqueConstraint("AK_AddressTypes_Type", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "GCS",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                    table.UniqueConstraint("AK_Regions_RegionAbbrev", x => x.RegionAbbrev);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "GCS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "GCS",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillPayRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.UniqueConstraint("AK_Skills_SkillName", x => x.SkillName);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "GCS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProfilePicture = table.Column<byte>(type: "tinyint", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "GCS",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.UniqueConstraint("AK_States_StateAbbrev", x => x.StateAbbrev);
                    table.ForeignKey(
                        name: "FK_States_Regions_RegionAbbrev",
                        column: x => x.RegionAbbrev,
                        principalSchema: "GCS",
                        principalTable: "Regions",
                        principalColumn: "RegionAbbrev",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "GCS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "GCS",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "GCS",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Regions_RegionAbbrev",
                        column: x => x.RegionAbbrev,
                        principalSchema: "GCS",
                        principalTable: "Regions",
                        principalColumn: "RegionAbbrev",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employees_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "GCS",
                        principalTable: "Skills",
                        principalColumn: "SkillId");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "GCS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "GCS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "GCS",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "GCS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "GCS",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "GCS",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "GCS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "GCS",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "GCS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                schema: "GCS",
                columns: table => new
                {
                    CityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionAbbrev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => new { x.CityName, x.StateAbbrev });
                    table.ForeignKey(
                        name: "FK_PostalCodes_States_StateAbbrev",
                        column: x => x.StateAbbrev,
                        principalSchema: "GCS",
                        principalTable: "States",
                        principalColumn: "StateAbbrev");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                schema: "GCS",
                columns: table => new
                {
                    EmployeeSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SkillDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillPayRate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.EmployeeSkillId);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "GCS",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillName",
                        column: x => x.SkillName,
                        principalSchema: "GCS",
                        principalTable: "Skills",
                        principalColumn: "SkillName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "GCS",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionAbbrev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.UniqueConstraint("AK_Cities_CityName_StateAbbrev", x => new { x.CityName, x.StateAbbrev });
                    table.ForeignKey(
                        name: "FK_Cities_PostalCodes_CityName_StateAbbrev",
                        columns: x => new { x.CityName, x.StateAbbrev },
                        principalSchema: "GCS",
                        principalTable: "PostalCodes",
                        principalColumns: new[] { "CityName", "StateAbbrev" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateAbbrev",
                        column: x => x.StateAbbrev,
                        principalSchema: "GCS",
                        principalTable: "States",
                        principalColumn: "StateAbbrev");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "GCS",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StateAbbrev = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionAbbrev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes_Type",
                        column: x => x.Type,
                        principalSchema: "GCS",
                        principalTable: "AddressTypes",
                        principalColumn: "Type");
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityName_StateAbbrev",
                        columns: x => new { x.CityName, x.StateAbbrev },
                        principalSchema: "GCS",
                        principalTable: "Cities",
                        principalColumns: new[] { "CityName", "StateAbbrev" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "GCS",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityName_StateAbbrev",
                schema: "GCS",
                table: "Addresses",
                columns: new[] { "CityName", "StateAbbrev" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                schema: "GCS",
                table: "Addresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Type",
                schema: "GCS",
                table: "Addresses",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateAbbrev",
                schema: "GCS",
                table: "Cities",
                column: "StateAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RegionAbbrev",
                schema: "GCS",
                table: "Employees",
                column: "RegionAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SkillId",
                schema: "GCS",
                table: "Employees",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                schema: "GCS",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillName",
                schema: "GCS",
                table: "EmployeeSkills",
                column: "SkillName");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCodes_StateAbbrev",
                schema: "GCS",
                table: "PostalCodes",
                column: "StateAbbrev");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "GCS",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "GCS",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_States_RegionAbbrev",
                schema: "GCS",
                table: "States",
                column: "RegionAbbrev");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "GCS",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "GCS",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "GCS",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "GCS",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "GCS",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "EmployeeSkills",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "AddressTypes",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "User",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "PostalCodes",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "States",
                schema: "GCS");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "GCS");
        }
    }
}
