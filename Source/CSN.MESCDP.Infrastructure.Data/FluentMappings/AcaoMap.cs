using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class AcaoMap : ClassMap<Acao> {
        
        public AcaoMap() {
			Table("T_ACAO");
			Id(x => x.NmAcao).GeneratedBy.Assigned().Column("NM_ACAO");
			//HasMany(x => x.AcaoFuncionalidadeMes).KeyColumn("NM_ACAO");
        }
    }
}
