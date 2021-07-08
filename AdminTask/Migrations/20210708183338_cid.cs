using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminTask.Migrations
{
    public partial class cid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_companies_companyId",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "employees",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_companyId",
                table: "employees",
                newName: "IX_employees_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_companies_CompanyId",
                table: "employees",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_companies_CompanyId",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "employees",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_CompanyId",
                table: "employees",
                newName: "IX_employees_companyId");

            migrationBuilder.AlterColumn<int>(
                name: "companyId",
                table: "employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_companies_companyId",
                table: "employees",
                column: "companyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
