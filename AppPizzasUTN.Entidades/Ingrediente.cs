using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AppPizzasUTN.Entidades
{
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Calorias {  get; set; }
        public bool Estado {  get; set; }
        public virtual ICollection<Pizzas_Ingredientes>? Pizzas_Ingredientes { get; set; }
    }
}
