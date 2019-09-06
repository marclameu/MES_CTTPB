using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP.Domain.Interfaces.Repositories
{
    public interface IAcaoFuncionalidadeMesRepository: IGenericRepository<AcaoFuncionalidadeMes>
    {
        IList<AcaoFuncionalidadeMes> getByGrupos(IList<string> nomesGrupos);
    }
}
