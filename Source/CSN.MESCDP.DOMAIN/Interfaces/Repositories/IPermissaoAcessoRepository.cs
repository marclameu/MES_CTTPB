using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using NHibernate;

namespace CTTPB.MESCDP.Domain.Interfaces.Repositories
{
    public interface IPermissaoAcessoRepository : IGenericRepository<PermissaoAcesso>
    {
        IList<PermissaoAcesso> FindByFields(int? idPermtAcss, string cdGrupoAd, string nmAcao, string nmFncaoMes);

        IList<string> ObtemTodosGruposMes();
        IList<PermissaoAcesso> FindPorGruposAd(IList<string> nomeAd);
    }
}
