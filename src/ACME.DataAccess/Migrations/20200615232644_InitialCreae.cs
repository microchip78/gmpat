using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACME.DataAccess.Migrations
{
    public partial class InitialCreae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    PostcodeId = table.Column<int>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(maxLength: 120, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Postcodes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pcode = table.Column<string>(maxLength: 50, nullable: true),
                    Locality = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Comments = table.Column<string>(maxLength: 50, nullable: true),
                    DeliveryOffice = table.Column<string>(maxLength: 50, nullable: true),
                    PreSortIndicator = table.Column<string>(maxLength: 50, nullable: true),
                    ParcelZone = table.Column<string>(maxLength: 50, nullable: true),
                    BSPnumber = table.Column<string>(maxLength: 50, nullable: true),
                    BSPname = table.Column<string>(maxLength: 50, nullable: true),
                    Category = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { 1, "AU", "Australia" },
                    { 9, "AR", "Argentina" },
                    { 8, "AQ", "Antarticia" },
                    { 7, "NZ", "New Zeland" },
                    { 6, "AU", "Australia" },
                    { 10, "BR", "Brazil" },
                    { 4, "AR", "Argentina" },
                    { 3, "AQ", "Antarctica" },
                    { 2, "NZ", "New Zealand" },
                    { 5, "BR", "Brazil" }
                });

            migrationBuilder.InsertData(
                table: "Postcodes",
                columns: new[] { "ID", "BSPname", "BSPnumber", "Category", "Comments", "DeliveryOffice", "Locality", "ParcelZone", "Pcode", "PreSortIndicator", "State" },
                values: new object[,]
                {
                    { 16361, null, null, "Delivery Area", null, null, "ABBOTSHAM", null, "7315", null, "TAS" },
                    { 50, null, null, "Delivery Area", null, null, "ACACIA HILLS", null, "822", null, "NT" },
                    { 3802, null, null, "Delivery Area", null, null, "ACTON", null, "2601", null, "ACT" },
                    { 5172, null, null, "Delivery Area", null, null, "AARONS PASS", null, "2850", null, "NSW" },
                    { 7795, null, null, "Delivery Area", null, null, "ABBEYARD", null, "3737", null, "VIC" },
                    { 10354, null, null, "Delivery Area", null, null, "ABBEYWOOD", null, "4613", null, "QLD" },
                    { 12392, null, null, "Delivery Area", null, null, "ABERFOYLE PARK", null, "5159", null, "SA" },
                    { 14504, null, null, "Delivery Area", null, null, "ABBA RIVER", null, "6280", null, "WA" },
                    { 16305, null, null, "Delivery Area", null, null, "ACACIA HILLS", null, "7306", null, "TAS" },
                    { 16389, null, null, "Delivery Area", "BURNIE", null, "ACTON", null, "7320", null, "TAS" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Postcodes");
        }
    }
}
