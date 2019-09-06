using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using CTTPB.MESCDP;
using CTTPB.MESCDP.Domain.Entities;

namespace CTTPB.MESCDP {
    
    
    public class AcaoFuncionalidadeMesMap : ClassMap<AcaoFuncionalidadeMes> {
        
        public AcaoFuncionalidadeMesMap() {
			Table("T_ACAO_FUNCIONALIDADE_MES");
			CompositeId().KeyProperty(x => x.NmAcao, "NM_ACAO")
			             .KeyProperty(x => x.NmFncaoMes, "NM_FNCAO_MES");
			References(x => x.Acao01).Column("NM_ACAO");
			References(x => x.FuncionalidadeMes01).Column("NM_FNCAO_MES");
            HasMany<PermissaoAcesso>(x => x.PermissaoAcessoLista)
                .AsBag()
                .KeyColumns.Add("NM_ACAO", "NM_FNCAO_MES");
            
        }
    }
}
