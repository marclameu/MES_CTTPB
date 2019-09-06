using System;
using System.Collections.Generic;
using System.Text;

namespace CTTPB.MESCDP.Domain.Enums
{
    public class TipoVeiculoTremEnum : BaseEnum
    {
        public static Par Locomotiva = new Par { Chave = "L", Valor = "Enum_TipoVeiculoTrem_Locomotiva" };
        public static Par Vagao = new Par { Chave = "V", Valor = "Enum_TipoVeiculoTrem_Vagao" };

        public TipoVeiculoTremEnum()
            : base(Locomotiva, Vagao)
        {
        }
    }
}
