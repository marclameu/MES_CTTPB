using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable()]
    public partial class PesagemVagao : Auditable
    {
        public PesagemVagao() { }
        public virtual string CdVclo { get; set; }
        public virtual int IdTern { get; set; }
        public virtual int IdTrem { get; set; }
        public virtual ComposicaoTrem ComposicaoTrem01 { get; set; }
        //public virtual Terminal Terminal01 { get; set; }
        public virtual double PsTaraVagao { get; set; }
        public virtual double PsVagaoBruto { get; set; }
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
            public static string CdVclo = ((MemberExpression)((Expression<Func<PesagemVagao, System.String>>)(a => a.CdVclo)).Body).Member.Name;
            public static string IdTern = ((MemberExpression)((Expression<Func<PesagemVagao, System.Int32>>)(a => a.IdTern)).Body).Member.Name;
            public static string IdTrem = ((MemberExpression)((Expression<Func<PesagemVagao, System.Int32>>)(a => a.IdTrem)).Body).Member.Name;
            public static string ComposicaoTrem01 = ((MemberExpression)((Expression<Func<PesagemVagao, ComposicaoTrem>>)(a => a.ComposicaoTrem01)).Body).Member.Name;
            //public static string Terminal01 = ((MemberExpression)((Expression<Func<PesagemVagao, Terminal>>)(a => a.Terminal01)).Body).Member.Name;
            public static string PsTaraVagao = ((MemberExpression)((Expression<Func<PesagemVagao, System.Double>>)(a => a.PsTaraVagao)).Body).Member.Name;
            public static string PsVagaoBruto = ((MemberExpression)((Expression<Func<PesagemVagao, System.Double>>)(a => a.PsVagaoBruto)).Body).Member.Name;
        }
    }
}
