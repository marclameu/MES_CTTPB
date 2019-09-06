using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable]
    public partial class Acao: Auditable
    {
        public Acao() { }
        public virtual string NmAcao { get; set; }
        //public virtual IList<AcaoFuncionalidadeMes> AcaoFuncionalidadeMesLista { get; set; }
        public partial class Atributos
        {
            public static string NmAcao = ((MemberExpression)((Expression<Func<Acao, System.String>>)(a => a.NmAcao)).Body).Member.Name;
            //public static string AcaoFuncionalidadeMesLista = ((MemberExpression)((Expression<Func<Acao, IList<AcaoFuncionalidadeMes>>>)(a => a.AcaoFuncionalidadeMesLista)).Body).Member.Name;
        }
    }
}
