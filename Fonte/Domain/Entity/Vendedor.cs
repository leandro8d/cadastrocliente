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

        public Vendedor(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            Cliente = new HashSet<Cliente>();

            Consistir(true);
        }

        public void Atualizar(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
           
            Consistir(false);
        }

        public void Consistir(bool inclusao)
        {

            if (!inclusao)
            {
                if (IdVendedor <= 0)
                {
                    throw new Exception("Vendedor Invalido");
                }
            }
            
                var erros = new List<Exception>();
                if (String.IsNullOrEmpty(Nome))
                {
                    erros.Add(new Exception("Nome invalido"));
                }

                if (String.IsNullOrEmpty(Cpf))
                {
                    erros.Add(new Exception("CPF Invalido"));
                }

              

                if (erros.Count > 0)
                {
                    throw new Exception("Erros Encontrados: " + String.Join(", ", erros));
                }
            }
        

        public bool PodeDeletar()
        {
            if (Cliente !=null && Cliente.Count > 0) {
                throw new Exception("Nao e possivel excluir um vendedor vinculado a um cliente!");
            }
            Consistir(false);
            return true;
        }


    }
}
