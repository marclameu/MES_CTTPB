using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP.Domain.Interfaces.Repositories
{
    public interface IComposicaoTremRepository: IGenericRepository<ComposicaoTrem>
    {
        IList<ComposicaoTrem> GetComposicaoTremListaPorID(int idTrem);
        IList<ComposicaoTrem> GetComposicaoComPesos(string cdPfxoTremCrga, int IdTrem, DateTime dataInicio, DateTime dataTermino, string flTernCtrlSist);
    }
}
