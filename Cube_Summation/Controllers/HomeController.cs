using Cube_Summation.Process;
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
        #region Global values

        //Creo un objeto global de tipo validations para realizar las respectivas validaciones.
        Validations val = new Validations();
        #endregion

        #region Actions Results
        public ActionResult Index()
        {
            //Carga la vista principal de la pagina web (Index).
            return View();
        }
        #endregion

        #region JsonResults
        public JsonResult getCases(int Num_case)
        {
            try
            {
                string Validation = val.SingleIntegerValidations("Num_Cases", Num_case);
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
                Validation = val.SingleIntegerValidations("LengthCube", SaveNumbers.Length);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                Validation = val.StringValidations("CubeOpStr", SaveNumbers[0]);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                Validation = val.StringValidations("CubeOpStr", SaveNumbers[1]);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                int Cube = Convert.ToInt32(SaveNumbers[0]);
                Validation = val.SingleIntegerValidations("Cube", Cube);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
                int Operations = Convert.ToInt32(SaveNumbers[1]);
                Validation = val.SingleIntegerValidations("Operations", Operations);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }
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

        public JsonResult For_Do_Operations(string ValuesOperation, int n)
        {
            try
            {
                string Validation = string.Empty;
                string[] SaveNumbers = ValuesOperation.Split(' ');
                Validation = val.SingleIntegerValidations("LengthOperation", SaveNumbers.Length);
                if (!string.IsNullOrEmpty(Validation))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = Validation,
                    });
                }

                for (int i = 0; i < SaveNumbers.Length; i++)
                {
                    Validation = val.StringValidations("CubeOpStr", SaveNumbers[i]);
                    if (!string.IsNullOrEmpty(Validation))
                    {
                        return Json(new
                        {
                            IsSuccess = false,
                            Message = Validation,
                        });
                    }
                }

                if (SaveNumbers.Length == 4)
                {
                    Validation = val.ValueForAssignation(SaveNumbers, n);
                    if (!string.IsNullOrEmpty(Validation))
                    {
                        return Json(new
                        {
                            IsSuccess = false,
                            Message = Validation,
                        });
                    }

                    Validation = val.SingleDoubleValidation(Convert.ToDouble(SaveNumbers[3]));
                    if (!string.IsNullOrEmpty(Validation))
                    {
                        return Json(new
                        {
                            IsSuccess = false,
                            Message = Validation,
                        });
                    }
                }
                else
                {
                    Validation = val.ValueForSummation(SaveNumbers, n);
                    if (!string.IsNullOrEmpty(Validation))
                    {
                        return Json(new
                        {
                            IsSuccess = false,
                            Message = Validation,
                        });
                    }
                }
                return Json(new
                {
                    IsSuccess = true,
                    SaveRow = SaveNumbers,
                    NumColumns = SaveNumbers.Length,
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

        public JsonResult Process_Cube(object[] Asignations, int n)
        {
            try
            {
                ProcessCube Cube = new ProcessCube();               
                return Json(new
                {
                    IsSuccess = true,
                    CubeComplete = Cube.allCube(Asignations, n),
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
        #endregion
    }
}