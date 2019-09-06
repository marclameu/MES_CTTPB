using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable()]
    public partial class ComposicaoTrem : Auditable
    {
        public ComposicaoTrem() { }
        public virtual string CdVclo { get; set; }
        public virtual int IdTrem { get; set; }
        
        //public virtual TremCarregamento TremCarregamento01 { get; set; }
        
        public virtual IList<PesagemVagao> PesagemVagaoLista { get; set; }
        public virtual string CdDpstvSegr { get; set; }
        public virtual string FlSituaVagaoAtrs { get; set; }
        public virtual string FlSituaVagaoTrem { get; set; }
        public virtual string FlTipoVclo { get; set; }
        public virtual System.Nullable<int> NuPoscVagao { get; set; }
        public virtual System.Nullable<double> PsAprvVagaoAtrs { get; set; }
        public virtual System.Nullable<double> PsBrutoVagaoCrgaDscg { get; set; }
        public virtual System.Nullable<double> PsTaraVagaoCrgaDscg { get; set; }
        public virtual string TxJustPerdaMter { get; set; }
        public virtual string TxJustRetrVagao { get; set; }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public partial class Atributos: Auditable
        {
            public static string CdVclo = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.CdVclo)).Body).Member.Name;
            public static string IdTrem = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.Int32>>)(a => a.IdTrem)).Body).Member.Name;
            public static string PesagemVagaoLista = ((MemberExpression)((Expression<Func<ComposicaoTrem, IList<PesagemVagao>>>)(a => a.PesagemVagaoLista)).Body).Member.Name;
            public static string CdDpstvSegr = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.CdDpstvSegr)).Body).Member.Name;
            public static string FlSituaVagaoAtrs = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.FlSituaVagaoAtrs)).Body).Member.Name;
            public static string FlSituaVagaoTrem = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.FlSituaVagaoTrem)).Body).Member.Name;
            public static string FlTipoVclo = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.FlTipoVclo)).Body).Member.Name;
            public static string NuPoscVagao = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.Int32?>>)(a => a.NuPoscVagao)).Body).Member.Name;
            public static string PsAprvVagaoAtrs = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.Double?>>)(a => a.PsAprvVagaoAtrs)).Body).Member.Name;
            public static string PsBrutoVagaoCrgaDscg = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.Double?>>)(a => a.PsBrutoVagaoCrgaDscg)).Body).Member.Name;
            public static string PsTaraVagaoCrgaDscg = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.Double?>>)(a => a.PsTaraVagaoCrgaDscg)).Body).Member.Name;
            public static string TxJustPerdaMter = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.TxJustPerdaMter)).Body).Member.Name;
            public static string TxJustRetrVagao = ((MemberExpression)((Expression<Func<ComposicaoTrem, System.String>>)(a => a.TxJustRetrVagao)).Body).Member.Name;
        }
    }
}
