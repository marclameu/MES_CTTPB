using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain
{
    [Serializable]
    public class Auditable
    {
        //public static DateTime? NewDate = new DateTime(1900, 1, 1);

        private DateTime? _DtUltAtual;
        private string _IdMtricUsuaUltAtual;

        public virtual DateTime? DtUltAtual
        {
            get
            {
                return _DtUltAtual ?? DateTime.Now;
            }
            set
            {
                _DtUltAtual = value;
            }
        }
        public virtual string IdMtricUsuaUltAtual
        {
            get
            {
                return _IdMtricUsuaUltAtual ?? "";
            }
            set
            {
                _IdMtricUsuaUltAtual = value;
            }
        }

        private int _nuVers = -1; // valor default != 0 para evitar problemas de 'references transient' no flush
        public virtual int NuVers
        {
            get { return _nuVers; }
            set { _nuVers = value; }
        }

        public class NomeAtributos
        {
            public static string IdMtricUsuaUltAtual = ((MemberExpression)((Expression<Func<Auditable, string>>)(a => a.IdMtricUsuaUltAtual)).Body).Member.Name;
            public static string DtUltAtual = ((MemberExpression)((Expression<Func<Auditable, DateTime?>>)(a => a.DtUltAtual)).Body).Member.Name;
            public static string NuVers = ((MemberExpression)((Expression<Func<Auditable, int>>)(a => a.NuVers)).Body).Member.Name;
        }
    }
}
