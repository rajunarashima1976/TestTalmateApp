using Microsoft.EntityFrameworkCore.Migrations;

namespace CBA.Training.Talmate.Repository.Migrations
{
    public partial class modifiedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecommendedForTraining",
                table: "Recommendations");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommendedForTraining",
                table: "ResourceDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnrolledForTraining",
                table: "Recommendations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecommendedForTraining",
                table: "ResourceDetails");

            migrationBuilder.DropColumn(
                name: "IsEnrolledForTraining",
                table: "Recommendations");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommendedForTraining",
                table: "Recommendations",
                type: "bit",
                nullable: true);
        }
    }
}
