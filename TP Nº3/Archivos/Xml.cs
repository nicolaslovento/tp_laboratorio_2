using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        #region "Métodos"
        
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            XmlTextWriter w = null;
            XmlSerializer s = new XmlSerializer(typeof(T));

            try
            {
                w = new XmlTextWriter(archivo, Encoding.UTF8);
                s.Serialize(w, datos);
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(w is null))
                {
                    w.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
        
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            XmlTextReader r = null;
            XmlSerializer s = new XmlSerializer(typeof(T));

            try
            {
                r = new XmlTextReader(archivo);
                datos = (T)s.Deserialize(r);
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(r is null))
                {
                    r.Close();
                    retorno = true;
                }
            }

            return retorno;
        }
        #endregion
    }

    
}
