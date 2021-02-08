using Business.Interfaces;
using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class VendasService : IVendasSerevice
    {
        private readonly Context _context;
        public VendasService(Context context)
        {
            _context = context;
        }
        public async Task<Vendas> ObterVendas(int id)
        {
            var vendas = _context.Vendas.Where(v => v.IdVenda == id).FirstOrDefault();

            return vendas;
        }

        public Vendas GravarVendaVeiculo(Vendas vendas)
        {

            if (!new VendedorService(_context)
                .IsValid(vendas.CodigoVendedor))

                throw new Exception("Vendedor inválido!");

            if (vendas.Veiculos.Count == 0)
                throw new Exception("Preencha pelo menos um veículo para registrar a venda!");


            if (vendas.IdVenda > 0)
                _context.Vendas.Update(vendas);
            else
                _context.Vendas.Add(vendas);

            _context.SaveChanges();

            return vendas;
        }

        public void AtualizarVenda(int idVenda, int Status)
        {
            var venda = _context.Vendas.Where(v => v.IdVenda == idVenda).FirstOrDefault();

            if (venda != null)
            {
                var StatusAtual = venda.Status;

                if (ValidaStatus(StatusAtual, Status))
                    venda.Status = Status;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Alteração de Status não permitida!");
            }
        }

        public bool ValidaStatus(int StatusAtual, int Status)
        {
            bool isValid = false;
            var StatusPosiveis = new List<Status>();
            //Confirmação pagamento > pagamento Aprovado
            StatusPosiveis.Add(new Status()
            {
                StatusDe = (int)StatusVendas.ConfirmacaodePagamento,

                StatusPara = (int)StatusVendas.PagamentoAprovado
            });
            //Confirmação pagamento > Cancelado
            StatusPosiveis.Add(new Status()
            {
                StatusDe = (int)StatusVendas.ConfirmacaodePagamento,

                StatusPara = (int)StatusVendas.Cancelada
            });
            //Confirmação pagamento > Cancelado
            StatusPosiveis.Add(new Status()
            {
                StatusDe = (int)StatusVendas.ConfirmacaodePagamento,

                StatusPara = (int)StatusVendas.Cancelada
            });
            //Pagamento aprovado > Em transporte
            StatusPosiveis.Add(new Status()
            {
                StatusDe = (int)StatusVendas.PagamentoAprovado,

                StatusPara = (int)StatusVendas.EmTransporte
            });
            //Pagamento aprovado > Cancelado
            StatusPosiveis.Add(new Status()
            {
                StatusDe = (int)StatusVendas.PagamentoAprovado,

                StatusPara = (int)StatusVendas.Cancelada
            });
            //Em transporte > Entregue
            StatusPosiveis.Add(new Status()
            {
                StatusDe = (int)StatusVendas.EmTransporte,

                StatusPara = (int)StatusVendas.Entregue
            });

            if (StatusPosiveis.Where(x => x.StatusDe == StatusAtual && x.StatusPara == Status).ToList().Count > 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
