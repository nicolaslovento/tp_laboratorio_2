using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{

    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> _alumnos;

        private Universidad.EClases _clase;

        private Profesor _instructor;
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }

        public Universidad.EClases Clase { get { return this._clase; } set { this._clase = value; } }

        public Profesor Instructor { get { return this._instructor; } set { this._instructor = value; } }

        #endregion

        #region CONSTRUCTORES
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }


        public Jornada(Universidad.EClases clase, Profesor instructor) : this()

        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion
        
        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Verifica si el alumno está cursando en determinada jornada.
        /// </summary>
        /// <param name="j">Instancia de tipo Jornada</param>
        /// <param name="a">Instancia de tipo Alumno</param>
        /// <returns>Retorna true si lo está, caso contrario false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno alumnos in j._alumnos)
            {
                if (alumnos == a)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Verifica si el alumno no está cursando en determinada jornada.
        /// </summary>
        /// <param name="j">Instancia de tipo Jornada</param>
        /// <param name="a">Instancia de tipo Alumno</param>
        /// <returns>Retorna true si no lo está, caso contrario false.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Si el alumno no está cursando en la jornada lo agrega.
        /// </summary>
        /// <param name="j">Instancia de tipo Jornada</param>
        /// <param name="a">Instancia de tipo Alumno</param>
        /// <returns>Retorna la jornada con el alta si el alumno no estaba cursando, caso contrario sin modificaciones.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alumnos in j._alumnos)
            {
                if (alumnos == a)
                {
                    return j;
                }
            }

            j._alumnos.Add(a);

            return j;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Metodo ToString sobreescrito.
        /// </summary>
        /// <returns>Retorna string con toda la informacion de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE  "+this._clase);
            sb.AppendLine("POR NOMBRE COMPLETO : " + this._instructor.Nombre + " " + this._instructor.Apellido);
            sb.AppendLine("NACIONALIDAD: " + this._instructor.Nacionalidad+"\n\n");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// De clase, Guarda los datos de la Jornada como texto.
        /// </summary>
        /// <returns>(string) Datos de la Jornada</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool guardado = false;
            Texto texto = new Texto();
            try
            {
                guardado = texto.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Jornada.txt", jornada.ToString());
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            return guardado;
        }
        /// <summary>
        /// De clase, retorna los datos de la Jornada como texto.
        /// </summary>
        /// <returns>(string) Datos de la Jornada</returns>
        public static string Leer()
        {
            bool leido = false;
            string datos = null, returnAux = null;
            Texto texto = new Texto();
            try
            {
                leido = texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Jornada.txt", out datos);
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            if (leido)
            {
                returnAux = datos;
            }
            return returnAux;
        }

        #endregion


    }
}
