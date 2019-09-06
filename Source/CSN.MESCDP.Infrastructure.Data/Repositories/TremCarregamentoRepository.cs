using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using NHibernate.Criterion;

namespace CTTPB.MESCDP.Infrastructure.Data.Repositories
{
    public class TremCarregamentoRepository: GenericRepository<TremCarregamento>, ITremCarregamentoRepository
    {
    }
}
