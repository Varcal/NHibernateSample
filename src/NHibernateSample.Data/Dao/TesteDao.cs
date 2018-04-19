using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NHibernateSample.Data.Entidades;

namespace NHibernateSample.Data.Dao
{
    public class TesteDao
    {
        public Teste Inserir(Teste teste)
        {
            using (var session = NhibernateConfig.GetSessionFactory().OpenSession())
            {

                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        session.Save(teste);
                        transaction.Commit();

                        return teste;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                
            }
        }
    }
}
