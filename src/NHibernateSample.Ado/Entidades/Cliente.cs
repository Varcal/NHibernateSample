using System;

namespace NHibernateSample.Ado.Entidades
{
    public class Cliente: Pessoa
    {
        public DateTime DataUltimaCompra { get; private set; }

        public Cliente(string nome, DateTime dataUltimaCompra)
        {
            Nome = nome;
            DataUltimaCompra = dataUltimaCompra;
        }
    }
}
