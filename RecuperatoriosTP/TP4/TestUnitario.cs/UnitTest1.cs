using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario.cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PaqueteInstanciado()
        {
            
            Correo c = new Correo();
            
            Assert.AreNotEqual(c.Paquetes, null);

        }

        [TestMethod]
        public void PaquetesIguales()
        {
            Paquete p1 = new Paquete("Mendez","444");
            Paquete p2 = new Paquete("Mendez","444");
            Correo c = new Correo();
            int flag = 0;
            try
            {
                c += p1;
                c += p2;

            }catch(TrackingIdRepetidoException e) {

                flag = 1;
                
            }

            Assert.AreEqual(flag, 1);
            


        }

    }
}
