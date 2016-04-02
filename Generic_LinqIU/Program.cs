using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqIU
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientes = new List<Clientes>()
            {
                new Clientes(){Id=1, Name="Pedro", Phone=11},
                new Clientes(){Id=2, Name="Juan", Phone=22},
                new Clientes(){Id=3, Name="Alberto", Phone=33},
                new Clientes(){Id=4, Name="Jennifer", Phone=44},
            };
            var facturas = new List<Facturas>() 
            {
                new Facturas(){IdFactura=1,Data=new DateTime(2016,01,01), IdCliente=1},
                new Facturas(){IdFactura=2,Data=new DateTime(2016,01,02), IdCliente=2},
                new Facturas(){IdFactura=3,Data=new DateTime(2016,01,03), IdCliente=3},
            };
            //Sacar la tabla
            var query = from c in clientes
                        join f in facturas
                        on c.Id equals f.IdCliente 
                        select new {Factura=f.IdFactura,Fecha=f.Data,Telefono=c.Phone};


            foreach (var item in query)
            {
                Console.WriteLine("Tabla");
                Console.WriteLine(item);


            }


            //para sacar el cliente que no tiene factura
            var query2 = from c in clientes
                         join f in facturas
                         on c.Id equals f.IdCliente into res
                         from cf in res.DefaultIfEmpty()
                         where null == cf
                         select new { IdCliente = c.Id , NumeroFacturas = (cf == null ? 0 : cf.IdFactura) };//Esto se haría porque si pones cf.IdFactura, cuando sea nulo te salta error.
        
            foreach(var item in query2){
                Console.WriteLine("");
                Console.WriteLine("Identificador del cliente sin factura");
                Console.Write(item);
                
         
            }
            Console.ReadLine();
        }
        }
}
