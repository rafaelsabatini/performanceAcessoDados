using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Infra.Transacoes
{
    public interface IUOW
    {
        void Commit();
        void Rollback();
    }
}
