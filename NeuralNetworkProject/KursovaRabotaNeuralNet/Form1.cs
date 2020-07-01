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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using CsvHelper;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace KursovaRabotaNeuralNet
{
    public partial class Form1 : Form
    {
        const string MNIST_FASHION_TRAINING_DATA_PATH = "../../Datasets/fashion-mnist_train_prep.csv";
        const string MNIST_FASHION_TEST_DATA_PATH = "../../Datasets/fashion-mnist_test_prep.csv";

        const string MNIST_DIGITS_TRAINING_DATA_PATH = "../../Datasets/mnist_train_prep.csv";
        const string MNIST_DIGITS_TEST_DATA_PATH = "../../Datasets/mnist_test_prep.csv";

        NeuralNetwork nn;
        List<Data> trainingData;
        List<int> predictions;
        bool training = false;

        public Form1()
        {
            InitializeComponent();
            imageList1.ImageSize = new Size(56, 56);
            trainingData = new List<Data>();
            predictions = new List<int>();
            listView1.SmallImageList = imageList1;
        }

        #region Images
        private byte[][] ToByteImages(List<Data> images)
        {
            byte[][] byteImages = new byte[images.Count][];

            //Converting the double array into byte array
            for (int i = 0; i < images.Count; i++)
            {
                byteImages[i] = new byte[784];
                for (int j = 0; j < 784; j++)
                {
                    byteImages[i][j] = (byte)(images[i].Pixels[j] * 255);
                }
            }

            return byteImages;
        }
        private void DisplayImages(List<Data> images, List<int> prediction)
        {
            byte[][] byteImages = ToByteImages(images);

            for (int i = 0; i < byteImages.Length; i++)
            {
                imageList1.Images.Add(ToBitmap(byteImages[i]));
            }

            listView1.SmallImageList = imageList1;
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = "Label: " + ToStringLabel(images[i].Label)
                        + "/Predicted:" + ToStringLabel(prediction[i]);
                listView1.Items.Add(item);
            }
        }
        private Bitmap ToBitmap(byte[] array)
        {
            Bitmap bmp = new Bitmap(28, 28, PixelFormat.Format8bppIndexed);

            ColorPalette palette = bmp.Palette;

            for (int i = 0; i < 256; i++)
            {
                palette.Entries[i] = Color.FromArgb(255, i, i, i);
            }

            bmp.Palette = palette;

            Rectangle rect = new Rectangle(0, 0, 28, 28);
            BitmapData bmpData = bmp.LockBits(rect,
                                              ImageLockMode.WriteOnly,
                                              bmp.PixelFormat);

            IntPtr intPtr = bmpData.Scan0;

            int bytes = bmpData.Stride * bmp.Width;

            Marshal.Copy(array, 0, intPtr, bytes);

            bmp.UnlockBits(bmpData);

            return bmp;
        }
        private static List<Data> ReadImages(string path, int n, int label)
        {
            List<Data> images = new List<Data>();

            for (int i = 0; i < n; i++)
                images.Add(new Data());

            double value;
            int k = -1;

            using (var fileReader = new StreamReader(path))
            using (var csvReader = new CsvReader(fileReader, true))
            {
                csvReader.Configuration.HasHeaderRecord = false;
                while (csvReader.Read() && k != images.Count - 1)
                {
                    for (int j = 0; csvReader.TryGetField<double>(j, out value); j++)
                    {
                        if (label != -1)
                        {
                            if (j == 0 && value != label)
                                break;
                        }

                        if (j == 0)
                        {
                            images[++k].Label = (int)value;
                        }
                        else
                        {
                            images[k].Pixels[j - 1] = value;
                        }
                    }

                }

            }
            return images;
        }
        private string ToStringLabel(int intLabel)
        {
            string label;
            switch (intLabel)
            {
                case 0:
                    label = "T-shirt/top";
                    break;
                case 1:
                    label = "Trouser";
                    break;
                case 2:
                    label = "Pullover";
                    break;
                case 3:
                    label = "Dress";
                    break;
                case 4:
                    label = "Coat";
                    break;
                case 5:
                    label = "Sandal";
                    break;
                case 6:
                    label = "Shirt";
                    break;
                case 7:
                    label = "Sneaker";
                    break;
                case 8:
                    label = "Bag";
                    break;
                case 9:
                    label = "Ankle boot";
                    break;
                default:
                    label = "?";
                    break;
            }
            return label;
        }

        private async void LoadData(string path)
        {
            int totalDataLength = int.Parse(textBox3.Text); //number of training samples
            int desiredLabel;
            int currentImageSize = trainingData.Count();
            List<Data> newImagesList = new List<Data>(totalDataLength);
            List<int> newPredictions = new List<int>(totalDataLength);

            await Task.Run(() =>
            {
                //loading specific type or if without a type specified load every sample in that range
                if (textBox6.Text == "")
                    desiredLabel = -1;
                else
                {
                    desiredLabel = int.Parse(textBox6.Text);
                }
                newImagesList = ReadImages(path, totalDataLength, desiredLabel);
            });


            //setting the current predicted status to '?'
            for (int i = 0; i < newImagesList.Count; i++)
                newPredictions.Add(-1);

            //getting the images from the samples
            var images = ToByteImages(newImagesList)
                            .Select(x => ToBitmap(x))
                            .ToArray();

            trainingData.AddRange(newImagesList);
            predictions.AddRange(newPredictions);
            imageList1.Images.AddRange(images);

            for (int i = 0; i < newImagesList.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.ImageIndex = i + currentImageSize;
                listViewItem.Text = "Label: " + ToStringLabel(trainingData[i + currentImageSize].Label)
                       + "/Predicted:" + ToStringLabel(predictions[i + currentImageSize]);
                listView1.Items.Add(listViewItem);
            }
        }
        #endregion

        private void ClearListView()
        {
            textBox6.Clear();
            trainingData.Clear();
            predictions.Clear();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            Invalidate();
        }
        private static bool GenerateMiniBatch(
            List<Data> trainingData,
            int batchNumber,
            int batchSize,
            out List<Data> miniBatch)
        {
            miniBatch = new List<Data>(batchSize);

            for (int i = 0; i < batchSize; i++)
            {
                miniBatch.Add(new Data());
            }

            int start = batchNumber * batchSize;

            for (int i = start; i < start + batchSize; i++)
            {
                if (trainingData[i] == null)
                    return false;

                miniBatch[i % batchSize] = trainingData[i];
            }

            return true;
        }

        private void ClearImages_Click(object sender, EventArgs e)
        {
            if (trainingData == null)
            {
                return;
            }
            ClearListView();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if (trainingData == null)
            {
                MessageBox.Show("No test data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            imageList1.Images.Clear();
            listView1.Items.Clear();

            for (int i = 0; i < trainingData.Count; i++)
            {
                Matrix output = nn.FeedForward(Matrix.FromArray(trainingData[i].Pixels));

                var index = Matrix.ToArray(output)
                                  .ToList()
                                  .IndexOf(Matrix.ToArray(output)
                                  .Max());

                predictions[i] = index;
            }

            DisplayImages(trainingData, predictions);
        }

        private void TrainB_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                MessageBox.Show("No network to train!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please fill for minibatch, interations and learning rate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int iterations = int.Parse(textBox7.Text);
            int miniBatchSize = int.Parse(textBox2.Text);
            double learningRate = double.Parse(textBox4.Text);
            int totalDataLength = int.Parse(textBox3.Text);

            int trainingDataLength = totalDataLength;
            int validationDataLength = totalDataLength - trainingDataLength;
            int epochs = trainingDataLength / miniBatchSize;

            List<Data> miniBatch;
            List<Data> trainingData = new List<Data>(this.trainingData);
            int k = 0;
            training = true;
            while (k++ < iterations && training)
            {
                //Training
                for (int i = 0; i < epochs && training; i++)
                {
                    double error;

                    textBox1.Text = "";
                    textBox1.Text += "Iteration:" + k + "\r\n";
                    textBox1.Text += "Epoch:" + i + "\r\n";

                    if (!GenerateMiniBatch(trainingData, i, miniBatchSize, out miniBatch))
                        break;

                    nn.MiniBatchTrain(miniBatch, miniBatchSize, learningRate, out error);
                    textBox1.Text += "Error: " + error + "\r\n";

                    Thread.Sleep(50);
                    Application.DoEvents();
                }
                trainingData.Shuffle();
            }
        }

        private void CreateNNB_Click(object sender, EventArgs e)
        {
            NeuralNetworkCreation form2 = new NeuralNetworkCreation();
            DialogResult dr = form2.ShowDialog();

            if (dr == DialogResult.OK)
            {
                nn = new NeuralNetwork(form2.CostFunction, form2.ActivationFuncs, form2.LayersNeurons);
                form2.Close();
                form2.Dispose();
            }

            if (dr == DialogResult.Cancel)
            {
                form2.Close();
                form2.Dispose();
            }
        }

        private void SaveNN_B_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                MessageBox.Show("No network to save!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IFormatter formatter = new BinaryFormatter();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(saveFileDialog1.FileName + ".txt", FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(stream, nn);
                }
            }
        }

        private void LoadNN_B_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string filePath = Path.Combine(openFileDialog1.InitialDirectory, openFileDialog1.FileName);
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    nn = formatter.Deserialize(stream) as NeuralNetwork;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            training = false;
        }

        private void LoadTrainingDataB_Click(object sender, EventArgs e)
        {
            LoadData(MNIST_FASHION_TRAINING_DATA_PATH);
        }

        private void LoadTestImagesB_Click(object sender, EventArgs e)
        {
            LoadData(MNIST_FASHION_TEST_DATA_PATH);
        }

    }
}
