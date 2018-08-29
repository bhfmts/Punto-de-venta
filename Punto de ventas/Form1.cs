using Punto_de_ventas.Connection;
using Punto_de_ventas.Models;
using Punto_de_ventas.ModelsClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_ventas
{
    public partial class Form1 : Form
    {
        TextBoxEvent evento = new TextBoxEvent();
        Cliente cliente = new Cliente();
        List<Clientes> numCliente = new List<Clientes>();
        private string accion = "insert", deudaActual, pago, dia, fecha;
        private int paginas = 4, pageSize= 10, maxReg, pageCount, numPagi, IdCliente = 0, IdRegistro=0;


        public Form1()
        {
            InitializeComponent();

            /**********************************************
             *                                            *          
             *          CODIGO DEL CLIENTE                *  
             *                                            *  
             * ********************************************/

            #region
            radioButton_IngresarCliente.Checked = true;
            radioButton_IngresarCliente.ForeColor = Color.DarkCyan;
            cliente.searchCliente(dataGridView_Cliente, "", 1, pageSize);

            cliente.getClienteReporte(dataGridView_ClienteReporte, IdCliente);

            #endregion
        }


        private void CargarDatos()
        {
            switch (paginas)
            {
                case 1:
                    numCliente = cliente.getClientes();
                    cliente.searchCliente(dataGridView_Cliente,"", 1, pageSize);
                 
                    maxReg = numCliente.Count();
                    break;

            }
            pageCount = (maxReg / pageSize);

            //Ajuste el numero de la pagina si la ultima pagina contiene una parte de la pagina
            if ((maxReg % pageSize) > 0) {
                pageCount += 1;
            }
            label_PaginasCliente.Text = "Paginas " + "1" + "/" + pageCount.ToString();
        }
    

        /**********************************************
         *                                            *          
         *          CODIGO DEL CLIENTE                *  
         *                                            *  
         * ********************************************/

        #region
        private void button_Clientes_Click(object sender, EventArgs e)
        {
            paginas = 1;
            accion = "insert";
            //Llamamos a la pagina 1 del tabcontrol1
            tabControl1.SelectedIndex = 1;
            CargarDatos();
            button_Clientes.Enabled = false;
            button_Ventas.Enabled = true;
            button_Productos.Enabled = true;
            button_Compras.Enabled = true;
            button_Dpto.Enabled = true;
            button_Compras.Enabled = true;

        }
        private void radioButton_IngresarCliente_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_IngresarCliente.ForeColor = Color.DarkCyan;
            radioButton_PagosDeudas.ForeColor = Color.Black;
            textBox_Nombre.ReadOnly = false;
            textBox_Apellido.ReadOnly = false;
            textBox_Direccion.ReadOnly = false;
            textBox_Telefono.ReadOnly = false;
            textBox_PagoscCliente.ReadOnly = true;
            label_PagoCliente.Text = "Pagos de deudas ";
            label_PagoCliente.ForeColor = Color.DarkCyan;

        }

        private void radioButton_PagosDeudas_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_PagosDeudas.ForeColor = Color.DarkCyan;
            radioButton_IngresarCliente.ForeColor = Color.Black;
            textBox_Nombre.ReadOnly = true;
            textBox_Apellido.ReadOnly = true;
            textBox_Direccion.ReadOnly = true;
            textBox_Telefono.ReadOnly = true;
            textBox_PagoscCliente.ReadOnly = false;
        }

        private void textBox_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.numberKeyPress(e);
        }

        private void textBox_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Nombre.Text == "")
            {
                label_Nombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Nombre.Text = "Nombre Completo";
                label_Nombre.ForeColor = Color.Green;
            }
        }

        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.textKeyPress(e);


        }

        private void textBox_Apellido_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Apellido.Text == "")
            {
                label_Apellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Apellido.Text = "Apellido";
                label_Apellido.ForeColor = Color.Green;
            }

        }

        private void textBox_Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.textKeyPress(e);

        }

        private void textBox_Direccion_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Direccion.Text == "")
            {
                label_Direccion.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Direccion.Text = "Dirección";
                label_Direccion.ForeColor = Color.Green;
            }


        }

     

        private void textBox_Telefono_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Telefono.Text == "")
            {
                label_Telefono.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Telefono.Text = "Teléfono";
                label_Telefono.ForeColor = Color.Green;
            }


        }

        private void textBox_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.numberKeyPress(e);

        }

        private void textBox_PagoscCliente_TextChanged(object sender, EventArgs e)
        {
            if (textBox_PagoscCliente.Text == "")
            {
                label_PagoCliente.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_PagoCliente.Text = "Pagos de deudas";
                label_PagoCliente.ForeColor = Color.Green;
            }
        }

        private void textBox_PagoscCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.numberDecimalKeyPress(textBox_PagoscCliente, e);

        }

        private void textBox_Id_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Id.Text == "")
            {
                label_Id.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Id.Text = "Id";
                label_Id.ForeColor = Color.Green;
            }

        }

     

        private void button_GuardarCliente_Click(object sender, EventArgs e)
        {
            if (radioButton_IngresarCliente.Checked)
            {
                guardarCliente();

            }        

        }
        private void textBox_Direccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button_PrimerosClientes_Click(object sender, EventArgs e)
        {
            numPagi = 1;
            label_PaginasCliente.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();
            cliente.searchCliente(dataGridView_Cliente, "",1, pageSize);
        }

        private void button_AnteriosClientes_Click(object sender, EventArgs e)
        {
            if (numPagi >1)
            {
                numPagi -= 1;
                label_PaginasCliente.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();
                cliente.searchCliente(dataGridView_Cliente, "",numPagi,pageSize);

            }
        }

        private void button_SiguientesClientes_Click(object sender, EventArgs e)
        {
            if (numPagi < pageCount)
            {
                numPagi += 1;
                label_PaginasCliente.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();
                cliente.searchCliente(dataGridView_Cliente, "", numPagi, pageSize);

            }

        }

        private void button_UltimosClientes_Click(object sender, EventArgs e)
        {
            numPagi = pageCount;
           
            label_PaginasCliente.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();
            cliente.searchCliente(dataGridView_Cliente, "", numPagi, pageSize);
        }
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            RestablecerCliente();
        }

        private void dataGridView_Cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Cliente.Rows.Count != 0)
            {
                dataGridViewCliente();
            }
        }

        private void dataGridView_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView_Cliente.Rows.Count != 0)
            {
                dataGridViewCliente();
            }

        }
        private void RestablecerCliente()
        {
            CargarDatos();
            textBox_Id.Text = "";
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
            textBox_Direccion.Text = "";
            textBox_Telefono.Text = "";
            textBox_PagoscCliente.Text = "";
            textBox_Id.Focus();
            textBox_BuscarCliente.Text = "";
            label_Id.ForeColor = Color.LightSlateGray;
            label_Nombre.ForeColor = Color.LightSlateGray;
            label_Apellido.ForeColor = Color.LightSlateGray;
            label_Direccion.ForeColor = Color.LightSlateGray;
            label_Telefono.ForeColor = Color.LightSlateGray;
            label_PagoCliente.ForeColor = Color.LightSlateGray;
            label_PagoCliente.Text = "Pagos de deudas ";
            radioButton_IngresarCliente.Checked = true;
            radioButton_IngresarCliente.ForeColor = Color.DarkCyan;
            accion = "insert";
            IdCliente = 0;
            label_NombreRB.Text = "Nombre";
            label_ApellidoRB.Text = "Apellido";
            label_ClienteSA.Text = "$.00";
            label_ClienteUP.Text = "$0.00";
            label_FechaPG.Text = "Fecha";
            dataGridViewCliente();

        }

        private void button_ImprCliente_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCliente()
        {
            accion = "update";
            IdCliente = Convert.ToInt16(dataGridView_Cliente.CurrentRow.Cells[0].Value);
            textBox_Id.Text = Convert.ToString(dataGridView_Cliente.CurrentRow.Cells[1].Value);
            textBox_Nombre.Text = Convert.ToString(dataGridView_Cliente.CurrentRow.Cells[2].Value);
            textBox_Apellido.Text = Convert.ToString(dataGridView_Cliente.CurrentRow.Cells[3].Value);
            textBox_Direccion.Text = Convert.ToString(dataGridView_Cliente.CurrentRow.Cells[4].Value);
            textBox_Telefono.Text = Convert.ToString(dataGridView_Cliente.CurrentRow.Cells[5].Value);

            cliente.getClienteReporte(dataGridView_ClienteReporte, IdCliente);

            IdRegistro = Convert.ToInt16(dataGridView_ClienteReporte.CurrentRow.Cells[0].Value);
            label_NombreRB.Text = Convert.ToString(dataGridView_ClienteReporte.CurrentRow.Cells[1].Value);
            label_ApellidoRB.Text = Convert.ToString(dataGridView_ClienteReporte.CurrentRow.Cells[2].Value);
            label_ClienteSA.Text = Convert.ToString(dataGridView_ClienteReporte.CurrentRow.Cells[3].Value);
            label_ClienteUP.Text = Convert.ToString(dataGridView_ClienteReporte.CurrentRow.Cells[5].Value);
            label_FechaPG.Text = Convert.ToString(dataGridView_ClienteReporte.CurrentRow.Cells[4].Value);



        }
        private void guardarCliente()
        {
            if (textBox_Id.Text == "")
            {
                label_Id.Text = "Ingrese la ID";
                label_Id.ForeColor = Color.Red;
                textBox_Id.Focus();
            }
            else
            {
                if (textBox_Nombre.Text == "")
                {
                    label_Nombre.Text = "Ingrese el nombre completo";
                    label_Nombre.ForeColor = Color.Red;
                    textBox_Nombre.Focus();
                }
                else
                {
                    if (textBox_Apellido.Text == "")
                    {
                        label_Apellido.Text = "Ingrese el apellido";
                        label_Apellido.ForeColor = Color.Red;
                        textBox_Apellido.Focus();
                    }
                    else
                    {
                        if (textBox_Direccion.Text == "")
                        {
                            label_Direccion.Text = "Ingrese la dirección";
                            label_Direccion.ForeColor = Color.Red;
                            textBox_Direccion.Focus();
                        }
                        else
                        {
                            if (textBox_Telefono.Text == "")
                            {
                                label_Telefono.Text = "Ingrese el teléfono";
                                label_Telefono.ForeColor = Color.Red;
                                textBox_Telefono.Focus();
                            }
                            else
                            {
                                string ID = textBox_Id.Text;
                                string Nombre = textBox_Nombre.Text;
                                string Apellido = textBox_Apellido.Text;
                                string Direccion = textBox_Direccion.Text;
                                string Telefono = textBox_Telefono.Text;
                                if (accion == "insert")
                                {
                                    cliente.insertCliente(ID, Nombre, Apellido, Direccion, Telefono);
                                }
                                RestablecerCliente();
                            }

                        }

                    }
                }
            }

            #endregion
        }
    }

}
