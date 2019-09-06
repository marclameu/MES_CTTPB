using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{

    [Serializable()]
    public partial class TremCarregamento : Auditable
    {
        public TremCarregamento() { }
        public virtual int IdTrem { get; set; }
        public virtual Terminal Terminal02 { get; set; }
        public virtual Terminal Terminal01 { get; set; }
        public virtual IList<ComposicaoTrem> ComposicaoTremLista { get; set; }
        //public virtual IList<DesmembramentoTrem> DesmembramentoTremLista { get; set; }
        //public virtual IList<EmbarqueFerroviario> EmbarqueFerroviarioLista { get; set; }
        public virtual string CdPfxoTremCrga { get; set; }
        public virtual string CdPfxoTremVazia { get; set; }
        public virtual string CdTabl { get; set; }
        public virtual System.Nullable<System.DateTime> DtDispTremEmbq { get; set; }
        public virtual System.Nullable<System.DateTime> DtRefrPrgmCrga { get; set; }
        public virtual string FlEnvioTremIntgr { get; set; }
        public virtual string FlSituaTrem { get; set; }
        public virtual System.Nullable<int> IdTremMina { get; set; }
        public virtual System.Nullable<int> QtVagoesAguaLivre { get; set; }
        public partial class Atributos
        {
            public static string IdTrem = ((MemberExpression)((Expression<Func<TremCarregamento, System.Int32>>)(a => a.IdTrem)).Body).Member.Name;
            public static string Terminal02 = ((MemberExpression)((Expression<Func<TremCarregamento, Terminal>>)(a => a.Terminal02)).Body).Member.Name;
            public static string Terminal01 = ((MemberExpression)((Expression<Func<TremCarregamento, Terminal>>)(a => a.Terminal01)).Body).Member.Name;
            public static string ComposicaoTremLista = ((MemberExpression)((Expression<Func<TremCarregamento, IList<ComposicaoTrem>>>)(a => a.ComposicaoTremLista)).Body).Member.Name;
            public static string CdPfxoTremCrga = ((MemberExpression)((Expression<Func<TremCarregamento, System.String>>)(a => a.CdPfxoTremCrga)).Body).Member.Name;
            public static string CdPfxoTremVazia = ((MemberExpression)((Expression<Func<TremCarregamento, System.String>>)(a => a.CdPfxoTremVazia)).Body).Member.Name;
            public static string CdTabl = ((MemberExpression)((Expression<Func<TremCarregamento, System.String>>)(a => a.CdTabl)).Body).Member.Name;
            public static string DtDispTremEmbq = ((MemberExpression)((Expression<Func<TremCarregamento, System.DateTime?>>)(a => a.DtDispTremEmbq)).Body).Member.Name;
            public static string DtRefrPrgmCrga = ((MemberExpression)((Expression<Func<TremCarregamento, System.DateTime?>>)(a => a.DtRefrPrgmCrga)).Body).Member.Name;
            public static string FlEnvioTremIntgr = ((MemberExpression)((Expression<Func<TremCarregamento, System.String>>)(a => a.FlEnvioTremIntgr)).Body).Member.Name;
            public static string FlSituaTrem = ((MemberExpression)((Expression<Func<TremCarregamento, System.String>>)(a => a.FlSituaTrem)).Body).Member.Name;
            public static string IdTremMina = ((MemberExpression)((Expression<Func<TremCarregamento, System.Int32?>>)(a => a.IdTremMina)).Body).Member.Name;
            public static string QtVagoesAguaLivre = ((MemberExpression)((Expression<Func<TremCarregamento, System.Int32?>>)(a => a.QtVagoesAguaLivre)).Body).Member.Name;
        }
    }
}

