using performace.domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performace.domain.Repositorios
{
   public  interface IItemRepositorio
    {

        IEnumerable<Item> Get();
        Item Get(Guid id);
    }
}
