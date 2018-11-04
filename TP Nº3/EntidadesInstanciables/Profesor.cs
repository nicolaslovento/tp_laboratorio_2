using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;
using EntidadesInstanciables;
using System.Threading;

namespace EntidadesInstanciables
{

    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random _random;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor estatico que inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor de instancia por defecto.
        /// </summary>
        public Profesor()
        {
            
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="legajo">Legajo a asignar</param>
        /// <param name="nombre">nombre a asignar</param>
        /// <param name="apellido">apellido a asignar</param>
        /// <param name="dni">dni a asignar</param>
        /// <param name="nacionalidad">nacionalidad a asignar</param>
        public Profesor(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo privado.Asigna dos EClases random en el atributo clasesDelDia.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
            Thread.Sleep(2000);
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
        }

        /// <summary>
        /// Metodo sobreescrito.
        /// </summary>
        /// <returns> Retorna las clases asignada a la instancia.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo sobreescrito.Llama al metodo base.MostrarDatos() y ParticiparEnClase()
        /// </summary>
        /// <returns>Retorna un string con los datos de la instancia.</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos()+ParticiparEnClase();
        }

        /// <summary>
        /// Metodo sobreescrito.Llama al metodo MostrarDatos() 
        /// </summary>
        /// <returns>String con los datos de la instancia</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region SOBRECARGADEOPERADORES
        /// <summary>
        /// Comprueba que este apto para dar la clase.
        /// </summary>
        /// <param name="p">Profesor a verificar</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Retorna true si puede dar la clase sino lanza la 
        /// excepcion SinProfesorException</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        { 
            foreach(Universidad.EClases c in p.clasesDelDia)
            {
                if (c == clase)
                {
                    return true;
                }
            }

            throw new SinProfesorException();
            return false;
        }

        
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        #endregion
    }
}
