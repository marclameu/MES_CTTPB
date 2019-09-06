using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class TremCarregamentoMap : ClassMap<TremCarregamento> {
        
        public TremCarregamentoMap() {
			Table("T_TREM_CARREGAMENTO");
			Id(x => x.IdTrem).GeneratedBy.Identity().Column("ID_TREM");
			//References(x => x.RecursoApropriacaoEvento).Column("ID_RECS_APRP_EVNT");
			//References(x => x.IdTernOrig).Column("ID_TERN_ORIG");
			//References(x => x.IdTernDstn).Column("ID_TERN_DSTN");
			Map(x => x.CdTabl).Column("CD_TABL").Length(10);
			Map(x => x.CdPfxoTremVazia).Column("CD_PFXO_TREM_VAZIA").Length(12);
			Map(x => x.CdPfxoTremCrga).Column("CD_PFXO_TREM_CRGA").Length(12);
			Map(x => x.DtDispTremEmbq).Column("DT_DISP_TREM_EMBQ");
			Map(x => x.DtRefrPrgmCrga).Column("DT_REFR_PRGM_CRGA");
			Map(x => x.FlSituaTrem).Column("FL_SITUA_TREM").Not.Nullable().Length(1);
			Map(x => x.IdTremMina).Column("ID_TREM_MINA").Precision(10);
			Map(x => x.DtUltAtual).Column("DT_ULT_ATUAL").Not.Nullable();
			Map(x => x.FlEnvioTremIntgr).Column("FL_ENVIO_TREM_INTGR").Length(1);
			//Map(x => x.QtVagoAguaLivr).Column("QT_VAGO_AGUA_LIVR").Precision(10);
			HasMany(x => x.ComposicaoTremLista).KeyColumn("ID_TREM");
			//HasMany(x => x.DesmembramentoTrem).KeyColumn("ID_TREM");
			//HasMany(x => x.Despacho).KeyColumn("ID_TREM");
			//HasMany(x => x.EmbarqueFerroviario).KeyColumn("ID_TREM_CRGA");
        }
    }
}
