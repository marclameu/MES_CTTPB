using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable()]
    public partial class PermissaoAcesso : Auditable
    {
        public PermissaoAcesso() { }
        public virtual int IdPermtAcss { get; set; }
        public virtual string CdPlanta { get; set; }

        //public virtual Processo Processo01 { get; set; }
        public virtual AcaoFuncionalidadeMes AcaoFuncionalidadeMes01 { get; set; }
        public virtual string CdGrupoAd { get; set; }
        public virtual string NmAcao { get; set; }
        public virtual string NmFncaoMes { get; set; }

        public partial class Atributos
        {
            public static string IdPermtAcss = ((MemberExpression)((Expression<Func<PermissaoAcesso, System.Int32>>)(a => a.IdPermtAcss)).Body).Member.Name;
            //public static string Processo01 = ((MemberExpression)((Expression<Func<PermissaoAcesso, Processo>>)(a => a.Processo01)).Body).Member.Name;
            public static string AcaoFuncionalidadeMes01 = ((MemberExpression)((Expression<Func<PermissaoAcesso, AcaoFuncionalidadeMes>>)(a => a.AcaoFuncionalidadeMes01)).Body).Member.Name;
            public static string CdGrupoAd = ((MemberExpression)((Expression<Func<PermissaoAcesso, System.String>>)(a => a.CdGrupoAd)).Body).Member.Name;
            public static string NmAcao = ((MemberExpression)((Expression<Func<PermissaoAcesso, System.String>>)(a => a.NmAcao)).Body).Member.Name;
            public static string NmFncaoMes = ((MemberExpression)((Expression<Func<PermissaoAcesso, System.String>>)(a => a.NmFncaoMes)).Body).Member.Name;
            public static string CdPlanta =
                ((MemberExpression)((Expression<Func<PermissaoAcesso, System.String>>)(a => a.CdPlanta)).Body).
                Member.Name;
        }

    }
}
