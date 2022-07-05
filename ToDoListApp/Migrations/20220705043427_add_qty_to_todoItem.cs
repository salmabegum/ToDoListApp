using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApp.Migrations
{
    public partial class add_qty_to_todoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "TodoItems");
        }
    }
}
