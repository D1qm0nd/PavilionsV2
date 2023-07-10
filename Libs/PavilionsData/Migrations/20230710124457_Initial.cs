using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavilionsData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id_City = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id_City);
                });

            migrationBuilder.CreateTable(
                name: "PavilionsStatuses",
                columns: table => new
                {
                    Id_PavilionsStatus = table.Column<int>(type: "int", nullable: false),
                    PavilionsStatusName = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PavilionsStatuses", x => x.Id_PavilionsStatus);
                });

            migrationBuilder.CreateTable(
                name: "RentalsStatuses",
                columns: table => new
                {
                    Id_RentalStatus = table.Column<int>(type: "int", nullable: false),
                    RentalStatusName = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalsStatuses", x => x.Id_RentalStatus);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_Role = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_Role);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCentersStatuses",
                columns: table => new
                {
                    Id_ShoppingStatus = table.Column<int>(type: "int", nullable: false),
                    ShoppingStatusName = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCentersStatuses", x => x.Id_ShoppingStatus);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id_Rental = table.Column<int>(type: "int", nullable: false),
                    Id_Tenant = table.Column<int>(type: "int", nullable: false),
                    Id_ShoppingCenter = table.Column<int>(type: "int", nullable: false),
                    Id_Pavilion = table.Column<int>(type: "int", nullable: false),
                    Id_Employee = table.Column<int>(type: "int", nullable: false),
                    Id_RentalStatus = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    RentalsStatusId_RentalStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id_Rental);
                    table.ForeignKey(
                        name: "FK_Rentals_RentalsStatuses_RentalsStatusId_RentalStatus",
                        column: x => x.RentalsStatusId_RentalStatus,
                        principalTable: "RentalsStatuses",
                        principalColumn: "Id_RentalStatus");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id_Employee = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Id_Role = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RentalId_Rental = table.Column<int>(type: "int", nullable: true),
                    RoleId_Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id_Employee);
                    table.ForeignKey(
                        name: "FK_Employees_Rentals_RentalId_Rental",
                        column: x => x.RentalId_Rental,
                        principalTable: "Rentals",
                        principalColumn: "Id_Rental");
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId_Role",
                        column: x => x.RoleId_Role,
                        principalTable: "Roles",
                        principalColumn: "Id_Role");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCenters",
                columns: table => new
                {
                    Id_ShoppingCenter = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Id_ShoppingCenterStatus = table.Column<int>(type: "int", nullable: false),
                    PavilionsCount = table.Column<int>(type: "int", nullable: false),
                    Id_City = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AddedValueCoefficient = table.Column<double>(type: "float", nullable: false),
                    FloorsNumber = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    CityId_City = table.Column<int>(type: "int", nullable: true),
                    RentalId_Rental = table.Column<int>(type: "int", nullable: true),
                    ShoppingCentersStatusId_ShoppingStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCenters", x => x.Id_ShoppingCenter);
                    table.ForeignKey(
                        name: "FK_ShoppingCenters_Cities_CityId_City",
                        column: x => x.CityId_City,
                        principalTable: "Cities",
                        principalColumn: "Id_City");
                    table.ForeignKey(
                        name: "FK_ShoppingCenters_Rentals_RentalId_Rental",
                        column: x => x.RentalId_Rental,
                        principalTable: "Rentals",
                        principalColumn: "Id_Rental");
                    table.ForeignKey(
                        name: "FK_ShoppingCenters_ShoppingCentersStatuses_ShoppingCentersStatusId_ShoppingStatus",
                        column: x => x.ShoppingCentersStatusId_ShoppingStatus,
                        principalTable: "ShoppingCentersStatuses",
                        principalColumn: "Id_ShoppingStatus");
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id_Tenant = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    RentalId_Rental = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id_Tenant);
                    table.ForeignKey(
                        name: "FK_Tenants_Rentals_RentalId_Rental",
                        column: x => x.RentalId_Rental,
                        principalTable: "Rentals",
                        principalColumn: "Id_Rental");
                });

            migrationBuilder.CreateTable(
                name: "Pavilions",
                columns: table => new
                {
                    Id_Pavilion = table.Column<int>(type: "int", nullable: false),
                    Id_PavilionsStatus = table.Column<int>(type: "int", nullable: false),
                    Id_ShoppingCenter = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AddedValueCoefficient = table.Column<double>(type: "float", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    PavilionStatusId_PavilionsStatus = table.Column<int>(type: "int", nullable: true),
                    RentalId_Rental = table.Column<int>(type: "int", nullable: true),
                    ShoppingCenterId_ShoppingCenter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pavilions", x => x.Id_Pavilion);
                    table.ForeignKey(
                        name: "FK_Pavilions_PavilionsStatuses_PavilionStatusId_PavilionsStatus",
                        column: x => x.PavilionStatusId_PavilionsStatus,
                        principalTable: "PavilionsStatuses",
                        principalColumn: "Id_PavilionsStatus");
                    table.ForeignKey(
                        name: "FK_Pavilions_Rentals_RentalId_Rental",
                        column: x => x.RentalId_Rental,
                        principalTable: "Rentals",
                        principalColumn: "Id_Rental");
                    table.ForeignKey(
                        name: "FK_Pavilions_ShoppingCenters_ShoppingCenterId_ShoppingCenter",
                        column: x => x.ShoppingCenterId_ShoppingCenter,
                        principalTable: "ShoppingCenters",
                        principalColumn: "Id_ShoppingCenter");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RentalId_Rental",
                table: "Employees",
                column: "RentalId_Rental");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId_Role",
                table: "Employees",
                column: "RoleId_Role");

            migrationBuilder.CreateIndex(
                name: "IX_Pavilions_PavilionStatusId_PavilionsStatus",
                table: "Pavilions",
                column: "PavilionStatusId_PavilionsStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Pavilions_RentalId_Rental",
                table: "Pavilions",
                column: "RentalId_Rental");

            migrationBuilder.CreateIndex(
                name: "IX_Pavilions_ShoppingCenterId_ShoppingCenter",
                table: "Pavilions",
                column: "ShoppingCenterId_ShoppingCenter");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalsStatusId_RentalStatus",
                table: "Rentals",
                column: "RentalsStatusId_RentalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCenters_CityId_City",
                table: "ShoppingCenters",
                column: "CityId_City");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCenters_RentalId_Rental",
                table: "ShoppingCenters",
                column: "RentalId_Rental");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCenters_ShoppingCentersStatusId_ShoppingStatus",
                table: "ShoppingCenters",
                column: "ShoppingCentersStatusId_ShoppingStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_RentalId_Rental",
                table: "Tenants",
                column: "RentalId_Rental");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Pavilions");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PavilionsStatuses");

            migrationBuilder.DropTable(
                name: "ShoppingCenters");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "ShoppingCentersStatuses");

            migrationBuilder.DropTable(
                name: "RentalsStatuses");
        }
    }
}
