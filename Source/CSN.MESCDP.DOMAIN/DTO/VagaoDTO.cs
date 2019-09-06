using System;
using System.Collections.Generic;
using System.Text;

namespace CTTPB.MESCDP.Domain.DTO
{
    [Serializable]
    public class VagaoDTO
    {
        public virtual string prefixo { get; set; }
        public virtual string numvagao { get; set; }
        public virtual string totalLiquido { get; set; }
        public virtual string totalBruto { get; set; }
        public virtual string totalTara { get; set; }
    }
}
