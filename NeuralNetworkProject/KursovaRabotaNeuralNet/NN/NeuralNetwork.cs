using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursovaRabotaNeuralNet.Helper;

namespace KursovaRabotaNeuralNet.NN
{
    [Serializable]
    public class NeuralNetwork
    {
        private Int32 inputSize;

        //number of layers without the input layer
        private Int32 layersCount;

        //an array of layer sizes without the input layer
        private Int32[] layerSizes;

        //an array of matrices where every matrix is the input to the neurons at layer i [from 1 to layersCount]
        private Matrix[] layerInput;

        //an array of matrices where every matrix is the output from layer i [from 1 to layersCount]
        private Matrix[] layerOutput;

        //array of weight matrices where at layer L the dimensions of the weight matrix are: 
        //rows - the size of the current layer L, columns - the size of the previous layer L - 1
        private Matrix[] weights;
        private Matrix[] biases;

        //the error in every layer
        private Matrix[] deltas;

        private Func<Matrix, Matrix>[] activationFunctions;
        private Func<Matrix, Matrix>[] activationFunctionsDerivatives;

        private Func<Matrix, Matrix, double> costFunction;
        private Func<Matrix, Matrix, Matrix> costFunctionDerivative;

        public NeuralNetwork(
            Func<Matrix, Matrix, double> costFunction,
            Func<Matrix, Matrix>[] activationFunctions,
            params Int32[] layerSizes)
        {
            if (activationFunctions.Length != layerSizes.Length - 1)
                throw new Exception("Cannot initialize network with these parameters.");

            inputSize = layerSizes[0];
            layersCount = layerSizes.Length - 1;

            this.activationFunctions = activationFunctions;
            this.layerSizes = new Int32[layersCount];

            this.costFunction = costFunction;
            InitActivationFunctionsDerivatives(activationFunctions);
            InitCostFuncDerivative(costFunction);

            for (int i = 0; i < layersCount; i++)
            {
                this.layerSizes[i] = layerSizes[i + 1];
            }

            layerInput = new Matrix[layersCount];
            layerOutput = new Matrix[layersCount];
            biases = new Matrix[layersCount];
            weights = new Matrix[layersCount];
            deltas = new Matrix[layersCount];

            for (int i = 0; i < layersCount; i++)
            {
                layerInput[i] = new Matrix(this.layerSizes[i], 1);
                layerOutput[i] = new Matrix(this.layerSizes[i], 1);

                biases[i] = new Matrix(this.layerSizes[i], 1);
                weights[i] = new Matrix(this.layerSizes[i], i == 0 ? inputSize : this.layerSizes[i - 1]);

                deltas[i] = new Matrix(this.layerSizes[i], 1);
            }

            for (int i = 0; i < layersCount; i++)
            {
                biases[i].RandomizeMatrix();
                weights[i].RandomizeMatrix();
            }
        }

        public Matrix FeedForward(Matrix input)
        {
            if (input.Rows != inputSize)
            {
                throw new InvalidOperationException("Input size does not match the size of the input layer.");
            }

            for (int i = 0; i < layersCount; i++)
            {
                //z[i] = w[i] * a[i - 1] + b[i]
                layerInput[i] = weights[i] *
                    (i == 0
                    ? input
                    : layerOutput[i - 1])
                    + biases[i];

                //a[i] = f(z[i])
                layerOutput[i] = activationFunctions[i](layerInput[i]);
            }
            return layerOutput[layersCount - 1];
        }

        public Matrix[] BackPropagation(
            Matrix input,
            Matrix target/*hard-encoded vector*/)
        {
            Matrix networkOutput = FeedForward(input);

            for (int i = layersCount - 1; i >= 0; i--)
            {
                if (i == layersCount - 1)
                {
                    #region CrossEntropyLoss
                    if (activationFunctions[layersCount - 1] == ActivationFunctions.SoftMax && costFunction == CostFunctions.LogLoss)
                    {
                        deltas[i] = networkOutput - target;
                        continue;
                    }                  
                    #endregion
                    //calculating the error of the last layer 
                    deltas[i] = Matrix.HadamardProduct(
                        costFunctionDerivative(target, networkOutput),
                        activationFunctionsDerivatives[i](layerInput[i])
                        );
                }
                else
                {
                    //calculating the error of layers (layerCount - 2 to 1)
                    deltas[i] = Matrix.HadamardProduct(
                    Matrix.Transpose(weights[i + 1]) * deltas[i + 1],
                    activationFunctionsDerivatives[i](layerInput[i])
                    );
                }
            }

            return deltas;
        }

