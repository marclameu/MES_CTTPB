using System;
using System.Collections.Generic;
using System.Text;

namespace CTTPB.MESCDP.Domain.DTO
{
    public class VagoesDTO
    {
        public string modelo { get; set; }
        public string sequencial { get; set; }
        public int ord { get; set; }
        public decimal tara { get; set; }
        public decimal bruto { get; set; }
        public string tipo { get; set; }
        public string status { get; set; }
        public decimal acumulado { get; set; }
        public decimal liquido { get; set; }
    }
}
