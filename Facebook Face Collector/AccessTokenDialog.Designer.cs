namespace Facebook_Face_Collector
{
    partial class AccessTokenDialog
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
            this.accessTokenBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accessTokenBox
            // 
            this.accessTokenBox.Location = new System.Drawing.Point(12, 57);
            this.accessTokenBox.Name = "accessTokenBox";
            this.accessTokenBox.Size = new System.Drawing.Size(274, 20);
            this.accessTokenBox.TabIndex = 0;
            this.accessTokenBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Invalid web request - your access token may have expired. Generate a new one and " +
    "enter it below.";
            // 
            // confirmButton
            // 
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Location = new System.Drawing.Point(211, 96);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Okay";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.quitButton.Location = new System.Drawing.Point(130, 96);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // AccessTokenDialog
            // 
            this.AcceptButton = this.confirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.quitButton;
            this.ClientSize = new System.Drawing.Size(298, 131);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessTokenBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccessTokenDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AccessTokenDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button quitButton;
        public System.Windows.Forms.TextBox accessTokenBox;
    }
}