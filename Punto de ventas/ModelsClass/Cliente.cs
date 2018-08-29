using LinqToDB;
using Punto_de_ventas.Connection;
using Punto_de_ventas.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_ventas.ModelsClass
{
    public class Cliente : Conexion
    {
        public List<Clientes> getClientes()
        {
            var query = from c in Cliente
                        select c;
            return query.ToList();
        }
        public void insertCliente(string id, string nombre, string apellido, string direccion, string telefono)
        {
            int pos, idCliente;
            using (var db = new Conexion())
            {
                db.Insert(new Clientes()
                {
                    ID = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = direccion,
                    Telefono = telefono

                });
                List<Clientes> cliente = getClientes();
                pos = cliente.Count;
                pos--;
                idCliente = cliente[pos].IdCliente;
                db.Insert(new Reportes_Clientes()
                {
                    IdCliente = idCliente,
                    SaldoActual = "$0,00",
                    FechaActual = "Sin fecha",
                    UltimoPago = "$0.00",
                    FechaPago = "Sin fecha",
                    ID = id

                });
            }
        }
        public void searchCliente(DataGridView dataGridView,string campo, int num_pagina, int reg_por_pagina)
        {
            IEnumerable<Clientes> query;
            int inicio = (num_pagina - 1) * reg_por_pagina;
            if (campo == "")
            {
                query = from c in Cliente select c;
            }
            else
            {
                query = from c in Cliente where c.ID.StartsWith(campo) || c.Nombre.StartsWith(campo) || c.Apellido.StartsWith(campo) select c;
            }
            dataGridView.DataSource = query.Skip(inicio).Take(reg_por_pagina).ToList();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Width = 180;
            dataGridView.Columns[2].Width = 180;
            dataGridView.Columns[3].Width = 180;
            dataGridView.Columns[4].Width = 180;
            dataGridView.Columns[5].Width = 180;
            dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.Columns[5].DefaultCellStyle.BackColor = Color.WhiteSmoke;

        }
        public void getClienteReporte(DataGridView dataGridView, int IdCliente)
        {
            var query = from c in Cliente
                        join r in ReportesClientes on c.IdCliente equals r.IdCliente
                        where c.IdCliente == IdCliente
                        select new
                        {
                            r.IdRegistro,
                            c.Nombre,
                            c.Apellido,
                            r.SaldoActual,
                            r.FechaActual,
                            r.UltimoPago,
                        };
            dataGridView.DataSource = query.ToList();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Width = 129;
            dataGridView.Columns[2].Width = 129;
            dataGridView.Columns[3].Width = 129;
            dataGridView.Columns[4].Width = 129;
            dataGridView.Columns[5].Width = 129;

        }
        public void updateCliente(string id, string nombre, string apellido, string direccion, string telefono, int IdCliente)
        {
            Cliente.Where(c => c.IdCliente == IdCliente)
                .Set(c => c.ID, id)
                .Set(c => c.Nombre, nombre)
                .Set(c => c.Apellido, apellido)
                .Set(c => c.Direccion, direccion)
                .Set(c => c.Telefono, telefono)
                .Update();
            //ReportesClientes = getClienteReporte(idCliente);
        }
    }
}



