using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.Mapping.PlanoContaMapping;
using myfinance_web_netcore.Infrastructure.Mapping.TransacaoMapping;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IPlanoContaRepository _planoContaRepository;
        
        public TransacaoController(ITransacaoRepository TransacaoRepository, IPlanoContaRepository PlanoContaRepository)
        {
            _transacaoRepository = TransacaoRepository;
            _planoContaRepository = PlanoContaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Transacao> Transacoes = await _transacaoRepository.GetAll();
            ICollection<TransacaoViewModel> TransacaoViewModel = new List<TransacaoViewModel>();

            if (Transacoes == null)
            {
                return View(new List<TransacaoViewModel>());
            }

            foreach (Transacao Transacao in Transacoes)
            {
                TransacaoViewModel.Add(TransacaoMapper.ToViewModel(Transacao));
            }

            return View(TransacaoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            TransacaoViewModel model = new TransacaoViewModel();

            if (id.HasValue && id.Value > 0)
            {
                Transacao Transacao = await _transacaoRepository.GetById(id.Value);

                if (Transacao == null)
                {
                    await GetPlanoContas(model);

                    model.Data = DateTime.Now;

                    return View(model);
                }

                model = TransacaoMapper.ToViewModel(Transacao);

                await GetPlanoContas(model);

                return View(model);
            }

            await GetPlanoContas(model);

            model.Data = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(TransacaoViewModel model)
        {
            Transacao transacao = TransacaoMapper.ToEntity(model);

            if (transacao.Id > 0)
            {
                await _transacaoRepository.Update(transacao);
            }
            else
            {
                await _transacaoRepository.Add(transacao);
            }

            return RedirectToAction("Index");
        }

        private async Task<TransacaoViewModel> GetPlanoContas(TransacaoViewModel model)
        {
            IEnumerable<PlanoConta> planosDeConta = await _planoContaRepository.GetAll();

            if (planosDeConta != null)
            {
                foreach (PlanoConta planoDeConta in planosDeConta)
                {
                    model.PlanoContas.Add(PlanoContaMapper.ToViewModel(planoDeConta));
                }
            }

            return model;
        }
    }
}