using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ENUMERADO
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
#endregion


        #region ATRIBUTOS
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion


        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// <param name="nacionalidad">Nacionalidad a asignar</param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// /// <param name="dni">Dni de tipo int a asignar</param>
        /// <param name="nacionalidad">Nacionalidad a asignar</param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre">Nombre a asignar</param>
        /// <param name="apellido">Apellido a asignar</param>
        /// /// <param name="dni">Dni de tipo string a asignar</param>
        /// <param name="nacionalidad">Nacionalidad a asignar</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            
            this.StringToDni = dni;
        }



        #endregion


        #region PROPIEDADES
        /// <summary>
        /// Obtiene y asigna el valor de ENacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        /// <summary>
        /// Obtiene y asigna el dni previo validar por el metodo ValidarDni(ENacionalidad,string)
        /// 
        /// </summary>
        public string StringToDni
        {
            set
            {
                int dni = 0;
                try
                {
                    dni = this.ValidarDni(this._nacionalidad, value);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
                this.DNI = dni;
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de dni previa validación por medio del método ValidarDni(ENacionalidad, int).
        /// 
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
            set
            {
                int dni = 0;
                try
                {
                    dni = this.ValidarDni(this._nacionalidad, value);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }

                this._dni = dni;
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de nombre previa validación por medio de ValidarNombreApellido(string).
        /// Caso de valor incorrecto, no se cargará.
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (!(this.ValidarNombreApellido(value) is null))
                {
                    this._nombre = value;
                }
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de apellido previa validación por medio de ValidarNombreApellido(string).
        /// Caso de valor incorrecto, no se cargará.
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (!(this.ValidarNombreApellido(value) is null))
                {
                    this._apellido = value;
                }
            }
        }
        #endregion


        #region METODOS
        /// <summary>
        /// Sobreescritura del metodo ToString(), devuelve datos de Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Nombre +" "+this.Apellido);
           sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return sb.ToString();
        }
        /// <summary>
        /// Valida el dni segun el tipo de nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">Dni a validar</param>
        /// <returns>int validado si pasa el bloque switch sino devuelve el mismo int pasado por parametro</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if(dato<1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(); 
                    }
                    return dato;
                    break;
                case ENacionalidad.Extranjero:
                    if (90000000 > dato || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    return dato;
                    break;
                default:
                    break;
            }

            return dato;
        }
        /// <summary>
        /// Valida que el length del string sea mayor que 8 y sea numerico.Luego valida 
        /// con el metodo ValidarDni(ENacionalidad,int)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;
            if (dato.Length>8 || !int.TryParse(dato, out int result))
            {
                throw new DniInvalidoException();
            }
            else
            {
                try
                {
                    dni = this.ValidarDni(nacionalidad, result);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
            }
            return dni;
        }
        /// <summary>
        /// Valida que un dato de tipo string sea todo su contenido de tipo char, sino devuelve "Sin asignar"
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char ch in dato)
            {
                if (!Char.IsLetter(ch))
                {
                    return "Sin asignar";
                }
            }
            return dato;
            
        }
        #endregion


    }
}
