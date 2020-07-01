namespace KursovaRabotaNeuralNet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreateNNB = new System.Windows.Forms.Button();
            this.TrainB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.LoadTestImagesB = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ClearImages = new System.Windows.Forms.Button();
            this.LoadNN_B = new System.Windows.Forms.Button();
            this.SaveNN_B = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadTrainingDataB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Label});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(412, 582);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // CreateNNB
            // 
            this.CreateNNB.Location = new System.Drawing.Point(4, 185);
            this.CreateNNB.Margin = new System.Windows.Forms.Padding(4);
            this.CreateNNB.Name = "CreateNNB";
            this.CreateNNB.Size = new System.Drawing.Size(334, 28);
            this.CreateNNB.TabIndex = 2;
            this.CreateNNB.Text = "Create NN";
            this.CreateNNB.UseVisualStyleBackColor = true;
            this.CreateNNB.Click += new System.EventHandler(this.CreateNNB_Click);
            // 
            // TrainB
            // 
            this.TrainB.Location = new System.Drawing.Point(4, 293);
            this.TrainB.Margin = new System.Windows.Forms.Padding(4);
            this.TrainB.Name = "TrainB";
            this.TrainB.Size = new System.Drawing.Size(334, 28);
            this.TrainB.TabIndex = 3;
            this.TrainB.Text = "Train";
            this.TrainB.UseVisualStyleBackColor = true;
            this.TrainB.Click += new System.EventHandler(this.TrainB_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 491);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(334, 88);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Minibatch size:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(187, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(151, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(187, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(151, 22);
            this.textBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number of samples:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(187, 133);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(151, 22);
            this.textBox4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Learning rate:";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(4, 458);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(335, 27);
            this.TestButton.TabIndex = 15;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // LoadTestImagesB
            // 
            this.LoadTestImagesB.Location = new System.Drawing.Point(4, 391);
            this.LoadTestImagesB.Name = "LoadTestImagesB";
            this.LoadTestImagesB.Size = new System.Drawing.Size(335, 28);
            this.LoadTestImagesB.TabIndex = 16;
            this.LoadTestImagesB.Text = "Load test images";
            this.LoadTestImagesB.UseVisualStyleBackColor = true;
            this.LoadTestImagesB.Click += new System.EventHandler(this.LoadTestImagesB_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(187, 41);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(151, 22);
            this.textBox6.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Type:";
            // 
            // ClearImages
            // 
            this.ClearImages.Location = new System.Drawing.Point(4, 425);
            this.ClearImages.Name = "ClearImages";
            this.ClearImages.Size = new System.Drawing.Size(335, 27);
            this.ClearImages.TabIndex = 19;
            this.ClearImages.Text = "Clear images";
            this.ClearImages.UseVisualStyleBackColor = true;
            this.ClearImages.Click += new System.EventHandler(this.ClearImages_Click);
            // 
            // LoadNN_B
            // 
            this.LoadNN_B.Location = new System.Drawing.Point(4, 221);
            this.LoadNN_B.Margin = new System.Windows.Forms.Padding(4);
            this.LoadNN_B.Name = "LoadNN_B";
            this.LoadNN_B.Size = new System.Drawing.Size(334, 28);
            this.LoadNN_B.TabIndex = 20;
            this.LoadNN_B.Text = "Load NN";
            this.LoadNN_B.UseVisualStyleBackColor = true;
            this.LoadNN_B.Click += new System.EventHandler(this.LoadNN_B_Click);
            // 
            // SaveNN_B
            // 
            this.SaveNN_B.Location = new System.Drawing.Point(4, 257);
            this.SaveNN_B.Margin = new System.Windows.Forms.Padding(4);
            this.SaveNN_B.Name = "SaveNN_B";
            this.SaveNN_B.Size = new System.Drawing.Size(334, 28);
            this.SaveNN_B.TabIndex = 21;
            this.SaveNN_B.Text = "Save NN";
            this.SaveNN_B.UseVisualStyleBackColor = true;
            this.SaveNN_B.Click += new System.EventHandler(this.SaveNN_B_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "D:\\Uni\\Синтез и анализ на алгоритми\\KursovaRabotaNeuralNet\\KursovaRabotaNeuralNet" +
    "\\NNs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Interations:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(187, 102);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(151, 22);
            this.textBox7.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 27);
            this.button1.TabIndex = 24;
            this.button1.Text = "Stop training";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LoadTrainingDataB
            // 
            this.LoadTrainingDataB.Location = new System.Drawing.Point(4, 361);
            this.LoadTrainingDataB.Name = "LoadTrainingDataB";
            this.LoadTrainingDataB.Size = new System.Drawing.Size(335, 27);
            this.LoadTrainingDataB.TabIndex = 25;
            this.LoadTrainingDataB.Text = "Load training data";
            this.LoadTrainingDataB.UseVisualStyleBackColor = true;
            this.LoadTrainingDataB.Click += new System.EventHandler(this.LoadTrainingDataB_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TestButton);
            this.panel1.Controls.Add(this.LoadTrainingDataB);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.LoadTestImagesB);
            this.panel1.Controls.Add(this.TrainB);
            this.panel1.Controls.Add(this.ClearImages);
            this.panel1.Controls.Add(this.SaveNN_B);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.LoadNN_B);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CreateNNB);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(412, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 582);
            this.panel1.TabIndex = 26;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = global::KursovaRabotaNeuralNet.Properties.Settings.Default.Text;
            this.saveFileDialog1.FileName = "nn";
            this.saveFileDialog1.InitialDirectory = "D:\\Uni\\Синтез и анализ на алгоритми\\KursovaRabotaNeuralNet\\KursovaRabotaNeuralNet" +
    "\\NNs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(776, 629);
            this.MinimumSize = new System.Drawing.Size(776, 629);
            this.Name = "Form1";
            this.Text = "Neural network";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button CreateNNB;
        private System.Windows.Forms.Button TrainB;
        private System.Windows.Forms.ColumnHeader Label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button LoadTestImagesB;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ClearImages;
        private System.Windows.Forms.Button LoadNN_B;
        private System.Windows.Forms.Button SaveNN_B;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoadTrainingDataB;
        private System.Windows.Forms.Panel panel1;
    }
}

