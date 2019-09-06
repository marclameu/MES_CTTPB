using System;
using System.Collections.Generic;
using System.Text;

namespace CTTPB.MESCDP.Domain
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TransactionAttribute : Attribute
    {
    }
}
