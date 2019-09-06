using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain.Entities
{
    [Serializable()]
    public partial class Terminal : Auditable
    {
        public Terminal() { }
        public virtual int IdTern { get; set; }
        //public virtual ModalTransporte ModalTransporte01 { get; set; }
        //public virtual Processo Processo01 { get; set; }
        //public virtual Planta Planta01 { get; set; }
        //public virtual RecursoApropriacaoEvento RecursoApropriacaoEvento01 { get; set; }
        //public virtual IList<ApropriacaoEvento> ApropriacaoEventoLista { get; set; }
        //public virtual IList<CartaControle> CartaControleLista { get; set; }
        //public virtual IList<ConfiguracaoTempoMedio> ConfiguracaoTempoMedioLista { get; set; }
        //public virtual IList<DetalhePlanoCargaDescarga> DetalhePlanoCargaDescargaLista { get; set; }
        //public virtual IList<DetalheProgramacaoTrem> DetalheProgramacaoTremLista { get; set; }
        //public virtual IList<DtlhPrgmAnualTransporte> DtlhPrgmAnualTransporteLista { get; set; }
        //public virtual IList<EquipamentoTerminal> EquipamentoTerminalLista { get; set; }
        //public virtual IList<Itinerario> ItinerarioLista { get; set; }
        //public virtual IList<Material> MaterialLista { get; set; }
        public virtual IList<PesagemVagao> PesagemVagaoLista { get; set; }
        //public virtual IList<PesoMedio> PesoMedioLista { get; set; }
        //public virtual IList<PontoCrgaTipoCrgaDscg> PontoCrgaTipoCrgaDscgLista { get; set; }
        //public virtual IList<ProgramacaoEmbarque> ProgramacaoEmbarqueLista { get; set; }
        //public virtual IList<SimlcProgramacaoEmbarque> SimlcProgramacaoEmbarqueLista { get; set; }
        public virtual IList<TremCarregamento> TremCarregamentoLista { get; set; }
        public virtual string CdTern { get; set; }
        public virtual string CdTernMrs { get; set; }
        public virtual string FlSituaTern { get; set; }
        public virtual string FlTernCrgaDscg { get; set; }
        public virtual string FlTernCtrlSist { get; set; }
        public virtual string FlTernPesa { get; set; }
        public virtual string TxDscrTern { get; set; }
        public virtual string FlEnvioTremPorto { get; set; }
        public virtual string CdTernScv { get; set; }

        public partial class Atributos
        {
            public static string IdTern = ((MemberExpression)((Expression<Func<Terminal, System.Int32>>)(a => a.IdTern)).Body).Member.Name;
            //public static string ModalTransporte01 = ((MemberExpression)((Expression<Func<Terminal, ModalTransporte>>)(a => a.ModalTransporte01)).Body).Member.Name;
            //public static string Processo01 = ((MemberExpression)((Expression<Func<Terminal, Processo>>)(a => a.Processo01)).Body).Member.Name;
            //public static string Planta01 = ((MemberExpression)((Expression<Func<Terminal, Planta>>)(a => a.Planta01)).Body).Member.Name;
            //public static string RecursoApropriacaoEvento01 = ((MemberExpression)((Expression<Func<Terminal, RecursoApropriacaoEvento>>)(a => a.RecursoApropriacaoEvento01)).Body).Member.Name;
            //public static string ApropriacaoEventoLista = ((MemberExpression)((Expression<Func<Terminal, IList<ApropriacaoEvento>>>)(a => a.ApropriacaoEventoLista)).Body).Member.Name;
            //public static string CartaControleLista = ((MemberExpression)((Expression<Func<Terminal, IList<CartaControle>>>)(a => a.CartaControleLista)).Body).Member.Name;
            //public static string ConfiguracaoTempoMedioLista = ((MemberExpression)((Expression<Func<Terminal, IList<ConfiguracaoTempoMedio>>>)(a => a.ConfiguracaoTempoMedioLista)).Body).Member.Name;
            //public static string DetalhePlanoCargaDescargaLista = ((MemberExpression)((Expression<Func<Terminal, IList<DetalhePlanoCargaDescarga>>>)(a => a.DetalhePlanoCargaDescargaLista)).Body).Member.Name;
            //public static string DetalheProgramacaoTremLista = ((MemberExpression)((Expression<Func<Terminal, IList<DetalheProgramacaoTrem>>>)(a => a.DetalheProgramacaoTremLista)).Body).Member.Name;
            //public static string DtlhPrgmAnualTransporteLista = ((MemberExpression)((Expression<Func<Terminal, IList<DtlhPrgmAnualTransporte>>>)(a => a.DtlhPrgmAnualTransporteLista)).Body).Member.Name;
            //public static string EquipamentoTerminalLista = ((MemberExpression)((Expression<Func<Terminal, IList<EquipamentoTerminal>>>)(a => a.EquipamentoTerminalLista)).Body).Member.Name;
            //public static string ItinerarioLista = ((MemberExpression)((Expression<Func<Terminal, IList<Itinerario>>>)(a => a.ItinerarioLista)).Body).Member.Name;
            //public static string MaterialLista = ((MemberExpression)((Expression<Func<Terminal, IList<Material>>>)(a => a.MaterialLista)).Body).Member.Name;
            public static string PesagemVagaoLista = ((MemberExpression)((Expression<Func<Terminal, IList<PesagemVagao>>>)(a => a.PesagemVagaoLista)).Body).Member.Name;
            //public static string PesoMedioLista = ((MemberExpression)((Expression<Func<Terminal, IList<PesoMedio>>>)(a => a.PesoMedioLista)).Body).Member.Name;
            //public static string PontoCrgaTipoCrgaDscgLista = ((MemberExpression)((Expression<Func<Terminal, IList<PontoCrgaTipoCrgaDscg>>>)(a => a.PontoCrgaTipoCrgaDscgLista)).Body).Member.Name;
            //public static string ProgramacaoEmbarqueLista = ((MemberExpression)((Expression<Func<Terminal, IList<ProgramacaoEmbarque>>>)(a => a.ProgramacaoEmbarqueLista)).Body).Member.Name;
            //public static string SimlcProgramacaoEmbarqueLista = ((MemberExpression)((Expression<Func<Terminal, IList<SimlcProgramacaoEmbarque>>>)(a => a.SimlcProgramacaoEmbarqueLista)).Body).Member.Name;
            public static string TremCarregamentoLista = ((MemberExpression)((Expression<Func<Terminal, IList<TremCarregamento>>>)(a => a.TremCarregamentoLista)).Body).Member.Name;
            public static string CdTern = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.CdTern)).Body).Member.Name;
            public static string CdTernMrs = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.CdTernMrs)).Body).Member.Name;
            public static string FlSituaTern = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.FlSituaTern)).Body).Member.Name;
            public static string FlTernCrgaDscg = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.FlTernCrgaDscg)).Body).Member.Name;
            public static string FlTernCtrlSist = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.FlTernCtrlSist)).Body).Member.Name;
            public static string FlTernPesa = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.FlTernPesa)).Body).Member.Name;
            public static string TxDscrTern = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.TxDscrTern)).Body).Member.Name;
            public static string FlEnvioTremPorto = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.FlEnvioTremPorto)).Body).Member.Name;
            public static string CdTernScv = ((MemberExpression)((Expression<Func<Terminal, System.String>>)(a => a.CdTernScv)).Body).Member.Name;
        }
    }
}
