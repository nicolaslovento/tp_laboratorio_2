using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;
using EntidadesInstanciables;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario

    {
        #region ENUMERADOS
        public enum EEstadoCuenta { AlDia, Deudor, Becado }
        #endregion

        #region ATRIBUTOS
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia por defecto
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="legajo">Legajo a asignar</param>
        /// <param name="nombre">nombre a asignar</param>
        /// <param name="apellido">apellido a asignar</param>
        /// <param name="dni">dni de tipo string a asignar</param>
        /// <param name="nacionalidad">naiconalidad a asignar</param>
        /// <param name="claseQueToma">Enumerado de tipo EClase a asignar</param>
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma) : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="legajo">Legajo a asignar</param>
        /// <param name="nombre">nombre a asignar</param>
        /// <param name="apellido">apellido a asignar</param>
        /// <param name="dni">dni de tipo string a asignar</param>
        /// <param name="nacionalidad">naiconalidad a asignar</param>
        /// /// <param name="estadoCuenta">Enumerado de tipo EEstadoCuenta a asignar</param>
        /// <param name="claseQueToma">Enumerado de tipo EClase a asignar</param>
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(legajo, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Metodo sobreescrito.
        /// </summary>
        /// <returns> Retorna las clases asignada a la instancia.</returns>
        protected override string ParticiparEnClase()
        {
            return "Toma Clases de: "+this._claseQueToma;
        }

        /// <summary>
        /// Metodo sobreescrito.Llama al metodo base.MostrarDatos() y ParticiparEnClase()
        /// </summary>
        /// <returns>Retorna un string con los datos de la instancia.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(ParticiparEnClase());


            return sb.ToString();
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

        #region SOBRECARGA DE OPERADORES
        
        /// <summary>
        /// Verifica si el alumno está en la clase y su  estado de cuenta no es deudor.
        /// </summary>
        /// <param name="a">Instancia de tipo alumno</param>
        /// <param name="clase">Variable de tipo EClases</param>
        /// <returns>Retorna true si se cumple, sino false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma==clase && a._estadoCuenta!=EEstadoCuenta.Deudor)
            {
                
                    return true;
                
            }

            return false;
        }

        /// <summary>
        /// Verifica si el alumno no está en la clase.
        /// </summary>
        /// <param name="a">Instancia de tipo alumno</param>
        /// <param name="clase">Variable de tipo EClases</param>
        /// <returns>Retorna true si no está, sino false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma != clase)
            {

                return true;

            }
            return false;
        }
        #endregion

    }
}
