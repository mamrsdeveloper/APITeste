using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IVeiculoService
    {        
        void GravarVeiculo(Veiculo veiculo);

        Task<IEnumerable<Veiculo>> ListarVeiculos();
    }
}
