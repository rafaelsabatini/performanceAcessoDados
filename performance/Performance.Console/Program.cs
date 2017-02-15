using performace.domain.Repositorios;
using Performance.Infra.Contexto;
using Performance.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Performance.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceContexto contexto = new PerformanceContexto();

            IPedidoRepositorio pedidoRepositorio = new PedidoRepositorio(contexto);


            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var pedidoAsNoTracking = pedidoRepositorio.GetAsNoTracking();
            stopwatch.Stop();
            WriteLine($"Tempo consulta EntityFramework NoTracking: {stopwatch.Elapsed}");
            WriteLine($"Qtd. retornado consulta EntityFramework  NoTracking: {pedidoAsNoTracking.Count()}");

            stopwatch.Restart();
            var pedido = pedidoRepositorio.Get();
            stopwatch.Stop();
            WriteLine($"Tempo consulta EntityFramework: {stopwatch.Elapsed}");
            WriteLine($"Qtd. retornado consulta EntityFramework : {pedido.Count()}");

            stopwatch.Restart();
            var pedidoDapper = pedidoRepositorio.GetDapper();
            stopwatch.Stop();
            WriteLine($"Tempo consulta Dapper: {stopwatch.Elapsed}");
            WriteLine($"Qtd. retornado consulta Dapper: {pedidoDapper.Count()}");

            stopwatch.Restart();
            var pedidoAdo = pedidoRepositorio.GetAdo();
            stopwatch.Stop();
            WriteLine($"Tempo consulta ADO: {stopwatch.Elapsed}");
            WriteLine($"Qtd. retornado consulta ADO: {pedidoAdo.Count()}");

            ReadLine();

        }
    }
}
