using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Entidades
{
    public enum EEstado { Ingresado, EnViaje, Entregado }

    

    public class Paquete:IMostrar<Paquete>
    {

        public delegate void DelegadoEstado(object o, EventArgs e);

        public enum EEstado { Ingresado, EnViaje, Entregado }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        public string DireccionEntrega { get{ return this.direccionEntrega; }  }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get {return this.trackingID; }  }


        


        public void MockCicloDeVida()
        {

            do
            {
                Thread.Sleep(5500);

                if (this.estado == EEstado.Ingresado)
                {
                    this.estado = EEstado.EnViaje;
                }
                else if (this.estado == EEstado.EnViaje)
                {
                    this.estado = EEstado.Entregado;
                }

                this.InformaEstado(this.estado, EventArgs.Empty);

            } while (this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                
            }

        }

        
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            if (p1.trackingID == p2.trackingID)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        


    }
        
    }

