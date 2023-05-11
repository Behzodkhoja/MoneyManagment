using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManagment.DAL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exposes_Users_UserId1",
                table: "Exposes");

            migrationBuilder.DropIndex(
                name: "IX_Exposes_UserId1",
                table: "Exposes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Exposes");

            migrationBuilder.AlterColumn<int>(
                name: "DeletedBy",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Exposes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeletedBy",
                table: "Exposes",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exposes_UserId",
                table: "Exposes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exposes_Users_UserId",
                table: "Exposes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exposes_Users_UserId",
                table: "Exposes");

            migrationBuilder.DropIndex(
                name: "IX_Exposes_UserId",
                table: "Exposes");

            migrationBuilder.AlterColumn<long>(
                name: "DeletedBy",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Exposes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "DeletedBy",
                table: "Exposes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Exposes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exposes_UserId1",
                table: "Exposes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exposes_Users_UserId1",
                table: "Exposes",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
