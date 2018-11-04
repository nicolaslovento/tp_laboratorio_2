using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using EntidadesInstanciables;


namespace EntidadesInstanciables
{

    public class Universidad
    {
        #region ENUMERADORES
        public enum EClases {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD }
        #endregion

        #region ATRIBUTOS
        private List<Alumno> _alumnos;
        private List<Jornada> _jornadas;
        private List<Profesor> _profesores;
        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Obtiene y asigna a la Lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }

        /// <summary>
        /// Obtiene y asigna a la Lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas { get { return this._jornadas; } set { this._jornadas = value; } }

        /// <summary>
        /// Obtiene y asigna a la Lista de profesores
        /// </summary>
        public List<Profesor> Instructores { get { return this._profesores; } set { this._profesores = value; } }

        /// <summary>
        /// Obtiene y asigna a la lista de jornada mediante un indexeador.
        /// </summary>
        public Jornada this[int i] { get { return this._jornadas[i]; } set { this._jornadas[i] = value; } }

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia por defecto.Incializa los atributos.
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornadas = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Comprueba si un alumno está en una lista
        /// </summary>
        /// <param name="u">Universidad que contiene una lista de alumnos</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Lanza la excepcion AlumnoRepetidoException si ya esta en la lista sino false</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool contiene = false;
            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == a)
                {
                    contiene = true;
                    throw new AlumnoRepetidoException();
                }
            }
            return contiene;
            
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Comprueba si un profesor está en una lista
        /// </summary>
        /// <param name="u">Universidad que contiene una lista de profesores</param>
        /// <param name="a">Profesor a verificar</param>
        /// <returns>Retorna true si ya esta en la lista sino false</returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor profesores in u._profesores)
            {
                if (profesores == p)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Crea una nueva jornada con el primer profesor que esté apto para dar la clase y con los alumnos
        /// que esten cursando esa clase
        /// </summary>
        /// <param name="u">Universidad </param>
        /// <param name="clase">Clase a agregar en la jornada</param>
        /// <returns>Retorna la universidad con la jornada asignada sino la universidad pasada como
        /// parametro sin modificaciones</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada nuevaJornada=new Jornada(clase, null);
            List<Alumno> nuevaLista = new List<Alumno>();

            foreach(Profesor profesores in u._profesores)
            {
                if (profesores == clase)
                {
                    nuevaJornada.Instructor = profesores;

                    foreach (Alumno alumnos in u._alumnos)
                    {
                        if (alumnos == clase)
                        {
                            nuevaLista.Add(alumnos);
                        }
                    }

                    nuevaJornada.Alumnos = nuevaLista;
                    u.Jornadas.Add(nuevaJornada);
                    return u;
                }
            }

            return u;
        }

        /// <summary>
        /// Retorna el primer profesor que puede dar la clase
        /// </summary>
        /// <param name="u">Universidad que contiene una lista de profesores</param>
        /// <param name="c">Clase a verificar</param>
        /// <returns>Retorna el primer profesor que puede dar la clase sino lanza excepcion SinProfesorException</returns>
        public static Profesor operator ==(Universidad u,EClases clase)
        {
            foreach(Profesor p in u._profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();

        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u._profesores)
            {
                if (p != clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Si el alumno no esta en la universidad lo agrega.
        /// </summary>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Si el profesor no esta en la universidad lo agrega.
        /// </summary>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
            {
                u._profesores.Add(p);
            }
            return u;

            
        }

        #endregion

        #region METODOS
        /// <summary>
        /// De clase.Retorna un string con los datos de la universidad.
        /// </summary>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("JORNADA:");
            for (int i = 0; i < uni.Jornadas.Count; i++)
            {
                s.Append(uni.Jornadas[i].ToString());
                s.AppendLine("<------------------------------------------------------------->\n");
            }
            return s.ToString();
        }

        /// <summary>
        /// Sobreescritura de ToString. Llama al metodo MostrarDatos de clase.
        /// </summary>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this); ;
        }

        /// <summary>
        /// De clase.Guardara los datos serializados de Universidad.
        /// </summary>
        public static bool Guardar(Universidad uni)
        {
            bool serializado = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                serializado = xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Universidad.xml", uni);
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            return serializado;
        }

        /// <summary>
        /// De clase.Retornará los datos serializados de Universidad.
        /// </summary>
        public static Universidad Leer()
        {
            bool deserializado = false;
            Universidad universidad = null, returnAux = null;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                deserializado = xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Universidad.xml", out universidad);
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            if (deserializado)
            {
                returnAux = universidad;
            }
            return returnAux;
        }

        #endregion
    }
}
