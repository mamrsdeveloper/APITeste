using Business.Service;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private readonly Context _context;
        public VendedorController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListarVendedor")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vedendor = await new VendedorService(_context)
                    .ListarVendedor();

                return Ok(vedendor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("GravarVedendor")]
        public IActionResult Set(Vendedor vendedor)
        {
            try
            {
                new VendedorService(_context).GravarVendedor(vendedor);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
