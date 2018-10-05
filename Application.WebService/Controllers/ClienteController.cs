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

        [HttpGet("listar")]
        public IActionResult Listar() {
            try
            {
                var clienteRepo = new ClienteRepository();
                var clientes = clienteRepo.ListAll();

                return Ok(clientes);
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

                return Ok("Cliente Incluido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("")]
        public IActionResult Atualizar([FromBody]ClienteDTO dto)
        {
            try
            {
                var clienteRepo = new ClienteRepository();
                var cliente = new Cliente();
                cliente.Atualizar(dto.Nome, dto.Cnpj, dto.DataNascimento, dto.IdVendedor);

                return Ok("Cliente Atualizado!");
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

                return Ok("Cliente Excluido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}