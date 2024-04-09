﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Superstore.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(CategoryName, ImageUrl) Values('Drink', 'drink.jpg')");
            migrationBuilder.Sql("Insert into Categories(CategoryName, ImageUrl) Values('Food', 'food.jpg')");
            migrationBuilder.Sql("Insert into Categories(CategoryName, ImageUrl) Values('Technology', 'technology.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
