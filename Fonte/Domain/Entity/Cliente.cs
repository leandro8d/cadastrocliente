using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Cliente
    {
        public long IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataNascimento { get; set; }
        public long IdVendedor { get; set; }

        public Vendedor Vendedor { get; set; }

        public Cliente() { }

        public Cliente(string nome, string cnpj, DateTime? dataNascimento, long idVendedor)
        {
            this.Nome = nome;
            this.Cnpj = cnpj;
            this.DataNascimento = dataNascimento;
            this.IdVendedor = idVendedor;
            Consistir(true);
        }

        public void Atualizar(string nome, string cnpj, DateTime? dataNascimento, long idVendedor) {
            this.Nome = nome;
            this.Cnpj = cnpj;
            this.DataNascimento = dataNascimento;
            this.IdVendedor = idVendedor;
            Consistir(false);
        }

        //consitencia para criaçao ou editaçao de registro
        public void Consistir(bool inclusao)
        {

            var erros = new List<Exception>();

            if (!inclusao)
            {
                if(IdCliente <= 0 )
                throw new Exception("Cliente Invalido");

            }
         
                if (String.IsNullOrEmpty(Nome))
                {
                    erros.Add(new Exception("Nome invalido"));
                }

                if (String.IsNullOrEmpty(Cnpj))
                {
                    erros.Add(new Exception("CNPJ Invalido"));
                }

                if (IdVendedor <= 0) {
                    erros.Add(new Exception("Vendedor Invalido"));
                }

                if (erros.Count > 0) {
                    throw new Exception("Erros Encontrados: " + String.Join(", ", erros));
                }
            
            
        }


        //Consite se o usuario pode deletar o registro
        public bool PodeDeletar() {

            Consistir(false);
            return true;
        }
    }
}
