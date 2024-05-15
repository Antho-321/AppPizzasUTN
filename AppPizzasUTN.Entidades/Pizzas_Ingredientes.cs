using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AppPizzasUTN.Entidades
{
    public class Pizzas_Ingredientes
    {
        [Key]
        public int Id { get; set; }
        public int PizzaId {  get; set; } // FK
        public Pizza? Pizza { get; set; }
        public int IngredienteId { get; set; } // FK
        public Ingrediente? Ingrediente { get; set; }
        public double Porcion {  get; set; }
    }
}
