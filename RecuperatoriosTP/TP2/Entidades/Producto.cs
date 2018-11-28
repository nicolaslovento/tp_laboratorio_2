using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_02_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca marca;

        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;

        public Producto(string codigo,EMarca marca,ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
            this.marca = marca;

        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de Calorias
        /// </summary>
        protected abstract short CantidadCalorias { get; /*set;*/ }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: "+ p.codigoDeBarras);
            sb.AppendLine("MARCA          : "+ p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : "+p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return v1.codigoDeBarras == v2.codigoDeBarras;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
    }
}
