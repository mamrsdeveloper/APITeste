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
    public class VendedorService : IVendedorService
    {
        private readonly Context _context;
        public VendedorService(Context context)
        {
            _context = context;
        }
        public bool IsValid(string Codigo)
        {
            bool IsValid = false;
            if (_context.Vendedor.Where(v => v.Codigo == Codigo).FirstOrDefault() != null)
            {
                IsValid = true;
            }
            return IsValid;
        }

        public void GravarVendedor(Vendedor vendedor)
        {
            if (vendedor.IdVendedor > 0)
            {
                _context.Vendedor.Update(vendedor);
            }
            else
            {
                _context.Vendedor.Add(vendedor);
            }
            _context.SaveChanges();

        }

        public async Task<IEnumerable<Vendedor>> ListarVendedor()
        {
            var vendedor = _context.Vendedor.ToList();

            return vendedor;
        }
    }
}
