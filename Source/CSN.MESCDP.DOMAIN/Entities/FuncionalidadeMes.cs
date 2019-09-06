using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable()]
    public partial class FuncionalidadeMes : Auditable
    {
        public FuncionalidadeMes() { }
        public virtual string NmFncaoMes { get; set; }
        public virtual IList<AcaoFuncionalidadeMes> AcaoFuncionalidadeMesLista { get; set; }
        public partial class Atributos
        {
            public static string NmFncaoMes = ((MemberExpression)((Expression<Func<FuncionalidadeMes, System.String>>)(a => a.NmFncaoMes)).Body).Member.Name;
            public static string AcaoFuncionalidadeMesLista = ((MemberExpression)((Expression<Func<FuncionalidadeMes, IList<AcaoFuncionalidadeMes>>>)(a => a.AcaoFuncionalidadeMesLista)).Body).Member.Name;
        }
    }
}
