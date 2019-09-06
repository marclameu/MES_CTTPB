using System;
using System.Collections.Generic;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP.Domain.Interfaces
{
    public interface ITremCarregamentoServices
    {
        void SalvarTremCarregamento(TremCarregamento trem);
    }
}
