using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using NHibernate.Util;

namespace CTTPB.MESCDP.Domain.Services
{
    public class TremCarregamentoServices : ITremCarregamentoServices
    {
        private ITremCarregamentoRepository _tremCarregamentoRepository;
        public TremCarregamentoServices(ITremCarregamentoRepository tremCarregamentoRepository)
        {
            _tremCarregamentoRepository = tremCarregamentoRepository;
        }
        [TransactionAttribute]
        public virtual void SalvarTremCarregamento(TremCarregamento trem)
        {
            trem.ComposicaoTremLista.ToList().ForEach(ct =>
            {
                ct.PesagemVagaoLista.ToList().ForEach(pv => { pv.IdTern = trem.Terminal02.IdTern; });
            });
            _tremCarregamentoRepository.Update(trem);
        }


    }
}
