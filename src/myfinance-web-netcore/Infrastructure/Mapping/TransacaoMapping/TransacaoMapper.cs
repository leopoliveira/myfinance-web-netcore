using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Infrastructure.Mapping.PlanoContaMapping;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Infrastructure.Mapping.TransacaoMapping
{
    public class TransacaoMapper
    {
        public static Transacao ToEntity(TransacaoViewModel viewModel)
        {
            Transacao transacao = new Transacao();

            transacao.Id = viewModel.Id;
            transacao.Historico = viewModel.Historico;
            transacao.Valor = viewModel.Valor;
            transacao.Data = viewModel.Data;
            transacao.PlanoContaId = viewModel.PlanoContaId;
            transacao.PlanoConta = PlanoContaMapper.ToEntity(viewModel.PlanoDeConta);

            return transacao;
        }

        public static TransacaoViewModel ToViewModel(Transacao entity)
        {
            TransacaoViewModel viewModel = new TransacaoViewModel();

            viewModel.Id = entity.Id;
            viewModel.Historico = entity.Historico;
            viewModel.Valor = entity.Valor;
            viewModel.Data = entity.Data;
            viewModel.PlanoContaId = entity.PlanoContaId;
            viewModel.PlanoDeConta = PlanoContaMapper.ToViewModel(entity.PlanoConta);

            return viewModel;
        }
        
    }
}