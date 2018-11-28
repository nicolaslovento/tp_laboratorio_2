using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double _numero;


        #region CONSTRUCTORES
        public Numero()
        {
            this._numero = 0;
        }

        public Numero(double num)
        {
            this._numero = num;
        }

        public Numero(string num)
        {
            this._numero = double.Parse(num);
        }

        #endregion


        private double validarNumero(string numIngresado)
        {
            bool validacion;
            double numero;
            if (numIngresado!="")
            {
            numero=double.Parse(numIngresado);
            validacion = double.IsNaN(numero);

            if(validacion!=true)
            {
                return numero;
            }
            }
            return 0;
        }

        public string SetNumero {
            set{
                this._numero = validarNumero(value);
             } }

        public static string BinarioDecimal(string binario)
        {
            double sumador = 0;
            string retorno = "Valor invalido";
            if (binario.Length>0)
            { 
                for (int x = binario.Length - 1, y = 0; x >= 0; x--, y++)
                {
                     if (binario[x] == '1')
                        {
                         sumador += 1 * Math.Pow(2, y);
                        }
                }

            retorno = sumador.ToString();
            }

            return retorno;
        }

        public static string DecimalBinario(double numero)
        {
            string numBinario ="Valor invalido";
            string residuo;
            int numero2;
            if (numero != 0)
            {
                numero2 = (int)numero;

                if (numero2 > -1)
            {
                numBinario = "";
                while (numero2 > 0)
                 {
                    residuo = (numero2 % 2).ToString();
                    numBinario = residuo + numBinario;
                    numero2 = numero2 / 2;
                }
            }
            }
            return numBinario;
        }

        public static string DecimalBinario(string numero)
        {
            string numBinario="";
            string residuo;
            int num;
            if (numero!="")
            {
                numBinario = "Valor invalido";
                num = int.Parse(numero);
            
            if (num > -1)
            {
                numBinario = "";
                while (num > 0)
                {
                    residuo = (num % 2).ToString();
                    numBinario = residuo + numBinario;
                    num = num / 2;
                }
            }
            }
            return numBinario;
        }

        #region operadores
        public static double operator +(Numero num1,Numero num2)
        {
            return num1._numero + num2._numero;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1._numero - num2._numero;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            return num1._numero / num2._numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1._numero * num2._numero;
        }

        #endregion



    }
}
