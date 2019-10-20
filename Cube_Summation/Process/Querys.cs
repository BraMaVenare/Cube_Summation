namespace Cube_Summation.Process
{
    public class Querys
    {
        public double[,,] AsignationValue(int x, int y, int z, double w, double[,,]Cube)
        {
            Cube[x, y, z] = w;
            return Cube;
        }

        public double SummationCube(int x1, int y1, int z1, int x2, int y2, int z2, double[,,] Cube)
        {
            double result = 0.0;
            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    for (int z = z1; z <= z2; z++)
                    {
                        result = result + Cube[x, y, z];
                    }
                }
            }

            return result;
        }
    }
}