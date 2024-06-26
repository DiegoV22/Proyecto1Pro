﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto1Pro.Data;

#nullable disable

namespace Proyecto1Pro.Migrations
{
    [DbContext(typeof(Proyecto1ProContext))]
    partial class Proyecto1ProContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto1Pro.Models.Catalogo", b =>
                {
                    b.Property<int>("IdCatalogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCatalogo"));

                    b.Property<int?>("IdPeluche")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdCatalogo");

                    b.HasIndex("IdPeluche");

                    b.ToTable("Catalogo");
                });

            modelBuilder.Entity("Proyecto1Pro.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"));

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdPeluche")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCompra");

                    b.HasIndex("IdPeluche");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Proyecto1Pro.Models.Peluche", b =>
                {
                    b.Property<int>("IdPeluche")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPeluche"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("Tamano")
                        .HasColumnType("int");

                    b.HasKey("IdPeluche");

                    b.ToTable("Peluche");
                });

            modelBuilder.Entity("Proyecto1Pro.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Proyecto1Pro.Models.Catalogo", b =>
                {
                    b.HasOne("Proyecto1Pro.Models.Peluche", "Peluche")
                        .WithMany()
                        .HasForeignKey("IdPeluche")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peluche");
                });

            modelBuilder.Entity("Proyecto1Pro.Models.Compra", b =>
                {
                    b.HasOne("Proyecto1Pro.Models.Peluche", "Peluche")
                        .WithMany()
                        .HasForeignKey("IdPeluche");

                    b.HasOne("Proyecto1Pro.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Peluche");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
