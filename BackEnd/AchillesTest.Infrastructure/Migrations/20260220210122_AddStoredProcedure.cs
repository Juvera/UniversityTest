using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchillesTest.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE PROCEDURE sp_GetProvinciaMasPopularPorCurso
            @idcurso INT
        AS
        BEGIN
            SELECT TOP 1 
                P.nomb_pro AS Provincia, 
                COUNT(E.idestudiante) AS TotalEstudiantes
            FROM TB_PROVINCIA P
            JOIN TB_DISTRITO D ON P.idprovincia = D.idprovincia
            JOIN TB_ESTUDIANTE E ON D.iddistrito = E.iddistrito
            JOIN TB_MATRICULA M ON E.idestudiante = M.idestudiante
            WHERE M.idcurso = @idcurso
            GROUP BY P.nomb_pro
            ORDER BY TotalEstudiantes DESC;
        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvinciaPopularResults");
        }
    }
}
