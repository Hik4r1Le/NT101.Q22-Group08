namespace CaesarCipher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.NumericUpDown numKey;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnBruteForce;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblKey = new Label();
            numKey = new NumericUpDown();
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            btnBruteForce = new Button();
            btnClear = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numKey).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CAESAR CIPHER";
            // 
            // lblKey
            // 
            lblKey.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKey.Location = new Point(12, 54);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(81, 28);
            lblKey.TabIndex = 1;
            lblKey.Text = "Khóa:";
            // 
            // numKey
            // 
            numKey.Location = new Point(99, 55);
            numKey.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numKey.Name = "numKey";
            numKey.Size = new Size(163, 27);
            numKey.TabIndex = 2;
            // 
            // txtInput
            // 
            txtInput.BackColor = SystemColors.Window;
            txtInput.ForeColor = SystemColors.ActiveCaptionText;
            txtInput.Location = new Point(20, 100);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Vui lòng nhập plaintext/ciphertext vào đây";
            txtInput.Size = new Size(350, 350);
            txtInput.TabIndex = 3;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.Window;
            txtOutput.Location = new Point(400, 100);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(350, 350);
            txtOutput.TabIndex = 4;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(268, 52);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 34);
            btnEncrypt.TabIndex = 5;
            btnEncrypt.Text = "Mã hóa";
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(368, 52);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 34);
            btnDecrypt.TabIndex = 6;
            btnDecrypt.Text = "Giải mã";
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnBruteForce
            // 
            btnBruteForce.Location = new Point(468, 52);
            btnBruteForce.Name = "btnBruteForce";
            btnBruteForce.Size = new Size(94, 34);
            btnBruteForce.TabIndex = 7;
            btnBruteForce.Text = "Brute-force";
            btnBruteForce.Click += btnBruteForce_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(568, 51);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "Xóa";
            btnClear.Click += btnClear_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(20, 470);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(700, 30);
            lblStatus.TabIndex = 9;
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 520);
            Controls.Add(lblTitle);
            Controls.Add(lblKey);
            Controls.Add(numKey);
            Controls.Add(txtInput);
            Controls.Add(txtOutput);
            Controls.Add(btnEncrypt);
            Controls.Add(btnDecrypt);
            Controls.Add(btnBruteForce);
            Controls.Add(btnClear);
            Controls.Add(lblStatus);
            Name = "MainForm";
            Text = "Caesar Cipher";
            ((System.ComponentModel.ISupportInitialize)numKey).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }

    #endregion
}
