using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Examen
    {
        public static void Palindromo(string texto)
        {
            string textoSinEspacios = "";

            for(int i= 0; i<texto.Length; i++)
            {
                if(texto[i].ToString() != " ")
                {
                    textoSinEspacios += texto[i];
                }
            }

            string cadenaAlreves = "";
            for(int i = textoSinEspacios.Length -1; i>=0; i--)
            {
                cadenaAlreves += textoSinEspacios[i];
            }

            Console.WriteLine(texto);
            Console.WriteLine(textoSinEspacios);
            Console.WriteLine(cadenaAlreves);

        }
    }
}
