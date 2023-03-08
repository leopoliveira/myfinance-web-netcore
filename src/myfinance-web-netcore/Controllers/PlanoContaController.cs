using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.Mapping.PlanoContaMapping;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly IPlanoContaRepository _planoContaRepository;
        
        public PlanoContaController(IPlanoContaRepository planoContaRepository)
        {
            _planoContaRepository = planoContaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlanoConta> planoContas = await _planoContaRepository.GetAll();
            ICollection<PlanoContaViewModel> planoContaViewModel = new List<PlanoContaViewModel>();

            if (planoContas == null)
            {
                return View(new List<PlanoContaViewModel>());
            }

            foreach (PlanoConta planoConta in planoContas)
            {
                planoContaViewModel.Add(PlanoContaMapper.ToViewModel(planoConta));
            }

            return View(planoContaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                PlanoConta planoConta = await _planoContaRepository.GetById(id.Value);

                if (planoConta == null)
                {
                    return View(new PlanoContaViewModel());
                }

                PlanoContaViewModel planoContaViewModel = PlanoContaMapper.ToViewModel(planoConta);
                return View(planoContaViewModel);
            }

            return View(new PlanoContaViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PlanoContaViewModel model)
        {
            PlanoConta planoConta = PlanoContaMapper.ToEntity(model);

            if (planoConta.Id > 0)
            {
                await _planoContaRepository.Update(planoConta);
            }
            else
            {
                await _planoContaRepository.Add(planoConta);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            PlanoConta planoConta = await _planoContaRepository.GetById(id);

            if (planoConta != null)
            {
                return View(PlanoContaMapper.ToViewModel(planoConta));
            }

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(PlanoContaViewModel model)
        {
            PlanoConta planoConta = PlanoContaMapper.ToEntity(model);

            if (planoConta != null)
            {
                await _planoContaRepository.Delete(planoConta);
            }

            return RedirectToAction("Index");
        }
    }
}