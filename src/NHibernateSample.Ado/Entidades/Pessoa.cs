﻿namespace NHibernateSample.Ado.Entidades
{
    public abstract class Pessoa
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
    }
}