        public void MiniBatchTrain(
            List<Data> miniBatch,
            int miniBatchCount,
            double learningRate,
            out double error)
        {
            Matrix[][] deltas = new Matrix[miniBatch.Count][];
            Matrix[][] miniBatchesOutput = new Matrix[miniBatch.Count][];
            Matrix[] weigthsDeltas = new Matrix[layersCount];
            Matrix[] biasesDeltas = new Matrix[layersCount];
            error = 0;

            for (int i = 0; i < deltas.Length; i++)
            {
                deltas[i] = new Matrix[layersCount - 1];
                miniBatchesOutput[i] = new Matrix[layersCount];
            }

            for (int i = 0; i < layersCount; i++)
            {
                biasesDeltas[i] = new Matrix(this.layerSizes[i], 1);
                weigthsDeltas[i] = new Matrix(this.layerSizes[i], i == 0 ? inputSize : this.layerSizes[i - 1]);
            }

            for (int i = 0; i < miniBatch.Count; i++)
            {
                //for every minibatch feedforward through the network
                for (int j = 0; j < layersCount; j++)
                {
                    layerInput[j] = weights[j] *
                        (j == 0
                        ? Matrix.FromArray(miniBatch[i].Pixels)
                        : layerOutput[j - 1])
                        + biases[j];
                    layerOutput[j] = activationFunctions[j](layerInput[j]);

                    //for the current sample calculate the output of every layer
                    miniBatchesOutput[i][j] = layerOutput[j];
                }

                //for every minibatch calculate the deltas in each layer
                deltas[i] = BackPropagation(Matrix.FromArray(miniBatch[i].Pixels), miniBatch[i].LabelConversion());
                error += costFunction(miniBatch[i].LabelConversion(), miniBatchesOutput[i][layersCount - 1]);
            }

            error /= miniBatchCount;

            for (int i = 0; i < deltas.Length; i++)
            {
                for (int j = deltas[i].Length - 1; j >= 0; j--)
                {
                    weigthsDeltas[j] += deltas[i][j] *
                        Matrix.Transpose(
                        j == 0
                        ? Matrix.FromArray(miniBatch[i].Pixels)
                        : miniBatchesOutput[i][j - 1]);
                    biasesDeltas[j] += deltas[i][j];
                }
            }

            for (int i = layersCount - 1; i >= 0; i--)
            {
                weights[i] -= (learningRate / miniBatchCount) * weigthsDeltas[i];
                biases[i] -= (learningRate / miniBatchCount) * biasesDeltas[i];
            }
        }

        private void InitActivationFunctionsDerivatives(Func<Matrix, Matrix>[] activationFunctions)
        {
            activationFunctionsDerivatives = new Func<Matrix, Matrix>[activationFunctions.Length];

            for (int i = 0; i < activationFunctions.Length; i++)
            {
                if (activationFunctions[i] == ActivationFunctions.Sigmoid)
                    activationFunctionsDerivatives[i] = ActivationFunctions.DSigmoid;

                if (activationFunctions[i] == ActivationFunctions.ReLU)
                    activationFunctionsDerivatives[i] = ActivationFunctions.DReLU;

                if (activationFunctions[i] == ActivationFunctions.LReLU)
                    activationFunctionsDerivatives[i] = ActivationFunctions.DLReLU;
            }
        }

        private void InitCostFuncDerivative(Func<Matrix, Matrix, double> costFunc)
        {
            if (costFunc == CostFunctions.QuadraticLossFunction)
                costFunctionDerivative = CostFunctions.QuadraticLossFunctionDev;

            if (costFunc == CostFunctions.LogLoss)
                costFunctionDerivative = CostFunctions.LogLossDev;
        }
    }
}