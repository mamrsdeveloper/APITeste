using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IVendedorService
    {
        bool IsValid(String Codigo);

        void GravarVendedor(Vendedor vendedor);

        Task<IEnumerable<Vendedor>> ListarVendedor();
    }
}
