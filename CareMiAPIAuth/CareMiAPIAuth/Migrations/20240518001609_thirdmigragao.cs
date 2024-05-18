using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareMiAPIAuth.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigragao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ATENDIMENTO_T_PACIENTE_paciente",
                table: "T_ATENDIMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOGIN_T_USUARIO_usuario",
                table: "T_LOGIN");

            migrationBuilder.DropForeignKey(
                name: "FK_T_PACIENTE_T_USUARIO_usuario",
                table: "T_PACIENTE");

            migrationBuilder.DropIndex(
                name: "IX_T_PACIENTE_usuario",
                table: "T_PACIENTE");

            migrationBuilder.DropIndex(
                name: "IX_T_LOGIN_usuario",
                table: "T_LOGIN");

            migrationBuilder.DropIndex(
                name: "IX_T_ATENDIMENTO_paciente",
                table: "T_ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "T_PACIENTE");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "T_LOGIN");

            migrationBuilder.DropColumn(
                name: "paciente",
                table: "T_ATENDIMENTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuario",
                table: "T_PACIENTE",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usuario",
                table: "T_LOGIN",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paciente",
                table: "T_ATENDIMENTO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_PACIENTE_usuario",
                table: "T_PACIENTE",
                column: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOGIN_usuario",
                table: "T_LOGIN",
                column: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATENDIMENTO_paciente",
                table: "T_ATENDIMENTO",
                column: "paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ATENDIMENTO_T_PACIENTE_paciente",
                table: "T_ATENDIMENTO",
                column: "paciente",
                principalTable: "T_PACIENTE",
                principalColumn: "cdPaciente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOGIN_T_USUARIO_usuario",
                table: "T_LOGIN",
                column: "usuario",
                principalTable: "T_USUARIO",
                principalColumn: "cdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_PACIENTE_T_USUARIO_usuario",
                table: "T_PACIENTE",
                column: "usuario",
                principalTable: "T_USUARIO",
                principalColumn: "cdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
