using Lib.PasswordChecker;
using PavilionsData.PavilionsModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Pavilions
    {
        [Test]
        public void PasswordDifficultyTest()
        {
            var res = PasswordChecker.Check("sdfds2123dsf_23");
            Console.WriteLine(res);
            Assert.IsTrue(res == "Средний");
        }

        [Test]
        public void PavilionRentTest()
        {
            PavilionsDbContext context = new PavilionsDbContext();

            var pavilionId = 1;
            var tenantId = 1;
            var employeeId = 1;
            var rentStatusId = 1;

            context.RentPavilion(
                pavilion_ID: pavilionId,
                tenantInfo: new PavilionsData.PavilionsModel.TenantInfo(
                    id: tenantId,
                    kindOfActivity: "SportMaster",
                    organization: "TestOrganization",
                    serviceList: new() { "Продажа спорт товаров" },
                    licence: "HH123FFF"),
                employee_ID: employeeId,
                rentStatus_ID: rentStatusId,
                startDate: DateTime.UtcNow,
                endDate: DateTime.UtcNow.AddYears(2));

            Assert.IsTrue(context.Rentals.Any(rent => rent.Id_Tenant == tenantId
                && rent.Employee.Id_Employee == employeeId 
                && rent.Pavilion.Id_Pavilion == pavilionId 
                && rent.Id_RentalStatus == rentStatusId));
        }
    }
}
