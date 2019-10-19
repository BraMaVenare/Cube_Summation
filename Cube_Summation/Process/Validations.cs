using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cube_Summation.Process
{
    public class Validations
    {
        public string NumericalsValidations(string strType, int number)
        {
            switch (strType)
            {
                case "Num_Cases":
                    if (number < 1 || number > 50)
                    {
                        return "El número ingresado no cumple las caracteristicas";
                    }
                    break;
                case "Cube":
                    if (number < 1 || number > 100)
                    {
                        return "El número ingresado no cumple las caracteristicas";
                    }
                    break;
                case "Operations":
                    if (number < 1 || number > 1000)
                    {
                        return "El número ingresado no cumple las caracteristicas";
                    }
                    break;
                case "Other":
                    if (number < 1 || number > 10000)
                    {
                        return "El número ingresado no cumple las caracteristicas";
                    }
                    break;
            }
            return string.Empty;
        }

        public string StringValidations(string sreType, string word)
        {
            switch (sreType)
            {
                case "CubeOpStr":
                    if (string.IsNullOrEmpty(word))
                    {
                        return "Este campo no puede estar vacio, ingrese valores";
                    }
                    Regex reg = new Regex(@"^\d$");
                    if (reg.IsMatch(word))
                    {
                        return "Solamente se permiten numeros en este campo.";
                    }
                    break;
            }
            return string.Empty;
        }
    }
}