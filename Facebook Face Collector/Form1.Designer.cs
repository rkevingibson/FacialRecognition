namespace Facebook_Face_Collector
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
            this.accessTokenBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.folderPathBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accessTokenBox
            // 
            this.accessTokenBox.Location = new System.Drawing.Point(94, 33);
            this.accessTokenBox.Name = "accessTokenBox";
            this.accessTokenBox.Size = new System.Drawing.Size(267, 20);
            this.accessTokenBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Access Token";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(286, 194);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Go";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Location = new System.Drawing.Point(13, 72);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(75, 23);
            this.folderSelectButton.TabIndex = 3;
            this.folderSelectButton.Text = "Destination";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // folderPathBox
            // 
            this.folderPathBox.Location = new System.Drawing.Point(94, 74);
            this.folderPathBox.Name = "folderPathBox";
            this.folderPathBox.Size = new System.Drawing.Size(267, 20);
            this.folderPathBox.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 102);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(346, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 132);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(348, 56);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 229);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.folderPathBox);
            this.Controls.Add(this.folderSelectButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessTokenBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox accessTokenBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.TextBox folderPathBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

