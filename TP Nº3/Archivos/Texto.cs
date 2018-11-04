using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos

{
    public class Texto : IArchivo<string>
    {


        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(archivo);
                sw.Write(datos);
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(sw is null))
                {
                    sw.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
        

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(sr is null))
                {
                    sr.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
    }
}
