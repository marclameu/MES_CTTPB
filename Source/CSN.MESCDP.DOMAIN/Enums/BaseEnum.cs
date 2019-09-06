using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace CTTPB.MESCDP.Domain.Enums
{
    public abstract class BaseEnum
    {
        public List<Par> Items;

        protected BaseEnum(params Par[] itemList)
        {
            Items = new List<Par>();
            foreach (Par item in itemList)
            {
                Items.Add(item);
            }
        }

        public Par GetByChave(string chave)
        {
            foreach (Par item in Items)
            {
                if (item.Chave.ToString().Equals(chave))
                    return item;
            }

            return null;
        }

    }
}
