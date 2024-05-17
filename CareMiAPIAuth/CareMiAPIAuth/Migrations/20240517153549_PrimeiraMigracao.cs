using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareMiAPIAuth.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIO",
                columns: table => new
                {
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nmUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dtNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    nrCpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nrRg = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dsNacionalidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nrTelefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "DATE", nullable: false),
                    dsEstadoCivil = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dsProfissao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    fgAtivo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO", x => x.cdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "T_LOGIN",
                columns: table => new
                {
                    cdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nrCpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dsSenha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    fgAtivo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOGIN", x => x.cdLogin);
                    table.ForeignKey(
                        name: "FK_T_LOGIN_T_USUARIO_usuario",
                        column: x => x.usuario,
                        principalTable: "T_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_PACIENTE",
                columns: table => new
                {
                    cdPaciente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nmPaciente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nrPeso = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nrAltura = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nmGrupoSanguineo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    flSexoBiologico = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PACIENTE", x => x.cdPaciente);
                    table.ForeignKey(
                        name: "FK_T_PACIENTE_T_USUARIO_usuario",
                        column: x => x.usuario,
                        principalTable: "T_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATENDIMENTO",
                columns: table => new
                {
                    cdAtendimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    paciente = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dsDescricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    qtDias = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dsHabito = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dsTempoSono = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dsHereditario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dtEnvio = table.Column<DateTime>(type: "DATE", nullable: false),
                    fgAtivo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ATENDIMENTO", x => x.cdAtendimento);
                    table.ForeignKey(
                        name: "FK_T_ATENDIMENTO_T_PACIENTE_paciente",
                        column: x => x.paciente,
                        principalTable: "T_PACIENTE",
                        principalColumn: "cdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ATENDIMENTO_paciente",
                table: "T_ATENDIMENTO",
                column: "paciente");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOGIN_usuario",
                table: "T_LOGIN",
                column: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_T_PACIENTE_usuario",
                table: "T_PACIENTE",
                column: "usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ATENDIMENTO");

            migrationBuilder.DropTable(
                name: "T_LOGIN");

            migrationBuilder.DropTable(
                name: "T_PACIENTE");

            migrationBuilder.DropTable(
                name: "T_USUARIO");
        }
    }
}
