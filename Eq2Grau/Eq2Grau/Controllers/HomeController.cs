using System.Diagnostics;
using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eq2Grau.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }


        public IActionResult Index(int A, int B, int C) {

            //vars auxiliares
            double delta = B * B - 4 * A * C;
            string x1 = "", x2 = "";

            //posso calcular as raízes?
            if (A != 0) {
                //há raízes reais?
                if (delta >= 0) {
                    //sim, há 
                    //x1 = (-b + sqrt(b2-4ac))/(2a)
                    //x2 = (-b - sqrt(b2 - 4ac)) / 2 / a
                    x1 = (-B + Math.Sqrt(delta))/(2*A) + "";
                    x2 = (-B - Math.Sqrt(delta)) / 2 / A + "";
                }
                else {
                    //não há reais
                    //x1 = -b/2/a + sqrt(-delta) /2/a i
                    //x2 = -b / 2 / a - sqrt(-delta) / 2 / a i
                    x1 = -B / 2 / A + " + " + Math.Sqrt(-delta) / 2 / A + " i";
                    x2 = -B / 2 / A + " - " + Math.Sqrt(-delta) / 2 / A + " i";

                }
            }

            //preparar os dados para serem enviados para a View
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;

            return View();
        }


        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}