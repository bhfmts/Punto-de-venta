using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Punto_de_ventas.ModelsClass
{
    public class TextBoxEvent
    {
        public void textKeyPress(KeyPressEventArgs e)
        {
            //Condición que solo nos permite ingresar datos de tipo texto
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //Condicion que nos permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //Condicion que nos permite utilizar la tecla espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void numberKeyPress(KeyPressEventArgs e)
        {
            //Condicion que solo nos permite ingresar datos númericos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void numberDecimalKeyPress(TextBox textBox, KeyPressEventArgs e)
        {
            //Condición que solo nos permite ingresar datos númericos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //Condición que nos permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //Condición que verifica si hay un punto decimal
            else if((e.KeyChar =='.') && (!textBox.Text.Contains("."))){
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

