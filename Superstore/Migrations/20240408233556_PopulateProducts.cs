using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Superstore.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Amount, CreatedAt, CategoryId) " +
                "Values('Coca-cola', 'Refreshing Drink with A lot of sugar', '5.45', 'coke.png', '500', now(), 1 )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");

        }
    }
}
