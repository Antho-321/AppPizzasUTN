using AppPizzasUTN.Entidades;
using AppPizzasUTNConsumeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppIngredientesUTN.MVC.Controllers
{
    public class IngredientesController : Controller
    {
        private string urlApi;

        public IngredientesController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Ingredientes";
        }
        // GET: IngredientesController
        public ActionResult Index()
        {
            var data = Crud<Ingrediente>.Read(urlApi);
            return View(data);
        }

        // GET: IngredientesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Ingrediente>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: IngredientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingrediente data)
        {
            try
            {
                var newData = Crud<Ingrediente>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: IngredientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Ingrediente>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: IngredientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ingrediente data)
        {
            try
            {
                Crud<Ingrediente>.Update(urlApi, id, data);
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


        // GET: IngredientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Ingrediente>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: IngredientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ingrediente data)
        {
            try
            {
                Crud<Ingrediente>.Delete(urlApi, id);
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
