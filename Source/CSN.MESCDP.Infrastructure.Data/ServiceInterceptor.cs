using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using CTTPB.MESCDP.Domain;
using log4net;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace CTTPB.MESCDP.Infrastructure.Data
{
    public class TransactionInterceptor : IInterceptor
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TransactionInterceptor));

        public void Intercept(IInvocation invocation)
        {
            if (CanIntercept(invocation))
                using (var session = NHibernateHelper.Session)
                {
                    ITransaction transaction;
                    using (transaction = session.BeginTransaction())
                    {
                        try
                        {
                            invocation.Proceed();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction?.Rollback();
                            Logger.Error(invocation.Method.Name, ex);
                            throw;
                        }
                        finally
                        {
                            session.Clear();
                            session.Close();
                            NHibernateHelper.UnbindSessionContext();
                        }
                    }
                }
            else
                invocation.Proceed();
        }

        public void TestConection()
        {
            using (var session = NHibernateHelper.Session)
            {
                try
                {
                    Logger.Info($"Teste Conexao :  {session.Connection.Database} {session.Connection.State}");

                    session.Clear();
                    session.Close();
                    NHibernateHelper.UnbindSessionContext();
                }
                catch (Exception ex)
                {
                    Logger.Error("Erro ao realizar teste de conexao", ex);
                    throw;
                }
            }

        }

        private static bool CanIntercept(IInvocation invocation)
        {
            var transAttribute = GetMethodTransactionAttribute(invocation);
            if (transAttribute == null) return false;
            var transaction = NHibernateHelper.Session.Transaction;
            return transaction == null || !transaction.IsActive;
        }

        private static TransactionAttribute GetMethodTransactionAttribute(IInvocation invocation)
        {
            foreach (var attr in invocation.Method.GetCustomAttributes(true))
                if (attr is TransactionAttribute attribute)
                    return attribute;
            return null;
        }
    }
}
