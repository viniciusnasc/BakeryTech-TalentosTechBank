﻿// <auto-generated />
using System;
using Bakery.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bakery.Dados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210730021753_venda")]
    partial class venda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bakery.Model.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<double>("QuantidadeMin")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto")
                        .IsUnique();

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("Bakery.Model.ItemVenda", b =>
                {
                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("IdProduto", "IdVenda");

                    b.HasIndex("IdVenda");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("Bakery.Model.MaterialReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("MaterialReceita");
                });

            modelBuilder.Entity("Bakery.Model.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TipoDeMedida")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeProduto")
                        .HasColumnType("int");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ListaDeProdutos");
                });

            modelBuilder.Entity("Bakery.Model.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("Bakery.Model.Estoque", b =>
                {
                    b.HasOne("Bakery.Model.Produto", "Produto")
                        .WithOne("Estoque")
                        .HasForeignKey("Bakery.Model.Estoque", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Bakery.Model.ItemVenda", b =>
                {
                    b.HasOne("Bakery.Model.Produto", "Produto")
                        .WithMany("ItemVendas")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bakery.Model.Venda", "Venda")
                        .WithMany("ItemVendas")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Bakery.Model.MaterialReceita", b =>
                {
                    b.HasOne("Bakery.Model.Produto", "Produto")
                        .WithMany("MaterialReceitas")
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Bakery.Model.Produto", b =>
                {
                    b.Navigation("Estoque");

                    b.Navigation("ItemVendas");

                    b.Navigation("MaterialReceitas");
                });

            modelBuilder.Entity("Bakery.Model.Venda", b =>
                {
                    b.Navigation("ItemVendas");
                });
#pragma warning restore 612, 618
        }
    }
}
