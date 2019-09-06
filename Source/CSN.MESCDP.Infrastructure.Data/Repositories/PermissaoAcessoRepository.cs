using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace CTTPB.MESCDP.Infrastructure.Data.Repositories
{
    public class PermissaoAcessoRepository : GenericRepository<PermissaoAcesso>, IPermissaoAcessoRepository
    {
        public IList<PermissaoAcesso> FindByFields(int? idPermtAcss, string cdGrupoAd, string nmAcao, string nmFncaoMes)
        {
            var criteria = Session.CreateCriteria<PermissaoAcesso>();
            criteria.CreateAlias(PermissaoAcesso.Atributos.AcaoFuncionalidadeMes01, "acaofunc");

            if (idPermtAcss != null)
                criteria.Add(Restrictions.Eq(PermissaoAcesso.Atributos.IdPermtAcss, idPermtAcss));
            if (!string.IsNullOrEmpty(cdGrupoAd))
                criteria.Add(Restrictions.Eq(PermissaoAcesso.Atributos.CdGrupoAd, cdGrupoAd));
            if (!string.IsNullOrEmpty(nmAcao))
                criteria.Add(Restrictions.Eq("acaofunc." + AcaoFuncionalidadeMes.Atributos.NmAcao, nmAcao));
            if (!string.IsNullOrEmpty(nmFncaoMes))
                criteria.Add(Restrictions.Eq("acaofunc." + AcaoFuncionalidadeMes.Atributos.NmFncaoMes, nmFncaoMes));

            return criteria.List<PermissaoAcesso>();
        }

        public IList<PermissaoAcesso> FindPorGruposAd(IList<string> nomeAd)
        {
            var criteria = Session.CreateCriteria<PermissaoAcesso>();
            // criteria.Fetch(SelectMode.Fetch, PermissaoAcesso.Atributos.AcaoFuncionalidadeMes01);

            if (nomeAd != null && nomeAd.Count > 0)
                criteria.Add(Restrictions.In(PermissaoAcesso.Atributos.CdGrupoAd, nomeAd.ToArray()));

            var listaPermissao = criteria.List<PermissaoAcesso>();

            return listaPermissao;
        }

        public IList<string> ObtemTodosGruposMes()
        {

            var hql = @"select distinct p.CdGrupoAd from PermissaoAcesso p";
            IQuery query = Session.CreateQuery(hql);

            return query.List<string>();
        }
    }
}
