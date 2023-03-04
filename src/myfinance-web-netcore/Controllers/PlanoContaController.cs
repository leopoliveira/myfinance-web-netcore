using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class PlanoContaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<PlanoContaViewModel> model = new List<PlanoContaViewModel>();;

            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue)
            {

            }
            return View(new PlanoContaViewModel());
        }

        [HttpPost]
        public IActionResult Salvar(PlanoContaViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(new PlanoContaViewModel());
        }
    }
}