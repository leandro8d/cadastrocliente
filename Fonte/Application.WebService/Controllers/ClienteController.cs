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
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{idCliente}")]
        public IActionResult Get(long idCliente)
        {
            try
            {
                var clienteRepo = new ClienteRepository();
                var cliente = clienteRepo.Get(idCliente);

                return Ok(cliente);
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
                var clienteRepo = new ClienteRepository();
                var clientes = clienteRepo.ListAll();
                var resultado = clientes.Select(x => new ClienteDTO() { IdCliente = x.IdCliente, Cnpj = x.Cnpj, DataNascimento = x.DataNascimento, IdVendedor = x.IdVendedor, Nome = x.Nome, NomeVendedor = x.Vendedor.Nome });

                return Ok(resultado);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPut("")]
        public IActionResult Inserir([FromBody]ClienteDTO dto)
        {
            try
            {
                var clienteRepo = new ClienteRepository();
                var cliente = new Cliente(dto.Nome, dto.Cnpj, dto.DataNascimento, dto.IdVendedor);
                clienteRepo.Add(cliente);

                return Json("Cliente incluido!"); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public IActionResult Atualizar([FromBody]ClienteDTO dto)
        {
            try
            {
                var clienteRepo = new ClienteRepository();
                var cliente = clienteRepo.Get(dto.IdCliente);
                cliente.Atualizar(dto.Nome, dto.Cnpj, dto.DataNascimento, dto.IdVendedor);
                clienteRepo.Update(cliente);

                return Json("Cliente atualizado!");
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
                var clienteRepo = new ClienteRepository();
                var cliente = clienteRepo.Get(id);
                cliente.PodeDeletar();
                clienteRepo.Delete(cliente);

                return Json("Cliente excluido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      

        

    }
}