using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using Punto_de_ventas.Models;

namespace Punto_de_ventas.Connection
{
    public class Conexion : DataConnection
    {
        public Conexion() : base("PDHN") { }
        public ITable<Clientes> Cliente { get { return GetTable<Clientes>(); } }
        public ITable<Reportes_Clientes> ReportesClientes { get { return GetTable<Reportes_Clientes>(); } }

    }
}
