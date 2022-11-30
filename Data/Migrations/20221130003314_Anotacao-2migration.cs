using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasAnotacoes.Data.Migrations
{
    public partial class Anotacao2migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosAnotacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<string>(nullable: true),
                    Cliente = table.Column<string>(nullable: true),
                    TipoSporte = table.Column<string>(nullable: true),
                    LocalSuporte = table.Column<string>(nullable: true),
                    CNPJ = table.Column<int>(nullable: false),
                    CaminhoPasta = table.Column<string>(nullable: true),
                    OBS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosAnotacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosAnotacao");
        }
    }
}
