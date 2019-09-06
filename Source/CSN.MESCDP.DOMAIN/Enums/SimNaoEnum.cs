using System;
using System.Collections.Generic;
using System.Text;

namespace CTTPB.MESCDP.Domain.Enums
{
    public class SimNaoEnum : BaseEnum
    {
        public static Par Nao = new Par { Chave = "N", Valor = "No" };
        public static Par Sim = new Par { Chave = "S", Valor = "Yes" };

        public SimNaoEnum()
            : base(Sim, Nao)
        {
        }

        public static string GetChaveByValue(string value)
        {
            if (Sim.Valor.Equals(value))
                return Sim.Chave.ToString();
            if (Nao.Valor.Equals(value))
                return Nao.Chave.ToString();
            return null;
        }

        public static string GetValueByChave(string chave)
        {
            if (Sim.Chave.Equals(chave))
                return Sim.Valor.ToString();
            if (Nao.Chave.Equals(chave))
                return Nao.Valor.ToString();
            return null;
        }
    }
}
