﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppPizzasUTN.API.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20240515180344_v10")]
    partial class v10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppPizzasUTN.Entidades.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Calorias")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("AppPizzasUTN.Entidades.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("AppPizzasUTN.Entidades.Pizzas_Ingredientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<double>("Porcion")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Pizzas_Ingredientes");
                });

            modelBuilder.Entity("AppPizzasUTN.Entidades.Pizzas_Ingredientes", b =>
                {
                    b.HasOne("AppPizzasUTN.Entidades.Ingrediente", "Ingrediente")
                        .WithMany("Pizzas_Ingredientes")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppPizzasUTN.Entidades.Pizza", "Pizza")
                        .WithMany("Pizzas_Ingredientes")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("AppPizzasUTN.Entidades.Ingrediente", b =>
                {
                    b.Navigation("Pizzas_Ingredientes");
                });

            modelBuilder.Entity("AppPizzasUTN.Entidades.Pizza", b =>
                {
                    b.Navigation("Pizzas_Ingredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
