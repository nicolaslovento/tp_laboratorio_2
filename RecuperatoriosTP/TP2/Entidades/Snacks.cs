using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_02_2018
{
    public class Snacks: Producto
    {
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : "+ this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
