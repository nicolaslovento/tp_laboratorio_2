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

namespace MainCorreo
{
    public partial class Form1 : Form
    {

        public Correo correo;

        public Form1()
        {
            InitializeComponent();
            this.correo = new Correo();
        }


        public void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            paquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);

            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException x)
            {
                MessageBox.Show(x.Message+paquete.TrackingID);
            }

            ActualizarEstados();
        }

        public void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:

                        lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:

                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:

                        lstEstadoEntregado.Items.Add(p);
                        break;
                    default:

                        break;
                }
            }

        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {

                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();

            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);

        }

        public void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!Object.Equals(elemento, null))
            {
                string info= elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = info;
                info.Guardar("InformacionDePaquetes.txt");

            }
        }

    private void mostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
    }
  }
}
