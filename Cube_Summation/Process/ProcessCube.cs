using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cube_Summation.Process
{
    public class ProcessCube
    {
        public string allCube(object[] Asignations, int n)
        {
            string Result = string.Empty;
            int x, y, z, x2, y2, z2;
            double[,,] Cube = new double[n, n, n];
            Querys q = new Querys();
            foreach (string[] item in Asignations)
            {
                if (item.Length == 4)
                {

                    x = Convert.ToInt32(item[0]) - 1;
                    y = Convert.ToInt32(item[1]) - 1;
                    z = Convert.ToInt32(item[2]) - 1;
                    Cube = q.AsignationValue(x,
                                             y,
                                             z,
                                             Convert.ToDouble(item[3]),
                                             Cube);
                }
                else
                {
                    x = Convert.ToInt32(item[0]) - 1;
                    y = Convert.ToInt32(item[1]) - 1;
                    z = Convert.ToInt32(item[2]) - 1;
                    x2 = Convert.ToInt32(item[3]) - 1;
                    y2 = Convert.ToInt32(item[4]) - 1;
                    z2 = Convert.ToInt32(item[5]) - 1;
                    Result = Result + q.SummationCube(x, y, z, x2, y2, z2, Cube) + "<br />";
                }

            }
            return Result;
        }
    }
}