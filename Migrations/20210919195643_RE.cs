using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate_with_efcore.Migrations
{
    public partial class RE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBroker_Brokers_BrokerId",
                table: "CompanyBroker");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBroker_Companies_CompanyId",
                table: "CompanyBroker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyBroker",
                table: "CompanyBroker");

            migrationBuilder.RenameTable(
                name: "CompanyBroker",
                newName: "CompanyBrokers");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBroker_BrokerId",
                table: "CompanyBrokers",
                newName: "IX_CompanyBrokers_BrokerId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Houses",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyBrokers",
                table: "CompanyBrokers",
                columns: new[] { "CompanyId", "BrokerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CompanyId",
                table: "Houses",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBrokers_Brokers_BrokerId",
                table: "CompanyBrokers",
                column: "BrokerId",
                principalTable: "Brokers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBrokers_Companies_CompanyId",
                table: "CompanyBrokers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Companies_CompanyId",
                table: "Houses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBrokers_Brokers_BrokerId",
                table: "CompanyBrokers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBrokers_Companies_CompanyId",
                table: "CompanyBrokers");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Companies_CompanyId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_CompanyId",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyBrokers",
                table: "CompanyBrokers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Houses");

            migrationBuilder.RenameTable(
                name: "CompanyBrokers",
                newName: "CompanyBroker");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBrokers_BrokerId",
                table: "CompanyBroker",
                newName: "IX_CompanyBroker_BrokerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyBroker",
                table: "CompanyBroker",
                columns: new[] { "CompanyId", "BrokerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBroker_Brokers_BrokerId",
                table: "CompanyBroker",
                column: "BrokerId",
                principalTable: "Brokers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBroker_Companies_CompanyId",
                table: "CompanyBroker",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
