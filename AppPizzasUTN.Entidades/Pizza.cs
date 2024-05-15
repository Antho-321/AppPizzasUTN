using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AppPizzasUTN.Entidades
{
    public class Pizza
    {
        [Key]
        public int Id {  get; set; }
        public string Nombre {  get; set; }
        public string Origen { get; set;}
        public bool Estado {  get; set; }
        public virtual ICollection<Pizzas_Ingredientes>? Pizzas_Ingredientes { get; set; }
    }
}
