using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kempsoft.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ReadyProjects",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TasksProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        logoImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        ProjectRoute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        ProjectImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ReadyProjects", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StatusPay",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StatusPay", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypePrices",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypePrices", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Prices",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        Price = table.Column<decimal>(type: "money", nullable: true),
            //        description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        IdTypePrice = table.Column<short>(type: "smallint", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Prices", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Prices_TypePrices",
            //            column: x => x.IdTypePrice,
            //            principalTable: "TypePrices",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Payment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        userId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        priceId = table.Column<short>(type: "smallint", nullable: true),
            //        countDays = table.Column<short>(type: "smallint", nullable: true),
            //        orderId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        SumPayment = table.Column<decimal>(type: "money", nullable: true),
            //        contactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        contactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payment", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Payment_Prices",
            //            column: x => x.priceId,
            //            principalTable: "Prices",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentsStatuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        idStatus = table.Column<short>(type: "smallint", nullable: true),
            //        idPayment = table.Column<int>(type: "int", nullable: true),
            //        dateCreated = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentsStatuses", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PaymentsStatuses_Payment",
            //            column: x => x.idPayment,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PaymentsStatuses_StatusPay",
            //            column: x => x.idStatus,
            //            principalTable: "StatusPay",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_priceId",
            //    table: "Payment",
            //    column: "priceId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaymentsStatuses_idPayment",
            //    table: "PaymentsStatuses",
            //    column: "idPayment");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaymentsStatuses_idStatus",
            //    table: "PaymentsStatuses",
            //    column: "idStatus");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prices_IdTypePrice",
            //    table: "Prices",
            //    column: "IdTypePrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PaymentsStatuses");

            //migrationBuilder.DropTable(
            //    name: "ReadyProjects");

            //migrationBuilder.DropTable(
            //    name: "Payment");

            //migrationBuilder.DropTable(
            //    name: "StatusPay");

            //migrationBuilder.DropTable(
            //    name: "Prices");

            //migrationBuilder.DropTable(
            //    name: "TypePrices");
        }
    }
}
