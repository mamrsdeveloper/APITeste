using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IVendasSerevice
    {
        Task<Vendas> ObterVendas(int id);

        Vendas GravarVendaVeiculo(Vendas vendas);

        void AtualizarVenda(int idVenda, int Status);

        bool ValidaStatus(int StatusAtual, int Status);
    }
}
