using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaUsuarioTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataNascimentoString",
                table: "Doadores",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimentoString",
                table: "Doadores");
        }
    }
}
