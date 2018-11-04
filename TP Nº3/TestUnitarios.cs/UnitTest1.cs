using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones;
using EntidadesAbstractas;
namespace TestUnitarios.cs
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba la excepcion NacionalidadInvalidaException al validar Nacionalidad y dni.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void PruebaExceptionNacionalidad()
        {
            Alumno alumnoTest = new Alumno(1, "Nicolas", "Gonzales", "12332234", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

        }

        /// <summary>
        /// Comprueba la excepcion AlumnoRepetidoException al ingresar dos alumnos iguales en Universidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void PruebaExceptionAlumnoRepetido()
        {
            Alumno alumnoTest1 = new Alumno(1, "Gabriel", "Gonzales", "123123", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno alumnoTest2 = new Alumno(1, "Joaquin", "Rodriguez", "2321312", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Universidad uniTest = new Universidad();
            uniTest += alumnoTest1;
            uniTest += alumnoTest2;
        }


        /// <summary>
        /// Comprueba que el atributo dni de tipo int sea igual al asignado por el constructor de tipo string
        /// </summary>
        [TestMethod]
        
        public void PruebaValorNumerico()
        {
            Alumno alumnoTest1 = new Alumno(1, "Gabriel", "Gonzales", "123123", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            Assert.AreEqual(123123,alumnoTest1.DNI);
        }

        /// <summary>
        /// Comprueba que los atributos de la instania Universidad no sean NULL
        /// </summary>
        [TestMethod]
        public void PruebaNoNulls()
        {
            Universidad uniTest = new Universidad();
           
            
                Assert.IsNotNull(uniTest.Alumnos);
                Assert.IsNotNull(uniTest.Instructores);
                Assert.IsNotNull(uniTest.Jornadas);
        }

    }
}
