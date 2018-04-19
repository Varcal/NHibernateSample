using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using NHibernateSample.Ado.Dados;
using NHibernateSample.Ado.Entidades;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace NHibernateSample.Ado.Servicos
{
    public class ClienteServico
    {
        private readonly PessoaDados _pessoaDados;
        private readonly ClienteDados _clienteDados;

        public ClienteServico()
        {
            _pessoaDados = new PessoaDados();
            _clienteDados = new ClienteDados();
        }

        public int Inserir(Cliente cliente)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var pessoaId = _pessoaDados.Inserir(cliente);
                var clienteId = _clienteDados.Inserir(pessoaId, cliente);

                scope.Complete();
                return clienteId;
            }
        }
    }
}
