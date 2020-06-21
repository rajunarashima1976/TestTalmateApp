using Microsoft.EntityFrameworkCore.Migrations;

namespace CBA.Training.Talmate.Repository.Migrations
{
    public partial class updatedmodelname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceShortlist",
                table: "ResourceShortlist");

            migrationBuilder.RenameTable(
                name: "ResourceShortlist",
                newName: "Recommendations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "ResourceShortlist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceShortlist",
                table: "ResourceShortlist",
                column: "Id");
        }
    }
}
