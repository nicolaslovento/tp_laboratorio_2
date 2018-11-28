using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda los datos de los paquetes en el archivo indicado.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto,string archivo)
        {
            StreamWriter sw = null;
            bool retorno = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+@"\" +archivo;

            try
            {
                if (File.Exists(archivo))
                {

                    sw = new StreamWriter(path, true);
                    sw.WriteLine(texto);
                    retorno = true;



                }
                else
                {
                    sw = new StreamWriter(path, false);
                    sw.WriteLine(texto);
                    retorno = true;

                }
            }catch(Exception)
            {

            }

            finally
            {
                sw.Close();
            }

            return retorno;

        }

    }
}
