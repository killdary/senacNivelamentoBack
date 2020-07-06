﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SenacNivelamento.Infra.Writing.Data;

namespace SenacNivelamento.Infra.Writing.Data.Migrations
{
    [DbContext(typeof(WritingContext))]
    [Migration("20200702220447_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("SenacNivelamento.Domain.Entities.Cargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<short>("NivelAcesso")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("SenacNivelamento.Domain.Entities.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cep")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cnpj")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagem")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pais")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("SenacNivelamento.Domain.Entities.Funcionario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<long>("CargoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cep")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("TEXT");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagem")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pais")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("SenacNivelamento.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("SenacNivelamento.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SenacNivelamento.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}