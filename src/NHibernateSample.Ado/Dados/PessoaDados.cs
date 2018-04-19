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
    public class PessoaDados
    {
        public int Inserir(Pessoa pessoa)
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
                    sqlCommand.CommandText = "uspPessoaInserir";
                    sqlCommand.Parameters.Add(new SqlParameter("@Nome", pessoa.Nome));

                    var retorno = sqlCommand.ExecuteScalar();
                    scope.Complete();
                    return Convert.ToInt32(retorno);
                }
            }          
        }
    }
}
