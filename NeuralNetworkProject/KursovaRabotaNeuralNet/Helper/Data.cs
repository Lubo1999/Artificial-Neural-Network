using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaRabotaNeuralNet.Helper
{
    public class Data
    {
        private int label;
        private double[] pixels = new double[784];

        public double[] Pixels
        {
            get
            {
                return pixels;
            }
            set
            {
                pixels = value;
            }
        }

        public int Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
            }
        }

        public Matrix LabelConversion()
        {
            Matrix matrix = new Matrix(10, 1);

            matrix[label][0] = 1.0;

            return matrix;
        }
    }
}
