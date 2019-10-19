namespace Cube_Summation.Process
{
    using System.Text.RegularExpressions;
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
                case "LengthCube":
                    if (number <= 1)
                    {
                        return "Debe separar los valores del cubo y las operaciones por un espacio en blanco";
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
                    Regex reg = new Regex(@"[a-zA-Z]+");
                    if (reg.IsMatch(word))
                    {
                        return "Solamente se permiten números en este campo.";
                    }
                    break;
            }
            return string.Empty;
        }
    }
}