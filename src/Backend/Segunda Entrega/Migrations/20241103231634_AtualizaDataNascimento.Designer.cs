﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoPI.Data;

#nullable disable

namespace ProjetoPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241103231634_AtualizaDataNascimento")]
    partial class AtualizaDataNascimento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoPI.Model.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Doador", b =>
                {
                    b.HasBaseType("ProjetoPI.Model.Usuario");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataNascimentoString")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Doadores", (string)null);
                });

            modelBuilder.Entity("ProjetoPI.Model.Ong", b =>
                {
                    b.HasBaseType("ProjetoPI.Model.Usuario");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.ToTable("Ongs", (string)null);
                });

            modelBuilder.Entity("Doador", b =>
                {
                    b.HasOne("ProjetoPI.Model.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Doador", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoPI.Model.Ong", b =>
                {
                    b.HasOne("ProjetoPI.Model.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ProjetoPI.Model.Ong", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}