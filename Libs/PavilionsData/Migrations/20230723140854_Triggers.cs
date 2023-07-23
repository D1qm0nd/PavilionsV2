using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavilionsData.Migrations
{
    /// <inheritdoc />
    public partial class Triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER CheckShopCenterUpdate " +
                "ON ShoppingCenters " +
                "FOR UPDATE " +
                "AS " +
                "BEGIN " +
                "IF UPDATE(Id_ShoppingCenterStatus) " +
                "BEGIN " +
                "IF EXISTS(SELECT 1 FROM Pavilions p " +
                "INNER JOIN inserted AS i " +
                "ON p.Id_ShoppingCenter = i.Id_ShoppingCenter " +
                "WHERE p.Id_PavilionsStatus >= 3 AND i.Id_ShoppingCenterStatus = 2) " +
                "BEGIN " +
                "RAISERROR ('Вы не можете изменить статус торгового цента на план если в нём присутствуют забронированные павильоны или арендованные',16,1) " +
                "ROLLBACK TRANSACTION " +
                "END " +
                "END " +
                "END");

            migrationBuilder.Sql("CREATE TRIGGER CheckPavilionUpdate " +
                "ON Pavilions " +
                "FOR UPDATE, DELETE " +
                "AS " +
                "BEGIN " +
                "DECLARE @Status int = (SELECT i.Id_PavilionsStatus FROM inserted as i); " +
                "IF ((@Status = 3 or @Status = 4) AND NOT UPDATE(Id_PavilionsStatus)) " +
                "BEGIN " +
                "RAISERROR ('Вы не можете изменять информацию о павильоне статус которого забронирован или арендован',16,1) " +
                "ROLLBACK TRANSACTION " +
                "END " +
                "END");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER CheckShopCenterUpdate");
            migrationBuilder.Sql("DROP TRIGGER CheckPavilionUpdate");
        }
    }
}
