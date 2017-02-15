using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performace.domain.Entidades
{
    public class Item
    {
        protected Item() { }
        public Item(Guid produtoId, int quantidade, decimal valor)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Valor = valor;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }

        public void PopulaItemADO(Guid id)
        {
            Id = id;
        }
    }
}
