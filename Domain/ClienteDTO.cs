using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class ClienteDTO
    {
        public long IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataNascimento { get; set; }
        public long IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
    }
}
