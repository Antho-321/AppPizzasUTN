using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppPizzasUTN.Entidades;

namespace AppPizzasUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pizzas_IngredientesController : ControllerBase
    {
        private readonly PizzaDbContext _context;

        public Pizzas_IngredientesController(PizzaDbContext context)
        {
            _context = context;
        }

        // GET: api/Pizzas_Ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizzas_Ingredientes>>> GetPizzas_Ingredientes()
        {
            return await _context.Pizzas_Ingredientes.ToListAsync();
        }

        // GET: api/Pizzas_Ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizzas_Ingredientes>> GetPizzas_Ingredientes(int id)
        {
            var pizzas_Ingredientes = await _context.Pizzas_Ingredientes.FindAsync(id);

            if (pizzas_Ingredientes == null)
            {
                return NotFound();
            }

            return pizzas_Ingredientes;
        }

        // PUT: api/Pizzas_Ingredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzas_Ingredientes(int id, Pizzas_Ingredientes pizzas_Ingredientes)
        {
            if (id != pizzas_Ingredientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzas_Ingredientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pizzas_IngredientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pizzas_Ingredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizzas_Ingredientes>> PostPizzas_Ingredientes(Pizzas_Ingredientes pizzas_Ingredientes)
        {
            _context.Pizzas_Ingredientes.Add(pizzas_Ingredientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzas_Ingredientes", new { id = pizzas_Ingredientes.Id }, pizzas_Ingredientes);
        }

        // DELETE: api/Pizzas_Ingredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzas_Ingredientes(int id)
        {
            var pizzas_Ingredientes = await _context.Pizzas_Ingredientes.FindAsync(id);
            if (pizzas_Ingredientes == null)
            {
                return NotFound();
            }

            _context.Pizzas_Ingredientes.Remove(pizzas_Ingredientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Pizzas_IngredientesExists(int id)
        {
            return _context.Pizzas_Ingredientes.Any(e => e.Id == id);
        }
    }
}
