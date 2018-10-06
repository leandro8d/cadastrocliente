using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace Application.WebService.Controllers
{
    [Route("[Controller]")]
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{idVendedor}")]
        public IActionResult Get(long idVendedor)
        {
            try
            {
                var vendedorRepo = new VendedorRepository();
                var vendedor = vendedorRepo.Get(idVendedor);

                return Ok(vendedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar() {
            try
            {
                var vendedorRepo = new VendedorRepository();
                var vendedores = vendedorRepo.ListAll();

                return Ok(vendedores);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPut("")]
        public IActionResult Inserir([FromBody]VendedorDTO dto)
        {
            try
            {
                var vendedorRepo = new VendedorRepository();
                var cliente = new Vendedor(dto.Nome, dto.Cpf);
                vendedorRepo.Add(cliente);

                return Json("Vendedor Incluido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public IActionResult Atualizar([FromBody]VendedorDTO dto)
        {
            try
            {
                var vendedorRepo = new VendedorRepository();
                var vendedor = vendedorRepo.Get(dto.IdVendedor);
                vendedor.Atualizar(dto.Nome, dto.Cpf);
                vendedorRepo.Update(vendedor);

                return Json("Vendedor Atualizado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            try
            {
                var vendedorRepo = new VendedorRepository();
                var vendedor = vendedorRepo.Get(id);
                vendedor.PodeDeletar();
                vendedorRepo.Delete(vendedor);

                return Json("Vendedor Excluido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("vendedorsemcliente")]
        public IActionResult VendedorSemCliente()
        {
            try
            {
                var vendedorRepo = new VendedorRepository();
                var vendedores = vendedorRepo.ListarVendedoresSemCliente().Select(x => new {IdVendedor = x.IdVendedor, Nome = x.Nome });

                return Ok(vendedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}