using AppPizzasUTN.Entidades;
using AppPizzasUTNConsumeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppPizzas_IngredientessUTN.MVC.Controllers
{
    public class PizzasIngredientesController : Controller
    {
        private string urlApi;

        public PizzasIngredientesController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Pizzas_Ingredientes";
        }
        // GET: Pizzas_IngredientessController
        public ActionResult Index()
        {
            var data = Crud<Pizzas_Ingredientes>.Read(urlApi);
            return View(data);
        }

        // GET: Pizzas_IngredientessController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Pizzas_Ingredientes>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: Pizzas_IngredientessController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas_IngredientessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizzas_Ingredientes data)
        {
            try
            {
                var newData = Crud<Pizzas_Ingredientes>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Pizzas_IngredientessController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Pizzas_Ingredientes>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: Pizzas_IngredientessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizzas_Ingredientes data)
        {
            try
            {
                Crud<Pizzas_Ingredientes>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                // You can use any logging framework or mechanism here
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Add a user-friendly error message to the ModelState
                ModelState.AddModelError("", "An error occurred while updating the department. Please try again.");

                // Optionally, you can add the exception message for more details
                // ModelState.AddModelError("", ex.Message);

                // Return to the view with the same data to allow the user to try again
                return View(data);
            }
        }


        // GET: Pizzas_IngredientessController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Pizzas_Ingredientes>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: Pizzas_IngredientessController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pizzas_Ingredientes data)
        {
            try
            {
                Crud<Pizzas_Ingredientes>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
