using performace.domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using performace.domain.Entidades;
using Performance.Infra.Contexto;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;

namespace Performance.Infra.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {


        private readonly PerformanceContexto _context;

        public PedidoRepositorio(PerformanceContexto context)
        {
            _context = context;
        }
        public IEnumerable<Pedido> Get()
        {
            return _context.Pedidos.Include("Itens").ToList();
        }

        public Pedido Get(Guid id)
        {
            return _context.Pedidos.Include("Itens").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Pedido> GetAdo()
        {
            var query = "select Pedido.id as id ,UsuarioId,Numero,DataCadastro, Item.Id as Item_Id,Pedido_Id as Item_Pedido_Id, ProdutoId as Item_ProdutoId,Quantidade as Item_Quantidade,Valor as Item_Valor  from Pedido inner join item on Item.Pedido_Id = Pedido.Id";
            using (var conn = new SqlConnection(@"Server=(LocalDb)\v11.0;Database=performance;User ID=admin;Password=admin;"))
            {
                conn.Open();
                Dictionary<Guid, Pedido> pedidos = new Dictionary<Guid, Pedido>();


                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader SqlDataReader = command.ExecuteReader();


                while (SqlDataReader.Read())
                {
                    Pedido p;


                    Guid usuarioId = SqlDataReader.GetGuid(SqlDataReader.GetOrdinal("UsuarioId"));                   
                    Guid id = SqlDataReader.GetGuid(SqlDataReader.GetOrdinal("id"));
                    string numero = SqlDataReader.GetString(SqlDataReader.GetOrdinal("Numero"));
                    DateTime dataCadastro = SqlDataReader.GetDateTime(SqlDataReader.GetOrdinal("DataCadastro"));




                    Guid itemId  = SqlDataReader.GetGuid(SqlDataReader.GetOrdinal("Item_Id"));
                    Guid itemPedidoId = SqlDataReader.GetGuid(SqlDataReader.GetOrdinal("Item_Pedido_Id"));
                    Guid itemProdutoId = SqlDataReader.GetGuid(SqlDataReader.GetOrdinal("Item_ProdutoId"));
                    int itemQtd = SqlDataReader.GetInt32(SqlDataReader.GetOrdinal("Item_Quantidade"));
                    decimal itemValor  = SqlDataReader.GetDecimal(SqlDataReader.GetOrdinal("Item_Valor"));

                    pedidos.TryGetValue(id, out p);

                    if (p == null)
                    {
                        p = new Pedido(usuarioId, new List<Item>());
                        p.PopulaResultADO(id, numero, dataCadastro);
                        pedidos[id] = p;
                    }

                    if (!Convert.IsDBNull(itemId))
                    {
                        Item item = p.Itens.FirstOrDefault(i => i.Id == itemId);
                        if (item == null)
                        {
                            item = new Item(itemProdutoId, itemQtd, itemValor);
                            item.PopulaItemADO(itemId);
                            p.PopulaItensADO(item);
                        }
                    }

                }


                return pedidos.Values;
            }
        }

        public IEnumerable<Pedido> GetAsNoTracking()
        {
            return _context.Pedidos.Include("Itens").AsNoTracking().ToList();
        }

        public IEnumerable<Pedido> GetDapper()
        {
            var query = "select p.*, i.* from Pedido as  p inner join item as i on i.Pedido_Id = p.Id";
            using (var conn = new SqlConnection(@"Server=(LocalDb)\v11.0;Database=performance;User ID=admin;Password=admin;"))
            {
                conn.Open();

                var lookup = new Dictionary<Guid, Pedido>();

                conn.Query<Pedido, Item, Pedido>(query, (p, i) =>
                {
                    Pedido pedido;

                    if (!lookup.TryGetValue(p.Id, out pedido))
                    {
                        lookup.Add(p.Id, pedido = p);
                    }
                    pedido.Itens.Add(i);
                    return pedido;
                }).AsQueryable();

                var result = lookup.Values;

                return result;
            }
        }
    }
}
