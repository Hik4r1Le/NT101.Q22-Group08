namespace PlayfairCipher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblMatrix;
        private System.Windows.Forms.TextBox txtMatrix;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblMatrix = new System.Windows.Forms.Label();
            this.txtMatrix = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PLAYFAIR CIPHER";

            // lblKey
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(22, 65);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(38, 15);
            this.lblKey.TabIndex = 1;
            this.lblKey.Text = "Khóa:";

            // txtKey
            this.txtKey.Location = new System.Drawing.Point(70, 62);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(220, 23);
            this.txtKey.TabIndex = 2;

            // btnEncrypt
            this.btnEncrypt.Location = new System.Drawing.Point(320, 58);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(100, 32);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Mã hóa";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);

            // btnDecrypt
            this.btnDecrypt.Location = new System.Drawing.Point(430, 58);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(100, 32);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Giải mã";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(540, 58);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // lblInput
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(22, 110);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(92, 15);
            this.lblInput.TabIndex = 6;
            this.lblInput.Text = "Văn bản đầu vào:";

            // txtInput
            this.txtInput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtInput.Location = new System.Drawing.Point(25, 135);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(420, 370);
            this.txtInput.TabIndex = 7;

            // lblOutput
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(468, 110);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(47, 15);
            this.lblOutput.TabIndex = 8;
            this.lblOutput.Text = "Kết quả:";

            // txtOutput
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtOutput.Location = new System.Drawing.Point(471, 135);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(420, 370);
            this.txtOutput.TabIndex = 9;

            // lblMatrix
            this.lblMatrix.AutoSize = true;
            this.lblMatrix.Location = new System.Drawing.Point(910, 110);
            this.lblMatrix.Name = "lblMatrix";
            this.lblMatrix.Size = new System.Drawing.Size(122, 15);
            this.lblMatrix.TabIndex = 10;
            this.lblMatrix.Text = "Ma trận Playfair 5 x 5:";

            // txtMatrix
            this.txtMatrix.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtMatrix.Location = new System.Drawing.Point(913, 135);
            this.txtMatrix.Multiline = true;
            this.txtMatrix.Name = "txtMatrix";
            this.txtMatrix.ReadOnly = true;
            this.txtMatrix.Size = new System.Drawing.Size(220, 160);
            this.txtMatrix.TabIndex = 11;

            // lblStatus
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(25, 525);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1108, 32);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 580);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtMatrix);
            this.Controls.Add(this.lblMatrix);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playfair Cipher App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
