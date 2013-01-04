namespace PrimeFinder
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.listViewPrime = new System.Windows.Forms.ListView();
            this.sliderThread = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelThread = new System.Windows.Forms.Label();
            this.labelNbFound = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTT = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sliderThread)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(438, 63);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(102, 29);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start !";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listViewPrime
            // 
            this.listViewPrime.Location = new System.Drawing.Point(12, 63);
            this.listViewPrime.Name = "listViewPrime";
            this.listViewPrime.Size = new System.Drawing.Size(420, 195);
            this.listViewPrime.TabIndex = 1;
            this.listViewPrime.UseCompatibleStateImageBehavior = false;
            // 
            // sliderThread
            // 
            this.sliderThread.AutoSize = false;
            this.sliderThread.LargeChange = 1;
            this.sliderThread.Location = new System.Drawing.Point(164, 21);
            this.sliderThread.Maximum = 20;
            this.sliderThread.Minimum = 1;
            this.sliderThread.Name = "sliderThread";
            this.sliderThread.Size = new System.Drawing.Size(313, 36);
            this.sliderThread.TabIndex = 2;
            this.sliderThread.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre de Threads :";
            // 
            // labelThread
            // 
            this.labelThread.AutoSize = true;
            this.labelThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThread.Location = new System.Drawing.Point(483, 21);
            this.labelThread.Name = "labelThread";
            this.labelThread.Size = new System.Drawing.Size(18, 20);
            this.labelThread.TabIndex = 4;
            this.labelThread.Text = "1";
            // 
            // labelNbFound
            // 
            this.labelNbFound.AutoSize = true;
            this.labelNbFound.Location = new System.Drawing.Point(441, 192);
            this.labelNbFound.Name = "labelNbFound";
            this.labelNbFound.Size = new System.Drawing.Size(13, 13);
            this.labelNbFound.TabIndex = 5;
            this.labelNbFound.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(441, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Premiers Trouvés";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(438, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parallel Time :";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(441, 140);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(29, 13);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "0 ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(441, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time to 1000 numbers";
            // 
            // labelTT
            // 
            this.labelTT.AutoSize = true;
            this.labelTT.Location = new System.Drawing.Point(441, 166);
            this.labelTT.Name = "labelTT";
            this.labelTT.Size = new System.Drawing.Size(26, 13);
            this.labelTT.TabIndex = 11;
            this.labelTT.Text = "0ms";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Fichiers Textes pour PrimeFinder (*.txt)|*.txt";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(438, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Save Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(439, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Load Results";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Fichiers Textes pour PrimeFinder (*.txt)|*.txt";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 270);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelTT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNbFound);
            this.Controls.Add(this.labelThread);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sliderThread);
            this.Controls.Add(this.listViewPrime);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "PrimeFinder By DARK_DUCK";
            ((System.ComponentModel.ISupportInitialize)(this.sliderThread)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListView listViewPrime;
        private System.Windows.Forms.TrackBar sliderThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelThread;
        private System.Windows.Forms.Label labelNbFound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTT;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

