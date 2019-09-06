using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class TipoEquipamentoMap : ClassMap<TipoEquipamento> {
        
        public TipoEquipamentoMap() {
			Table("T_TIPO_EQUIPAMENTO");
			Id(x => x.CdTipoEqpm).GeneratedBy.Assigned().Column("CD_TIPO_EQPM");
			Map(x => x.TxDscrTipoEqpm).Column("TX_DSCR_TIPO_EQPM").Not.Nullable().Length(100);
			Map(x => x.FlEqpmMovel).Column("FL_EQPM_MOVEL").Not.Nullable().Length(1);
			Map(x => x.DtUltAtual).Column("DT_ULT_ATUAL").Not.Nullable();
			Map(x => x.IdMtricUsuaUltAtual).Column("ID_MTRIC_USUA_ULT_ATUAL").Not.Nullable().Length(10);
			//HasMany(x => x.Equipamento).KeyColumn("CD_TIPO_EQPM");
			//HasMany(x => x.EventoArvoreTipoEquipamento).KeyColumn("CD_TIPO_EQPM");
			//HasMany(x => x.TipoEquipamentoPlanta).KeyColumn("CD_TIPO_EQPM");
        }
    }
}
