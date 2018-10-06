using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repositories
{
    public class VendedorRepository:RepositoryBase<Vendedor>
    {
        public IList<Vendedor> ListarVendedoresSemCliente() {
            var vendedores = from vendedor in this.context.Vendedor
                        where !(from o in this.context.Cliente
                                select o.IdVendedor).Contains(vendedor.IdVendedor)
                        select vendedor;
            return vendedores.ToList();
        }
    }
}
