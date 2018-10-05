using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Cliente = new HashSet<Cliente>();
        }

        public long IdVendedor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
    }
}
