using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TpCalculadora
{
    public partial class FormCalculadora : Form
    {
        
        private Numero _num1;
        private Numero _num2;

        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.comboBox.Items.Add("/");
            this.comboBox.Items.Add("*");
            this.comboBox.Items.Add("+");
            this.comboBox.Items.Add("-");




        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
           
            this._num1 = new Numero();
            this._num2 = new Numero();




            _num1.SetNumero = this.textBox1.Text;
            _num2.SetNumero = this.textBox2.Text;
            string operador = this.comboBox.Text;
            if (operador.Length==0)
            {
                
                this.label1.Text ="Seleccione operador.";
            }
            else
            {
                double resultado = Calculadora.Operar(this._num1, this._num2, operador);
                this.label1.Text = resultado.ToString();
            }
            
        }




        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.label1.Text = Numero.DecimalBinario(this.label1.Text);


        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.label1.Text = Numero.BinarioDecimal(this.label1.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is Label)
                {
                    item.Text = "";
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


