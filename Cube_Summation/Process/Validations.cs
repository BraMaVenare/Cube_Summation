namespace Cube_Summation.Process
{
    using System;
    using System.Text.RegularExpressions;
    public class Validations
    {
        public string SingleIntegerValidations(string strType, int number)
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
                case "LengthCube":
                    if (number <= 1)
                    {
                        return "Debe separar los valores del cubo y las operaciones por un espacio en blanco";
                    }
                    break;
                case "LengthOperation":
                    if (number != 4 && number != 6)
                    {
                        return "Los valores para realizar la operacion que usted ingreso no son correctos.";
                    }
                    break;
            }
            return string.Empty;
        }

        public string SingleDoubleValidation(double value)
        {
            if (0.000000001 >  value || value > 1000000000)
            {
                return "El valor de w no esta dentro de los limites permitidos";
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
                    Regex reg = new Regex(@"[a-zA-Z]+");
                    if (reg.IsMatch(word))
                    {
                        return "Sola se permiten números en este campo.";
                    }
                    break;
            }
            return string.Empty;
        }

        public string ValueForAssignation(string[] array, int n)
        {
            int value = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                value = Convert.ToInt32(array[i]);
                if (value < 1 || value > n)
                {
                    return "Todos los valores de las posiciones de cubo deben mayores de 1 pero menosre o iguales que el tamaño del mismo.";
                }
            }
            return string.Empty;
        }

        public string ValueForSummation(string[] array, int n)
        {
            int value1 = 0;
            int value2 = 0;
            for (int i = 0; i < array.Length/2; i++)
            {
                value1 = Convert.ToInt32(array[i]);
                value2 = Convert.ToInt32(array[i + 3]);
                if ((value1 < 1 || value1 > n) || (value2 < 1 || value2 > n) || (value2 < value1))
                {
                    return "Todos los valores de las posiciones de cubo deben mayores de 1 pero menores o iguales que el tamaño del mismo. Adicional x1, y1, z1 deben ser menores que x2, y2, z3";
                }
            }
            return string.Empty;
        }
    }
}