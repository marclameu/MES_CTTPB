using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.DOMAIN;

namespace CTTPB.MESCDP.Domain.Interfaces.Repositories
{
    public interface ITipoEquipamentoRepository : IGenericRepository<TipoEquipamento>
    {
        PaginationInfo<TipoEquipamento> FindTipoEquipamentos(string cdTipoEqpm, string txDscrTipoEqpm, string flEqpmModel, PaginationInfo<TipoEquipamento> paginationInfo);
    }
}
