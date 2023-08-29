using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCS_CO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityName_StateAbbrev",
                schema: "GCS",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                schema: "GCS",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                schema: "GCS",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityName_StateAbbrev",
                schema: "GCS",
                table: "Addresses",
                columns: new[] { "CityName", "StateAbbrev" },
                principalSchema: "GCS",
                principalTable: "Cities",
                principalColumns: new[] { "CityName", "StateAbbrev" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityName_StateAbbrev",
                schema: "GCS",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                schema: "GCS",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                schema: "GCS",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityName_StateAbbrev",
                schema: "GCS",
                table: "Addresses",
                columns: new[] { "CityName", "StateAbbrev" },
                principalSchema: "GCS",
                principalTable: "Cities",
                principalColumns: new[] { "CityName", "StateAbbrev" });
        }
    }
}
