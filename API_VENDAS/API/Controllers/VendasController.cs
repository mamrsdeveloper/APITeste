using Business.Service;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : Controller
    {
        private readonly Context _context;
        public VendasController(Context context)
        {
            _context = context;

        }
        [HttpGet]
        [Route("ObterVendas")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var vendas = await new VendasService(_context)
                    .ObterVendas(Id);

                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("GravarVendaVeiculo")]
        public IActionResult Set([FromBody] Vendas vendas)
        {
            try
            {
                new VendasService(_context)
                    .GravarVendaVeiculo(vendas);

                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AtualizarVenda")]
        public async Task<IActionResult> Put(int IdVenda, StatusVendas status)
        {
            try
            {
                new VendasService(_context)
                   .AtualizarVenda(IdVenda, Convert.ToInt32(status));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
