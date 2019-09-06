using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class PermissaoAcessoMap : ClassMap<PermissaoAcesso> {
        
        public PermissaoAcessoMap() {
			Table("T_PERMISSAO_ACESSO");
			Id(x => x.IdPermtAcss).GeneratedBy.Identity().Column("ID_PERMT_ACSS");
			References(x => x.AcaoFuncionalidadeMes01).Column("NM_ACAO");
			//References(x => x.Processo).Column("CD_PLANTA");
			Map(x => x.CdGrupoAd).Column("CD_GRUPO_AD").Not.Nullable().Length(100);
        }
    }
}
