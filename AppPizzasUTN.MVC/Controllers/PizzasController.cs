using AppPizzasUTNConsumeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppPizzasUTN.Entidades;

namespace AppPizzasUTN.MVC.Controllers
{
    public class PizzasController : Controller
    {
        private string urlApi;

        public PizzasController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Pizzas";
        }
        // GET: PizzasController
        public ActionResult Index()
        {
            var data = Crud<Pizza>.Read(urlApi);
            return View(data);
        }

        // GET: PizzasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Pizza>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: PizzasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza data)
        {
            try
            {
                var newData = Crud<Pizza>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PizzasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Pizza>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: PizzasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza data)
        {
            try
            {
                Crud<Pizza>.Update(urlApi, id, data);
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


        // GET: PizzasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Pizza>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: PizzasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pizza data)
        {
            try
            {
                Crud<Pizza>.Delete(urlApi, id);
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
