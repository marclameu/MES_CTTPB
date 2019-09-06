using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CTTPB.MESCDP.Domain
{

        [Serializable]
        public class Par
        {
            public static Par Vazio = new Par { Chave = "", Valor = "" };
            public static Par Zero = new Par { Chave = 0, Valor = "" };
            public static Par Todos = new Par { Chave = "", Valor = "Todos" };
            public object Chave { get; set; }
            public object Valor { get; set; }


            public Par()
            { }

            //Construtor utilizado em hbm
            public Par(object chave, object valor)
            {
                Chave = chave;
                Valor = valor;
            }

            public override string ToString()
            {
                return Chave.ToString();
            }

            public bool ChaveIgualA(string valor)
            {
                return valor == ToString();
            }

            public static IList<Par> Converte(string[] lista)
            {
                List<Par> retorno = new List<Par>();
                foreach (var s in lista)
                {
                    retorno.Add(new Par(s, s));
                }
                return retorno;
            }
            public static IList<Par> ConverteOrdena(string[] lista)
            {
                IList<Par> retorno = Converte(lista);
                return retorno.OrderBy(val => val.Valor).ToList();
            }

            public class Atributos
            {
                public static string Chave = ((MemberExpression)((Expression<Func<Par, object>>)(a => a.Chave)).Body).Member.Name;
                public static string Valor = ((MemberExpression)((Expression<Func<Par, object>>)(a => a.Valor)).Body).Member.Name;
            }

        }
    
}
