using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingTools
{
    /// <summary>
    /// Tools set for banking calculates
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Return array with ccc splited
        /// </summary>
        /// <param name="CCC"></param>
        /// <returns></returns>
        public static string[] SplitCCC(string CCC)
        {
            string[] cccSplited = new string[4];

            string entityCode = CCC.Substring(0, 4); //0182
            string office = CCC.Substring(4, 4); //2487
            string controlNumber = CCC.Substring(8,2); //75
            string account = CCC.Substring(10,10); //0201519689

            return cccSplited;
        }

        /// <summary>
        /// Return IBAN code
        /// </summary>
        /// <param name="ccc"></param>
        /// <returns></returns>
        public static string IbanCalculate(string ccc)
        {
            // Calculamos el IBAN
            ccc =ccc.Trim();

            if (ccc.Length != 20)
            {
                return "La CCC debe tener 20 dígitos";
            }
            // Le añadimos el codigo del pais al ccc
            ccc = ccc + "142800";
 
            // Troceamos el ccc en partes (26 digitos)
            string[] partsCCC = new string[5];

            partsCCC[0] = ccc.Substring(0, 5);
            partsCCC[1] = ccc.Substring(5, 5);
            partsCCC[2] = ccc.Substring(10, 5);
            partsCCC[3] = ccc.Substring(15, 5);
            partsCCC[4] = ccc.Substring(20, 6);
 
            int iResult = int.Parse(partsCCC[0]) % 97;
            string result = iResult.ToString();

            for (int i = 0; i < partsCCC.Length - 1; i++)
            {
                iResult = int.Parse(result + partsCCC[i + 1]) % 97;
                result = iResult.ToString();
            }
            // Le restamos el resultado a 98
            int iRestIban = 98 - int.Parse(result);
            string restIban = iRestIban.ToString();

            if (restIban.Length == 1)
                restIban = "0" + restIban;
 
            return "ES" + restIban;
        }
    }
}
