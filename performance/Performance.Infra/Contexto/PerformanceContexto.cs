
using performace.domain.Entidades;
using Performance.Infra.Mapeamento;
using System.Data.Entity;

namespace Performance.Infra.Contexto
{
   public  class PerformanceContexto : DbContext
    {
        public PerformanceContexto() : base(@"Server=(LocalDb)\v11.0;Database=performance;User ID=admin;Password=admin;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new PedidoMap());
        }
    }
}
