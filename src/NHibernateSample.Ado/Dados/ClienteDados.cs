using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using NHibernateSample.Ado.Entidades;
using IsolationLevel = System.Transactions.IsolationLevel;


namespace NHibernateSample.Ado.Dados
{
    public class ClienteDados
    {
        public int Inserir(int pessoaId, Cliente cliente)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var connStr = $"Data Source=localhost;Initial Catalog=NHibernateSampleDb;Integrated Security=true;";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    var sqlCommand = conn.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "uspClienteInserir";
                    sqlCommand.Parameters.Add(new SqlParameter("@PessoaId", pessoaId));
                    sqlCommand.Parameters.Add(new SqlParameter("@DataUltimaCompra", cliente.DataUltimaCompra));

                    var retorno = sqlCommand.ExecuteScalar();
                    scope.Complete();
                    return Convert.ToInt32(retorno);
                }
            }
        }
    }
}
