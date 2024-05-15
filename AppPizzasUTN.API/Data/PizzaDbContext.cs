using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppPizzasUTN.Entidades;

    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext (DbContextOptions<PizzaDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppPizzasUTN.Entidades.Pizza> Pizzas { get; set; } = default!;

public DbSet<AppPizzasUTN.Entidades.Ingrediente> Ingredientes { get; set; } = default!;

public DbSet<AppPizzasUTN.Entidades.Pizzas_Ingredientes> Pizzas_Ingredientes { get; set; } = default!;
    }
