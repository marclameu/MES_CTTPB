using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable]
    public partial class TipoEquipamento: Auditable
    {
        public TipoEquipamento() { }
        public virtual string CdTipoEqpm { get; set; }
        //public virtual IList<Equipamento> EquipamentoLista { get; set; }
        //public virtual IList<TipoEquipamentoPlanta> TipoEquipamentoPlantaLista { get; set; }
        public virtual string FlEqpmMovel { get; set; }
        public virtual string TxDscrTipoEqpm { get; set; }
        //public virtual IList<EventoArvore> EventoArvoreLista { get; set; }
        public partial class Atributos
        {
            public static string CdTipoEqpm = ((MemberExpression)((Expression<Func<TipoEquipamento, System.String>>)(a => a.CdTipoEqpm)).Body).Member.Name;
            //public static string EquipamentoLista = ((MemberExpression)((Expression<Func<TipoEquipamento, IList<Equipamento>>>)(a => a.EquipamentoLista)).Body).Member.Name;
            //public static string TipoEquipamentoPlantaLista = ((MemberExpression)((Expression<Func<TipoEquipamento, IList<TipoEquipamentoPlanta>>>)(a => a.TipoEquipamentoPlantaLista)).Body).Member.Name;
            public static string FlEqpmMovel = ((MemberExpression)((Expression<Func<TipoEquipamento, System.String>>)(a => a.FlEqpmMovel)).Body).Member.Name;
            public static string TxDscrTipoEqpm = ((MemberExpression)((Expression<Func<TipoEquipamento, System.String>>)(a => a.TxDscrTipoEqpm)).Body).Member.Name;
            //public static string EventoArvoreLista = ((MemberExpression)((Expression<Func<TipoEquipamento, IList<EventoArvore>>>)(a => a.EventoArvoreLista)).Body).Member.Name;
        }
    }
}
