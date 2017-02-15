using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performace.domain.Entidades
{
    public class Pedido
    {
        protected Pedido() {
            Itens = new List<Item>();
        }

        public Pedido(Guid usuarioId, ICollection<Item> itens)
        {
            UsuarioId = UsuarioId;
            Id = Guid.NewGuid();
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            DataCadastro = DateTime.Now;
            Itens = new List<Item>();
            if(itens.Any())
            Itens = itens;
        }
        

        public Guid Id { get; private set; }
        public string Numero { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Guid UsuarioId { get; private set; }
        public ICollection<Item> Itens { get;  set; }


       public void PopulaResultADO(Guid id, string numero, DateTime dataCadastro)
        {
            Id = id;
            Numero = numero;
            dataCadastro = DataCadastro;
        }

        public void PopulaItensADO(Item item)
        {
            Itens.Add(item);
        }
    }
}
