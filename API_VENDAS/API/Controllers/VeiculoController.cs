using Business.Service;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly Context _context;
        public VeiculoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListarVeiculos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vendas = await new VeiculoService(_context)
                    .ListarVeiculos();

                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("GravarVeiculos")]
        public ActionResult Set(Veiculo veiculo)
        {
            try
            {
                new VeiculoService(_context).GravarVeiculo(veiculo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
