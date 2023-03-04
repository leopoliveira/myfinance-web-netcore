using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class TransacaoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<TransacaoViewModel> model = new List<TransacaoViewModel>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue)
            {

            }
            TransacaoViewModel model = new TransacaoViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Salvar(TransacaoViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(new TransacaoViewModel());
        }
    }
}