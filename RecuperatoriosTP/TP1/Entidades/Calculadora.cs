using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if(operador=="-" || operador=="/" || operador == "*")
            {
                retorno = operador;
            }
            return retorno; 
        }

        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado;
            string operadorValidado = ValidarOperador(operador);


            
            if(operadorValidado=="/")
            {
                resultado = num1/ num2;
            }
            else
            { 
                if (operadorValidado == "-")
                {
                resultado = num1 - num2;
                }
                else { 
                if(operadorValidado == "*")
                {
                    resultado=num1* num2;
                }
                else
                {
                    resultado = num1 + num2;
                }

                }

            }
            

            return resultado;
        }
    }
}
