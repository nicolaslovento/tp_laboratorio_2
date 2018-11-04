using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region ATRIBUTOS
        private int _legajo;

        #endregion


        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="legajo">Legajo a asignar</param>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// <param name="dni">Dni a asignar</param>
        /// <param name="nacionalidad">Nacionalidad a asignar</param>
        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion


        #region METODOS

        /// <summary>
        /// Metodo virtual. Llama al metodo ToString de la clase Persona y agrega los datos de legajo.
        /// </summary>
        /// <returns>Retorna string con los datos.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO: " + this._legajo);
           

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto. Se implementará en las clases derivadas de esta.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion


        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Compara si la nacionalidad y el dni o legajo son iguales.
        /// </summary>
        /// <param name="u1">Instancia de tipo Universitario</param>
        /// <param name="u2">Instancia de tipo Universitario</param>
        /// <returns>retorna true si son iguales, false si no lo son.</returns>
        public static bool operator ==(Universitario u1,Universitario u2)
        {
            return u1.Nacionalidad == u2.Nacionalidad && (u1.DNI == u2.DNI || u1._legajo == u2._legajo);
        }

        /// Compara si la nacionalidad y el dni o legajo son distintos.
        /// </summary>
        /// <param name="u1">Instancia de tipo Universitario</param>
        /// <param name="u2">Instancia de tipo Universitario</param>
        /// <returns>retorna false si son iguales,true si no lo son.</returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        #endregion

    }
}
