using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrregApi.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_AddressId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OrganizationTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Country", "CountryCode", "Municipality", "MunicipalityNumber", "PostalCode", "Region", "Street" },
                values: new object[,]
                {
                    { 1, "Norge", "NO", "BERGEN", "4601", "5007", "BERGEN", "[\"Parkveien 1\"]" },
                    { 2, "Norge", "NO", "BERGEN", "4601", "5160", "LAKSEVÅG", "[\"Damsg\\u00E5rdsveien 175\"]" },
                    { 3, "Norge", "NO", "HAUGESUND", "1106", "5536", "HAUGESUND", "[\"Deco-bygget\",\"Longhammarvegen 28\"]" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "FLI", "Forening/lag/innretning" },
                    { 2, "FLI", "Forening/lag/innretning" },
                    { 3, "FLI", "Forening/lag/innretning" },
                    { 4, "AS", "Aksjeselskap" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressId", "Email", "Homepage", "Name", "OrgNumber", "OrganizationTypeId" },
                values: new object[,]
                {
                    { 1, 1, "seiling@bsi.no", "www.bsiseiling.no", "BSI - SEILING", "916598408", 1 },
                    { 2, null, "badminton@bsi.no", "badminton.bsi.no/no/", "BSI - BADMINTON", "998008166", 2 },
                    { 3, 2, "innebandy@bsi.no", "www.innebandy.bsi.no", "BSI - INNEBANDY", "918995897", 3 },
                    { 4, 3, "hello@appex.no", "www.appex.no", "APPEX AS", "995412020", 4 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompanyId", "Note" },
                values: new object[,]
                {
                    { 1, 1, "Test" },
                    { 2, 2, "Testing" },
                    { 3, 3, "This is a test" },
                    { 4, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OrganizationTypeId",
                table: "Companies",
                column: "OrganizationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_AddressId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OrganizationTypeId",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrganizationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrganizationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrganizationTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrganizationTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OrganizationTypeId",
                table: "Companies",
                column: "OrganizationTypeId",
                unique: true,
                filter: "[OrganizationTypeId] IS NOT NULL");
        }
    }
}
