using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP.Domain.Interfaces
{
    public interface ITipoEquipamentoServices
    {
        int SalvarTipoEquipamento(TipoEquipamento tipoEquipamento);
        void AtualizarTipoEquipamento(TipoEquipamento tipoEquipamento);
        void ExcluirTipoEquipamento(int idTipoEquipamento);
    }
}
