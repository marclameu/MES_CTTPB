using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using NHibernate.Criterion;

namespace CTTPB.MESCDP.Infrastructure.Data.Repositories
{
    public class AcaoFuncionalidadeMesRepository : GenericRepository<AcaoFuncionalidadeMes>, IAcaoFuncionalidadeMesRepository
    {
        public IList<AcaoFuncionalidadeMes> getByGrupos(IList<string> nomesGrupos)
        {
            var criteria = Session.CreateCriteria<AcaoFuncionalidadeMes>();
            criteria.Add(Restrictions.In("permissaoAcesso." + PermissaoAcesso.Atributos.CdGrupoAd,
                nomesGrupos.ToArray()));

            return criteria.List<AcaoFuncionalidadeMes>();
        }
    }
}
