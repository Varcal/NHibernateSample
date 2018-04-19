using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernateSample.Ado.Entidades;
using NHibernateSample.Ado.Servicos;
using NHibernateSample.Data.Dao;
using NHibernateSample.Data.Entidades;

namespace NHibernateSample.Tests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        [TestCategory("Cliente serviço")]
        public void Inserir_novo_cliente()
        {
            var cliente = new Cliente("Maria José", DateTime.Today);

            var servico = new ClienteServico();

            var retorno = servico.Inserir(cliente);

            Assert.AreNotEqual(0, retorno);
        }

        [TestMethod]
        [TestCategory("Teste transação Nhibernate Ado")]
        public void Inserir_Teste()
        {
            var cliente = new Cliente("Teste NH", DateTime.Today);
            var servico = new ClienteServico();
            var nhDao = new TesteDao();

            using(var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions(){IsolationLevel = IsolationLevel.ReadCommitted}))
            {
                var retorno = servico.Inserir(cliente);
                var teste = nhDao.Inserir(new Teste("Teste Descrição"));

                Assert.AreNotEqual(0, retorno);
                Assert.IsNotNull(teste);

                scope.Complete();
            }           
        }
    }
}
