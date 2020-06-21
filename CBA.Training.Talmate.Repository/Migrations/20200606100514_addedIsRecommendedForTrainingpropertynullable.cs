using Microsoft.EntityFrameworkCore.Migrations;

namespace CBA.Training.Talmate.Repository.Migrations
{
    public partial class addedIsRecommendedForTrainingpropertynullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRecommendedForTraining",
                table: "Recommendations",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRecommendedForTraining",
                table: "Recommendations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
