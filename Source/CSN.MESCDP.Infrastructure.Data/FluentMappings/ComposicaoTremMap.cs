using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class ComposicaoTremMap : ClassMap<ComposicaoTrem> {
        
        public ComposicaoTremMap() {
			Table("T_COMPOSICAO_TREM");
			CompositeId().KeyProperty(x => x.IdTrem, "ID_TREM")
			             .KeyProperty(x => x.CdVclo, "CD_VCLO");
			//References(x => x.TremCarregamento).Column("ID_TREM");
			//References(x => x.ClassificacaoVeiculo).Column("ID_CLSS_VCLO");
			//References(x => x.VagaoTardio).Column("ID_VAGAO_ATRS");
			//References(x => x.Despacho).Column("ID_DESPACHO");
			//References(x => x.NotaFiscal).Column("ID_NOTA_FISCAL");
			Map(x => x.FlTipoVclo).Column("FL_TIPO_VCLO").Not.Nullable().Length(1);
			Map(x => x.NuPoscVagao).Column("NU_POSC_VAGAO").Precision(10);
			Map(x => x.PsTaraVagaoCrgaDscg).Column("PS_TARA_VAGAO_CRGA_DSCG").Precision(11).Scale(3);
			Map(x => x.PsBrutoVagaoCrgaDscg).Column("PS_BRUTO_VAGAO_CRGA_DSCG").Precision(11).Scale(3);
			Map(x => x.PsAprvVagaoAtrs).Column("PS_APRV_VAGAO_ATRS").Precision(11).Scale(3);
			Map(x => x.FlSituaVagaoTrem).Column("FL_SITUA_VAGAO_TREM").Not.Nullable().Length(1);
			Map(x => x.FlSituaVagaoAtrs).Column("FL_SITUA_VAGAO_ATRS").Not.Nullable().Length(1);
			Map(x => x.TxJustRetrVagao).Column("TX_JUST_RETR_VAGAO").Length(200);
			Map(x => x.TxJustPerdaMter).Column("TX_JUST_PERDA_MTER").Length(200);
			Map(x => x.DtUltAtual).Column("DT_ULT_ATUAL").Not.Nullable();
			Map(x => x.NuVers).Column("NU_VERS").Not.Nullable().Precision(10);
			Map(x => x.CdDpstvSegr).Column("CD_DPSTV_SEGR").Length(50);
            HasMany<PesagemVagao>(x => x.PesagemVagaoLista)
                .AsBag()
                .KeyColumns.Add("CD_VCLO", "ID_TREM");
            //HasMany(x => x.PesagemVagaoLista).KeyColumns(new string[] { "CD_VCLO", "ID_TREM" });
        }
    }
}
