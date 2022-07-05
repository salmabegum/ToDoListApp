using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApp.Migrations
{
    public partial class add_totalprice_to_todoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "TodoItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "TodoItems");
        }
    }
}
