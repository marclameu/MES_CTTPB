using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class PesagemVagaoMap : ClassMap<PesagemVagao> {
        
        public PesagemVagaoMap() {
			Table("T_PESAGEM_VAGAO");
			CompositeId().KeyProperty(x => x.IdTrem, "ID_TREM")
			             .KeyProperty(x => x.CdVclo, "CD_VCLO")
			             .KeyProperty(x => x.IdTern, "ID_TERN");
			References(x => x.ComposicaoTrem01).Column("ID_TREM");
			//References(x => x.Terminal).Column("ID_TERN");
			Map(x => x.PsTaraVagao).Column("PS_TARA_VAGAO").Not.Nullable().Precision(11).Scale(3);
			Map(x => x.PsVagaoBruto).Column("PS_VAGAO_BRUTO").Not.Nullable().Precision(11).Scale(3);
			Map(x => x.DtUltAtual).Column("DT_ULT_ATUAL").Not.Nullable();
			Map(x => x.IdMtricUsuaUltAtual).Column("ID_MTRIC_USUA_ULT_ATUAL").Not.Nullable().Length(10);
        }
    }
}
