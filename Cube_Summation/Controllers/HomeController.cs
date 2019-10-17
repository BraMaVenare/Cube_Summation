using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Cube_Summation.Controllers
{
    public class HomeController : Controller
    {
        int[,,] Cube_General;

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getCases(int Num_case)
        {
            try
            {
                string Validation = NumericalsValidations("Num_Cases", Num_case);
                if (string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = true,
                        Result = Num_case,
                    });
                }
                else
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Se ha presentado un error " + ex.Message,
                });
            }
        }

        public JsonResult Cube_Operations(string CubeOp)
        {
            try
            {
                string Validation = string.Empty;
                string[] SaveNumbers = new string[2];
                SaveNumbers = CubeOp.Split(' ');
                Validation = StringValidations("CubeOpStr", SaveNumbers[0]);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                Validation = StringValidations("CubeOpStr", SaveNumbers[1]);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                int Cube = Convert.ToInt32(SaveNumbers[0]);
                Validation = NumericalsValidations("Cube", Cube);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                int Operations = Convert.ToInt32(SaveNumbers[1]);
                Validation = NumericalsValidations("Operations", Operations);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                Cube_General = new int[Cube, Cube, Cube];
                return Json(new
                {
                    IsSuccess = true,
                    Value_Cube = Cube,
                    Value_Operations = Operations,
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Se ha presentado un error " + ex.Message,
                });
            }
        }

        private string NumericalsValidations(string strType, int number)
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

        private string StringValidations(string sreType, string word)
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