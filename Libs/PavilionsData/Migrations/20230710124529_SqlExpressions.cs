using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavilionsData.Migrations
{
    /// <inheritdoc />
    public partial class SqlExpressions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE PROCEDURE RentPavilion "+
                                 "( "+
                                 "@PavilionId INT, "+
                                 "@LeaseStart DateTime, "+
                                 "@LeaseEnd DATETIME, "+
                                 "@TenantId INT, "+
                                 "@EmpId INT, "+
                                 "@RentStatusId INT "+
                                 ") "+
                                 "AS "+
                                 "BEGIN "+
                                 "IF (SELECT Pavilions.Id_PavilionsStatus FROM Pavilions WHERE Id_Pavilion = @PavilionId) = 2 AND @LeaseStart < @LeaseEnd "+
                                 "BEGIN "+
                                 "UPDATE Pavilions "+
                                 "SET Id_PavilionsStatus = @RentStatusId "+
                                 "WHERE Id_Pavilion = @PavilionId "+
                                 "INSERT INTO Rentals VALUES "+
                                 "( "+
                                 "(SELECT MAX(Id_Rental) FROM Rentals) + 1 , "+ 
                                 "@TenantId, "+ 
                                 "(SELECT Id_ShoppingCenter FROM Pavilions where Id_Pavilion = @PavilionId), "+ 
                                 "@PavilionId, "+
                                 "@EmpId, "+
                                 "1, "+
                                 "@LeaseStart, "+
                                 "@LeaseEnd, "+
                                 "NULL, NULL) "+
                                 "END "+
                                 "ELSE "+
                                 "RAISERROR ('Этот павильон уже забронирован либо вы указали дату неверно', 16, 1) "+
                                 "END"
                                 );
            
            migrationBuilder.Sql("CREATE TRIGGER PreventSCStatusChange "+
                                 "ON ShoppingCenters "+
                                 "FOR UPDATE "+
                                 "AS "+
                                 "BEGIN "+
                                 "IF UPDATE(Id_ShoppingCenterStatus) "+
                                 "BEGIN "+
                                 "IF EXISTS ( "+
                                 "SELECT 1 "+
                                 "FROM Pavilions p "+
                                 "INNER JOIN inserted AS i ON p.Id_PavilionsStatus = i.Id_ShoppingCenterStatus "+
                                 "WHERE p.Id_PavilionsStatus = 2 AND i.Id_ShoppingCenter = 2 "+
                                 ") "+
                                 "BEGIN "+
                                 "RAISERROR ('Cannot change Mall status to \"план\" due to reserved pavilions.', 16, 1) "+
                                 "ROLLBACK TRANSACTION "+
                                 "RETURN "+
                                 "END "+
                                 "END "+
                                 "END");
            
            migrationBuilder.Sql("GO "+ 
                                 "CREATE TRIGGER PreventModifyReservedPavilions "+
                                 "ON Pavilions "+
                                 "INSTEAD OF DELETE, UPDATE "+
                                 "AS "+
                                 "BEGIN "+
                                 "IF EXISTS ( "+
                                 "SELECT 1 "+
                                 "FROM deleted d "+
                                 "INNER JOIN Pavilions p ON p.Id_Pavilion = d.Id_Pavilion "+
                                 "INNER JOIN PavilionsStatuses ps ON ps.Id_PavilionsStatus = p.Id_PavilionsStatus "+
                                 "WHERE ps.Id_PavilionsStatus IN (3, 4)) "+
                                 "BEGIN "+
                                 "RAISERROR ('Невозможно удалить или изменить павильоны со статусом \"забронирован\" или \"арендован\".', 16, 1) "+
                                 "ROLLBACK TRANSACTION "+
                                 "END "+
                                 "END");

            migrationBuilder.Sql(
                "GO "+
                "CREATE PROCEDURE CreateChangeTrigger "+
                "( "+
                "@TableName NVARCHAR(MAX), "+
                "@Action NVARCHAR(MAX) "+
                ") "+
                "AS "+
                "BEGIN "+
                "DECLARE @TRIGGER NVARCHAR(MAX) = "+
                "' CREATE TRIGGER '+ @TableName + '_'+@Action+'_Tracking'+ "+
                "' ON '+ @TableName+ "+
                "' AFTER '+@Action+ "+
                "' AS'+ "+
                "' BEGIN'+ "+ 
                "' DECLARE @USRNAME NVARCHAR(MAX) = USER_NAME()'+ "+
                "' INSERT INTO DATA_BASE_AUDIT (UserName, Table_Name, ActionWithTable) VALUES'+ "+
                "' (@USRNAME,'''+@TableName+''','''+@Action+''')'+ "+
                "' END' "+
                "EXEC (@TRIGGER) "+
                "PRINT ('Создан TRIGGER '+ @TableName + '_'+@Action+'_Tracking') "+
                "END "
                );
                
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER PreventModifyReservedPavilions");
            migrationBuilder.Sql("DROP TRIGGER PreventSCStatusChange");
            migrationBuilder.Sql("DROP PROCEDURE RentPavilion");
            migrationBuilder.Sql("DROP PROCEDURE CreateChangeTrigger");
        }
    }
}
