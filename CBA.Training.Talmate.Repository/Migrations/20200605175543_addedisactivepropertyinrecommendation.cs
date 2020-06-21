using Microsoft.EntityFrameworkCore.Migrations;

namespace CBA.Training.Talmate.Repository.Migrations
{
    public partial class addedisactivepropertyinrecommendation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Recommendations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Recommendations");
        }
    }
}
