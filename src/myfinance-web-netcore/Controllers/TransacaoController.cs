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
        private readonly ITransacaoRepository _TransacaoRepository;
        private readonly IPlanoContaRepository _PlanoContaRepository;
        
        public TransacaoController(ITransacaoRepository TransacaoRepository)
        {
            _TransacaoRepository = TransacaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Transacao> Transacoes = await _TransacaoRepository.GetAll();
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

            IEnumerable<PlanoConta> PlanoContas = await _PlanoContaRepository.GetAll();

            if (PlanoContas != null)
            {
                foreach (PlanoConta PlanoConta in PlanoContas)
                {
                    model.PlanoContas.Add(PlanoContaMapper.ToViewModel(PlanoConta));
                }
            }

            if (id.HasValue && id.Value > 0)
            {
                Transacao Transacao = await _TransacaoRepository.GetById(id.Value);

                if (Transacao == null)
                {
                    return View(model);
                }

                model = TransacaoMapper.ToViewModel(Transacao);
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(TransacaoViewModel model)
        {
            Transacao transacao = TransacaoMapper.ToEntity(model);

            if (transacao.Id > 0)
            {
                await _TransacaoRepository.Update(transacao);
            }
            else
            {
                await _TransacaoRepository.Add(transacao);
            }

            return RedirectToAction("Index");
        }
    }
}