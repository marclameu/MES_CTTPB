using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using CTTPB.MESCDP.DOMAIN;
using NHibernate;
using NHibernate.Criterion;

namespace CTTPB.MESCDP.Infrastructure.Data.Repositories
{
    public class TipoEquipamentoRepository : GenericRepository<TipoEquipamento>, ITipoEquipamentoRepository
    {
        public PaginationInfo<TipoEquipamento> FindTipoEquipamentos(string cdTipoEqpm, string txDscrTipoEqpm, string flEqpmModel, PaginationInfo<TipoEquipamento> paginationInfo)
        {
            var criteria = Session.CreateCriteria(typeof(TipoEquipamento));
            if (!string.IsNullOrEmpty(cdTipoEqpm))
                criteria.Add(Restrictions.Like(TipoEquipamento.Atributos.CdTipoEqpm, cdTipoEqpm, MatchMode.Anywhere));
            if (!string.IsNullOrEmpty(txDscrTipoEqpm))
                criteria.Add(Restrictions.Like(TipoEquipamento.Atributos.TxDscrTipoEqpm, txDscrTipoEqpm, MatchMode.Anywhere));
            if (!string.IsNullOrEmpty(flEqpmModel))
                criteria.Add(Restrictions.Eq(TipoEquipamento.Atributos.FlEqpmMovel, flEqpmModel));
            var crit = (ICriteria)criteria.Clone();

            paginationInfo.List = FindAll(criteria, paginationInfo);
            //paginationInfo.Total = Count(criteria);

            paginationInfo.Total = crit.SetProjection(Projections.RowCountInt64()).UniqueResult<long>();

            return paginationInfo;
        }
    }
}
