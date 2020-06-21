using Microsoft.EntityFrameworkCore.Migrations;

namespace CBA.Training.Talmate.Repository.Migrations
{
    public partial class addResouceshortlisttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceShortlist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PrimarySkills = table.Column<string>(nullable: true),
                    SecondarySkills = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    TrainingRecommendation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceShortlist", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceShortlist");
        }
    }
}
