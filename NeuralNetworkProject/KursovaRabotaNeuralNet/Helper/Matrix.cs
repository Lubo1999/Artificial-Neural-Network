using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaRabotaNeuralNet.Helper
{
    [Serializable]
    public class Matrix
    {
        private Double[][] matrix;
        private Int32 rows;
        private Int32 columns;
        private static Random random = new Random();

        public double[] this[int index1]
        {
            get => matrix[index1];
            set => matrix[index1] = value;
        }

        public double this[int index1, int index2]
        {
            get => matrix[index1][index2];
            set => matrix[index1][index2] = value;
        }

        public Int32 Rows
        {
            get => rows;
            set => rows = value;
        }

        public Int32 Columns
        {
            get => columns;
            set => columns = value;
        }

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new double[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new double[columns];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = 0.0;
                }
            }
        }

        public void RandomizeMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = random.NextDouble() * 0.00025;
                }
            }
        }

        public static Matrix Transpose(Matrix matrix)
        {
            Matrix newMatrix = new Matrix(matrix.columns, matrix.rows);

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    newMatrix.matrix[j][i] = matrix.matrix[i][j];
                }
            }

            return newMatrix;
        }

        public static Matrix HadamardProduct(Matrix m1, Matrix m2)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new InvalidOperationException("Rows/columns must be equal.");
            }

            Matrix newMatrix = new Matrix(m1.rows, m2.columns);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    newMatrix.matrix[i][j] = m1.matrix[i][j] * m2.matrix[i][j];
                }
            }

            return newMatrix;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new InvalidOperationException("Rows/columns must be equal.");
            }

            Matrix newMatrix = new Matrix(m1.rows, m2.columns);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    newMatrix.matrix[i][j] = m1.matrix[i][j] + m2.matrix[i][j];
                }
            }

            return newMatrix;
        }

        public static Matrix operator +(Matrix m, double n)
        {
            Matrix newMatrix = new Matrix(m.rows, m.columns);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    newMatrix[i][j] = m[i][j] + n;
                }
            }

            return m;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new InvalidOperationException("Rows/columns must be equal.");
            }

            Matrix newMatrix = new Matrix(m1.rows, m1.columns);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    newMatrix[i][j] = m1[i][j] - m2[i][j];
                }
            }

            return newMatrix;
        }

        public static Matrix operator -(double a, Matrix m)
        {
            Matrix newMatrix = new Matrix(m.rows, m.columns);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    newMatrix[i][j] = a - m[i][j];
                }
            }
            return newMatrix;
        }

        public static Matrix operator *(double scalar, Matrix m1)
        {
            Matrix newMatrix = new Matrix(m1.rows, m1.columns);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    newMatrix[i][j] = m1[i][j] * scalar;
                }
            }

            return newMatrix;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.columns != m2.rows)
            {
                throw new InvalidOperationException("Columns from first matrix must be equal to the rows of the second matrix.");
            }

            Matrix newMatrix = new Matrix(m1.rows, m2.columns);

            Parallel.For(0, m1.rows, (i) =>
            {
                for (int j = 0; j < m2.columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m1.columns; k++)
                    {
                        sum += m1[i][k] * m2[k][j];
                    }
                    newMatrix[i][j] = sum;
                }
            });

            return newMatrix;
        }

        public static Matrix operator /(Matrix m1, Matrix m2)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new InvalidOperationException("Rows/columns must be equal.");
            }

            Matrix newMatrix = new Matrix(m1.rows, m1.columns);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    newMatrix[i][j] = m1[i][j] / m2[i][j];
                }
            }

            return newMatrix;
        }

        public static Matrix FromArray(double[] array)
        {
            Matrix newMatrix = new Matrix(array.Length, 1);

            for (int i = 0; i < array.Length; i++)
            {
                newMatrix[i][0] = array[i];
            }

            return newMatrix;
        }

        public static double[] ToArray(Matrix m)
        {
            double[] array = new double[m.rows];

            for (int i = 0; i < m.rows; i++)
            {
                array[i] = m[i][0];
            }
            return array;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    s += matrix[i][j] + "\t";
                }
                s += "\r\n";
            }
            return s;
        }

    }
}
