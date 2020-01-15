using System;
using System.Collections.Generic;
using System.Text;

namespace CPTAPP.Business.Models.Validations.Documents
{
    public class ValidacaoDocs
    {
    }

    public class Utils
    {
        public static string ApenasNumeros(String valor)
        {
            var onlyNumber = "";

            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }

            return onlyNumber.Trim();
        }
    }
}
