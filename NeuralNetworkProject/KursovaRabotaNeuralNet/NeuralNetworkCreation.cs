using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KursovaRabotaNeuralNet.Helper;
using KursovaRabotaNeuralNet.NN;

namespace KursovaRabotaNeuralNet
{
    public partial class NeuralNetworkCreation : Form
    {
        private Func<Matrix, Matrix, double> costFunc;
        private int[] layersNeurons;
        private Func<Matrix, Matrix>[] aFuncs;
        public Func<Matrix, Matrix, double> CostFunction
        {
            get
            {
                return costFunc;
            }
            set
            {
                costFunc = value;
            }
        }

        public int[] LayersNeurons {
            get
            {
                return layersNeurons;
            }
            set
            {
                layersNeurons = value;
            }
        }

        public Func<Matrix, Matrix>[] ActivationFuncs
        {
            get
            {
                return aFuncs;
            }
            set
            {
                aFuncs = value;
            }
        }
        public NeuralNetworkCreation()
        {
            InitializeComponent();
        }

        //sigmoid, softmax, relu, lrelu
        private Func<Matrix, Matrix> FuncConversion(string acFunc)
        {
            string s = acFunc.ToLower();
            Func<Matrix, Matrix> func = null;

            switch (s)
            {
                case "sigmoid":
                    func = ActivationFunctions.Sigmoid;
                    break;
                case "softmax":
                    func = ActivationFunctions.SoftMax;
                    break;
                case "relu":
                    func = ActivationFunctions.ReLU;
                    break;
                case "lrelu":
                    func = ActivationFunctions.LReLU;
                    break;
                default:
                    break;
            }

            return func;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string[] aFuncH = textBox3.Text.Trim().Split(' ');

            int inputNeurons = int.Parse(textBox1.Text.Trim());

            int[] hiddenLayerNeurons = textBox2.Text.Trim()
                                                    .Split(' ')
                                                    .Select(x => int.Parse(x))
                                                    .ToArray();

            int outputNeurons = int.Parse(textBox4.Text.Trim());

            layersNeurons = new int[hiddenLayerNeurons.Length + 2];

            Func<Matrix, Matrix>[] funcs = new Func<Matrix, Matrix>[aFuncH.Length + 1];

            //getting the activation functions for every layer except the input layer
            for (int i = 0; i < aFuncH.Length; i++)
            {
                funcs[i] = FuncConversion(aFuncH[i]);
            }
            funcs[aFuncH.Length] = FuncConversion(textBox5.Text);
            aFuncs = funcs;

            //getting the cost function
            if (comboBox1.SelectedIndex == 0)
                costFunc = CostFunctions.QuadraticLossFunction;
            else if (comboBox1.SelectedIndex == 1)
                costFunc = CostFunctions.LogLoss;

            //getting the number of neurons in every layers 
            for (int i = 1; i < hiddenLayerNeurons.Length + 1; i++)
            {
                layersNeurons[i] = hiddenLayerNeurons[i - 1];
            }

            layersNeurons[0] = inputNeurons;
            layersNeurons[hiddenLayerNeurons.Length + 1] = outputNeurons;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
