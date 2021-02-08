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
    public class VeiculoService : IVeiculoService
    {
        private readonly Context _context;
        public VeiculoService(Context context)
        {
            _context = context;
        }
        public void GravarVeiculo(Veiculo veiculo)
        {
            if (veiculo.IdVeiculo > 0)
            {
                _context.Veiculo.Update(veiculo);
            }
            else
            {
                _context.Veiculo.Add(veiculo);
            }
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Veiculo>> ListarVeiculos()
        {
            var Veiculos = _context.Veiculo.ToList(); 

            return Veiculos;
        }
    }
}
