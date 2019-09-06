using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{

    [Serializable()]
    public partial class AcaoFuncionalidadeMes : Auditable
    {
        public AcaoFuncionalidadeMes() { }
        public virtual string NmAcao { get; set; }
        public virtual string NmFncaoMes { get; set; }
        public virtual Acao Acao01 { get; set; }
        public virtual FuncionalidadeMes FuncionalidadeMes01 { get; set; }
        public virtual IList<PermissaoAcesso> PermissaoAcessoLista { get; set; }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public partial class Atributos
        {
            public static string NmAcao = ((MemberExpression)((Expression<Func<AcaoFuncionalidadeMes, System.String>>)(a => a.NmAcao)).Body).Member.Name;
            public static string NmFncaoMes = ((MemberExpression)((Expression<Func<AcaoFuncionalidadeMes, System.String>>)(a => a.NmFncaoMes)).Body).Member.Name;
            public static string Acao01 = ((MemberExpression)((Expression<Func<AcaoFuncionalidadeMes, Acao>>)(a => a.Acao01)).Body).Member.Name;
            public static string FuncionalidadeMes01 = ((MemberExpression)((Expression<Func<AcaoFuncionalidadeMes, FuncionalidadeMes>>)(a => a.FuncionalidadeMes01)).Body).Member.Name;
            public static string PermissaoAcessoLista = ((MemberExpression)((Expression<Func<AcaoFuncionalidadeMes, IList<PermissaoAcesso>>>)(a => a.PermissaoAcessoLista)).Body).Member.Name;
        }
    }
}
