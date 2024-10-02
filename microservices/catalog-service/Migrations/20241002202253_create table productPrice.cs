using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catalog_service.Migrations
{
    /// <inheritdoc />
    public partial class createtableproductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableStock",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvailableStock",
                table: "Products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
