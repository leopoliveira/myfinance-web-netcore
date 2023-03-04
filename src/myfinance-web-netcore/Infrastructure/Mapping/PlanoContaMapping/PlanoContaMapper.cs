using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Infrastructure.Mapping.PlanoContaMapping
{
    public class PlanoContaMapper
    {
        public static PlanoConta ToEntity(PlanoContaViewModel viewModel)
        {
            PlanoConta planoConta = new PlanoConta();

            planoConta.Id = viewModel.Id;
            planoConta.Descricao = viewModel.Descricao;
            planoConta.Tipo = viewModel.Tipo;

            return planoConta;
        }

        public static PlanoContaViewModel ToViewModel(PlanoConta entity)
        {
            PlanoContaViewModel viewModel = new PlanoContaViewModel();

            viewModel.Id = entity.Id;
            viewModel.Descricao = entity.Descricao;
            viewModel.Tipo = entity.Tipo;

            return viewModel;
        }
    }
}