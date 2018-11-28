using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes= new List<Paquete>();
        }

        /// <summary>
        /// Propiedad Paquetes con get y set.
        /// </summary>
        public List<Paquete> Paquetes { get { return this.paquetes; } }

        /// <summary>
        /// Finaliza todas las entregas.
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                t.Abort();
            }
        }


        /// <summary>
        /// Guarda los datos de los paquetes y los retorna como string.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elemento).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));

            }

            return sb.ToString();
        }


        /// <summary>
        /// Agrega un paquete al correo si no fue ingresado previamente.Si está lanza excepcion.
        /// Luego de agregarlo inicia un hilo y lo agrega a una lista de Threads.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            foreach(Paquete p1 in c.paquetes)
            {
                if (p1 == p)
                {
                    throw new TrackingIdRepetidoException("Error: el paquete ya se ingreso. Tracking ID:");
                }
            }

            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }

    }
}
