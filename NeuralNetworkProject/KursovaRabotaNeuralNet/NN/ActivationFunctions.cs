using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursovaRabotaNeuralNet.Helper;

namespace KursovaRabotaNeuralNet.NN
{
    public static class ActivationFunctions
    {

        public static double alpha = 0.2;

        public static Matrix Sigmoid(Matrix m)
        {
            Matrix m1 = new Matrix(m.Rows, m.Columns);

            for (int i = 0; i < m.Rows; i++)
                m1[i][0] = 1.0 / (1.0 + Math.Pow(Math.E, -m[i][0]));

            return m1;
        }

        public static Matrix DSigmoid(Matrix m)
        {
            return Matrix.HadamardProduct(Sigmoid(m), 1.0 - Sigmoid(m));
        }

        public static Matrix SoftMax(Matrix m)
        {
            double sum = 0;
            Matrix m1 = new Matrix(m.Rows, m.Columns);

            for (int i = 0; i < m.Rows; i++)
                sum += Math.Exp(m[i][0]);

            for (int i = 0; i < m.Rows; i++)
                m1[i, 0] = Math.Exp(m[i][0]) / sum;

            return m1;
        }

        public static Matrix ReLU(Matrix m)
        {
            Matrix newMatrix = new Matrix(m.Rows, 1);

            for (int i = 0; i < m.Rows; i++)
                newMatrix[i][0] = Math.Max(0, m[i][0]);

            return newMatrix;
        }

        public static Matrix DReLU(Matrix m)
        {
            Matrix newMatrix = new Matrix(m.Rows, 1);

            for (int i = 0; i < m.Rows; i++)
            {
                if (m[i][0] > 0)
                    newMatrix[i][0] = 1;
                else
                    newMatrix[i][0] = 0;
            }

            return newMatrix;
        }


        public static Matrix LReLU(Matrix m)
        {
            Matrix newMatrix = new Matrix(m.Rows, 1);

            for (int i = 0; i < m.Rows; i++)
            {
                if (m[i][0] > 0)
                {
                    newMatrix[i][0] = m[i][0];
                }
                else
                {
                    newMatrix[i][0] = alpha * m[i][0];
                }
            }

            return newMatrix;
        }

        public static Matrix DLReLU(Matrix m)
        {
            Matrix newMatrix = new Matrix(m.Rows, 1);

            for (int i = 0; i < m.Rows; i++)
            {
                if (m[i][0] > 0)
                {
                    newMatrix[i][0] = 1;
                }
                else
                {
                    newMatrix[i][0] = alpha;
                }
            }

            return newMatrix;
        }
    }
}