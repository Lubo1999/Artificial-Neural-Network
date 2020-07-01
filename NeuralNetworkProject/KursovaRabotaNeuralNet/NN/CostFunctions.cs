using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursovaRabotaNeuralNet.Helper;

namespace KursovaRabotaNeuralNet.NN
{
    public static class CostFunctions
    {
        public static double QuadraticLossFunction(Matrix target, Matrix output)
        {
            double sum = 0;

            for (int i = 0; i < target.Rows; i++)
            {
                sum += (target[i][0] - output[i][0]) * (target[i][0] * output[i][0]);
            }

            return sum / 2;
        }
        public static Matrix QuadraticLossFunctionDev(Matrix target, Matrix output)
        {
            return output - target;
        }

        public static Matrix LogLossDev(Matrix target, Matrix output)
        {
            Matrix gradient = new Matrix(target.Rows, target.Columns);

            for (int i = 0; i < target.Rows; i++)
            {
                if (target[i][0] == 1)
                    gradient[i][0] = -1 / output[i][0];
            }

            return gradient;
            //return (target - output) / Matrix.HadamardProduct(output, 1 - output);
        }

        public static double LogLoss(Matrix target, Matrix output)
        {
            double sum = 0;
            for (int i = 0; i < target.Rows; i++)
            {
                sum -= target[i][0] * Math.Log(output[i][0]);
            }
            return sum;
        }

    }
}
