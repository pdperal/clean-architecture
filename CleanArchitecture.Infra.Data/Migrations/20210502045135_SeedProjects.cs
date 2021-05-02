using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infra.Data.Migrations
{
    public partial class SeedProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name)" +
                "Values('Material Escolar')");
            migrationBuilder.Sql("INSERT INTO Categories(Name)" +
                "Values('Outros')");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "Values('Caderno espiral', 'Caderno Espiral 100 Folhas', 7.50, 50, 'caderno.jpg', 5)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "Values('Estojo', 'Estojo grande', 10, 50, 'estojo.jpg', 5)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "Values('Caneta', 'Caneta preta', 1, 10, 'caneta.jpg', 5)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "Values('Calculadora', 'Calculadora científica', 15, 5, 'calculadora.jpg', 6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
