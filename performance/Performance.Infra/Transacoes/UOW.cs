using Performance.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Infra.Transacoes
{
    public class UOW : IUOW
    {

        private readonly PerformanceContexto _context;

        public UOW(PerformanceContexto context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
          
        }
    }
}
