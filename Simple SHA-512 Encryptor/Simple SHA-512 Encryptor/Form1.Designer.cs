namespace Simple_SHA_512_Encryptor
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
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLimit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPass
            // 
            this.tbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tbPass.Location = new System.Drawing.Point(10, 11);
            this.tbPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(360, 30);
            this.tbPass.TabIndex = 0;
            // 
            // tbSalt
            // 
            this.tbSalt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tbSalt.Location = new System.Drawing.Point(10, 45);
            this.tbSalt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(360, 30);
            this.tbSalt.TabIndex = 1;
            // 
            // tbResult
            // 
            this.tbResult.BackColor = System.Drawing.SystemColors.Window;
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tbResult.Location = new System.Drawing.Point(9, 108);
            this.tbResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(360, 140);
            this.tbResult.TabIndex = 2;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(11, 80);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(56, 24);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt!";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Limit:";
            // 
            // tbLimit
            // 
            this.tbLimit.Location = new System.Drawing.Point(322, 83);
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.Size = new System.Drawing.Size(44, 20);
            this.tbLimit.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 258);
            this.Controls.Add(this.tbLimit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbSalt);
            this.Controls.Add(this.tbPass);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbSalt;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLimit;
    }
}

