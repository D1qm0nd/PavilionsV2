using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavilionsData.Migrations
{
    /// <inheritdoc />
    public partial class Procedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE PROCEDURE RentPavilion " +
                "(@ID_Pavilion INT, @ID_Tennant INT, @ID_Employee INT, @ID_Status INT, @Start DATE, @End DATE, @AdditionalInfo NVARCHAR(MAX)) " +
                "AS " +
                "BEGIN " +
                "INSERT INTO Rentals " +
                "(Id_Rental, Id_Pavilion, Id_Tenant, Id_Employee, Id_RentalStatus, StartDate, EndDate, AdditionalInfo) " +
                "VALUES " +
                "( (SELECT MAX(Id_Rental) FROM Rentals)+1, @ID_Pavilion, @ID_Tennant, @ID_Employee, @ID_Status, @Start, @End, @AdditionalInfo) " +
                "END");

            migrationBuilder.Sql("CREATE PROCEDURE ChangePavilionStatus(@ID_Pavilion INT, @ID_Status INT) " +
                "AS UPDATE Pavilions SET Id_PavilionsStatus = @ID_Status WHERE Id_Pavilion = @ID_Pavilion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE RentPavilion");
            migrationBuilder.Sql("DROP PROCEDURE ChangePavilionStatus");
        }
    }
}
