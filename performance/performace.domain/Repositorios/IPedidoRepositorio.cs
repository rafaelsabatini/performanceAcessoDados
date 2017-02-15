using performace.domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performace.domain.Repositorios
{
  public   interface IPedidoRepositorio
    {

        IEnumerable<Pedido> Get();
        IEnumerable<Pedido> GetAsNoTracking();
        IEnumerable<Pedido> GetDapper();
        IEnumerable<Pedido> GetAdo();
        Pedido Get(Guid id);
    }
}
