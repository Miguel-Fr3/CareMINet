﻿// <auto-generated />
using System;
using CareMiAPIAuth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CareMiAPIAuth.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240517153549_PrimeiraMigracao")]
    partial class PrimeiraMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CareMiAPIAuth.Models.Atendimento", b =>
                {
                    b.Property<int>("cdAtendimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdAtendimento"));

                    b.Property<string>("dsDescricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("dsHabito")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("dsHereditario")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("dsTempoSono")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("dtEnvio")
                        .HasColumnType("DATE");

                    b.Property<int>("fgAtivo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("paciente")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("qtDias")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("cdAtendimento");

                    b.HasIndex("paciente");

                    b.ToTable("T_ATENDIMENTO");
                });

            modelBuilder.Entity("CareMiAPIAuth.Models.Login", b =>
                {
                    b.Property<int>("cdLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdLogin"));

                    b.Property<string>("dsSenha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("fgAtivo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nrCpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("usuario")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("cdLogin");

                    b.HasIndex("usuario");

                    b.ToTable("T_LOGIN");
                });

            modelBuilder.Entity("CareMiAPIAuth.Models.Paciente", b =>
                {
                    b.Property<int>("cdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdPaciente"));

                    b.Property<string>("flSexoBiologico")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nmGrupoSanguineo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nmPaciente")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("nrAltura")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("nrPeso")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("usuario")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("cdPaciente");

                    b.HasIndex("usuario");

                    b.ToTable("T_PACIENTE");
                });

            modelBuilder.Entity("CareMiAPIAuth.Models.Usuario", b =>
                {
                    b.Property<int>("cdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdUsuario"));

                    b.Property<string>("dsEstadoCivil")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("dsNacionalidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("dsProfissao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("dtCadastro")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("dtNascimento")
                        .HasColumnType("DATE");

                    b.Property<int>("fgAtivo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nmUsuario")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nrCpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nrRg")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nrTelefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("cdUsuario");

                    b.ToTable("T_USUARIO");
                });

            modelBuilder.Entity("CareMiAPIAuth.Models.Atendimento", b =>
                {
                    b.HasOne("CareMiAPIAuth.Models.Paciente", "cdPaciente")
                        .WithMany()
                        .HasForeignKey("paciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cdPaciente");
                });

            modelBuilder.Entity("CareMiAPIAuth.Models.Login", b =>
                {
                    b.HasOne("CareMiAPIAuth.Models.Usuario", "cdUsuario")
                        .WithMany()
                        .HasForeignKey("usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cdUsuario");
                });

            modelBuilder.Entity("CareMiAPIAuth.Models.Paciente", b =>
                {
                    b.HasOne("CareMiAPIAuth.Models.Usuario", "cdUsuario")
                        .WithMany()
                        .HasForeignKey("usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
