namespace PlayfairCipher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated variables

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppSubtitle;
        private System.Windows.Forms.Button btnPlayfair;
        private System.Windows.Forms.Button btnRSA;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCurrentCipher;

        private System.Windows.Forms.Panel pnlPlayfair;
        private System.Windows.Forms.Label lblPFSectionTitle;
        private System.Windows.Forms.Label lblPFKey;
        private System.Windows.Forms.TextBox txtPFKey;
        private System.Windows.Forms.Label lblPFInput;
        private System.Windows.Forms.TextBox txtPFInput;
        private System.Windows.Forms.Label lblPFOutput;
        private System.Windows.Forms.TextBox txtPFOutput;
        private System.Windows.Forms.Button btnPFEncrypt;
        private System.Windows.Forms.Button btnPFDecrypt;
        private System.Windows.Forms.Button btnPFClear;
        private System.Windows.Forms.Button btnPFCopy;
        private System.Windows.Forms.Label lblPFMatrix;
        private System.Windows.Forms.TextBox txtPFMatrix;

        private System.Windows.Forms.Panel pnlRSA;
        private System.Windows.Forms.Label lblRSASectionTitle;
        private System.Windows.Forms.Label lblRSAKeySize;
        private System.Windows.Forms.ComboBox cboRSAKeySize;
        private System.Windows.Forms.Label lblRSAPadding;
        private System.Windows.Forms.ComboBox cboRSAPadding;
        private System.Windows.Forms.Label lblRSAFormat;
        private System.Windows.Forms.ComboBox cboRSAFormat;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.Button btnImportKey;
        private System.Windows.Forms.Button btnExportKey;
        private System.Windows.Forms.Button btnClearKey;
        private System.Windows.Forms.Label lblRSAInput;
        private System.Windows.Forms.TextBox txtRSAInput;
        private System.Windows.Forms.Label lblRSAOutput;
        private System.Windows.Forms.TextBox txtRSAOutput;
        private System.Windows.Forms.Button btnRSAEncrypt;
        private System.Windows.Forms.Button btnRSADecrypt;
        private System.Windows.Forms.Button btnRSAClear;
        private System.Windows.Forms.Button btnRSACopy;

        private System.Windows.Forms.Label lblStatus;

        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblMenuHint = new Label();
            btnRSA = new Button();
            btnPlayfair = new Button();
            lblAppSubtitle = new Label();
            lblAppTitle = new Label();
            pnlHeader = new Panel();
            lblHeaderDesc = new Label();
            lblCurrentCipher = new Label();
            pnlPlayfair = new Panel();
            lblPFSectionTitle = new Label();
            lblPFKey = new Label();
            txtPFKey = new TextBox();
            lblPFInput = new Label();
            txtPFInput = new TextBox();
            lblPFOutput = new Label();
            txtPFOutput = new TextBox();
            btnPFEncrypt = new Button();
            btnPFDecrypt = new Button();
            btnPFClear = new Button();
            btnPFCopy = new Button();
            lblPFMatrix = new Label();
            txtPFMatrix = new TextBox();
            pnlRSA = new Panel();
            lblRSASectionTitle = new Label();
            lblRSAKeySize = new Label();
            cboRSAKeySize = new ComboBox();
            lblRSAPadding = new Label();
            cboRSAPadding = new ComboBox();
            lblRSAFormat = new Label();
            cboRSAFormat = new ComboBox();
            lblPublicKey = new Label();
            txtPublicKey = new TextBox();
            lblPrivateKey = new Label();
            txtPrivateKey = new TextBox();
            btnGenerateKey = new Button();
            btnImportKey = new Button();
            btnExportKey = new Button();
            btnClearKey = new Button();
            lblRSAInput = new Label();
            txtRSAInput = new TextBox();
            lblRSAOutput = new Label();
            txtRSAOutput = new TextBox();
            btnRSAEncrypt = new Button();
            btnRSADecrypt = new Button();
            btnRSAClear = new Button();
            btnRSACopy = new Button();
            lblStatus = new Label();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlPlayfair.SuspendLayout();
            pnlRSA.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.BorderStyle = BorderStyle.FixedSingle;
            pnlSidebar.Controls.Add(lblMenuHint);
            pnlSidebar.Controls.Add(btnRSA);
            pnlSidebar.Controls.Add(btnPlayfair);
            pnlSidebar.Controls.Add(lblAppSubtitle);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Location = new Point(14, 16);
            pnlSidebar.Margin = new Padding(3, 4, 3, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(285, 915);
            pnlSidebar.TabIndex = 0;
            // 
            // lblMenuHint
            // 
            lblMenuHint.BackColor = Color.WhiteSmoke;
            lblMenuHint.BorderStyle = BorderStyle.FixedSingle;
            lblMenuHint.Font = new Font("Segoe UI", 9F);
            lblMenuHint.ForeColor = Color.DimGray;
            lblMenuHint.Location = new Point(23, 387);
            lblMenuHint.Name = "lblMenuHint";
            lblMenuHint.Size = new Size(234, 98);
            lblMenuHint.TabIndex = 4;
            lblMenuHint.Text = "Gợi ý:\r\n- Chọn thuật toán ở tab trái\r\n- Điền đầy đủ thông tin tương ứng với thuật toán ở tab giữa\r\n";
            lblMenuHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRSA
            // 
            btnRSA.BackColor = Color.White;
            btnRSA.FlatStyle = FlatStyle.Flat;
            btnRSA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRSA.Location = new Point(23, 267);
            btnRSA.Margin = new Padding(3, 4, 3, 4);
            btnRSA.Name = "btnRSA";
            btnRSA.Size = new Size(234, 80);
            btnRSA.TabIndex = 3;
            btnRSA.Text = "RSA Cipher";
            btnRSA.UseVisualStyleBackColor = false;
            // 
            // btnPlayfair
            // 
            btnPlayfair.BackColor = Color.AliceBlue;
            btnPlayfair.FlatStyle = FlatStyle.Flat;
            btnPlayfair.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPlayfair.Location = new Point(23, 167);
            btnPlayfair.Margin = new Padding(3, 4, 3, 4);
            btnPlayfair.Name = "btnPlayfair";
            btnPlayfair.Size = new Size(234, 80);
            btnPlayfair.TabIndex = 2;
            btnPlayfair.Text = "Playfair Cipher";
            btnPlayfair.UseVisualStyleBackColor = false;
            // 
            // lblAppSubtitle
            // 
            lblAppSubtitle.Font = new Font("Segoe UI", 9F);
            lblAppSubtitle.ForeColor = Color.DimGray;
            lblAppSubtitle.Location = new Point(23, 64);
            lblAppSubtitle.Name = "lblAppSubtitle";
            lblAppSubtitle.Size = new Size(234, 56);
            lblAppSubtitle.TabIndex = 1;
            lblAppSubtitle.Text = "Chào mừng bạn quay lại !\r\n";
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.Location = new Point(21, 24);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(173, 37);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Cipher Suite";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblHeaderDesc);
            pnlHeader.Controls.Add(lblCurrentCipher);
            pnlHeader.Location = new Point(313, 16);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1136, 117);
            pnlHeader.TabIndex = 1;
            // 
            // lblHeaderDesc
            // 
            lblHeaderDesc.AutoSize = true;
            lblHeaderDesc.Font = new Font("Segoe UI", 9F);
            lblHeaderDesc.ForeColor = Color.DimGray;
            lblHeaderDesc.Location = new Point(23, 64);
            lblHeaderDesc.Name = "lblHeaderDesc";
            lblHeaderDesc.Size = new Size(0, 20);
            lblHeaderDesc.TabIndex = 1;
            // 
            // lblCurrentCipher
            // 
            lblCurrentCipher.AutoSize = true;
            lblCurrentCipher.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentCipher.Location = new Point(23, 30);
            lblCurrentCipher.Name = "lblCurrentCipher";
            lblCurrentCipher.Size = new Size(172, 31);
            lblCurrentCipher.TabIndex = 0;
            lblCurrentCipher.Text = "Playfair Cipher";
            // 
            // pnlPlayfair
            // 
            pnlPlayfair.BackColor = Color.White;
            pnlPlayfair.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayfair.Controls.Add(lblPFSectionTitle);
            pnlPlayfair.Controls.Add(lblPFKey);
            pnlPlayfair.Controls.Add(txtPFKey);
            pnlPlayfair.Controls.Add(lblPFInput);
            pnlPlayfair.Controls.Add(txtPFInput);
            pnlPlayfair.Controls.Add(lblPFOutput);
            pnlPlayfair.Controls.Add(txtPFOutput);
            pnlPlayfair.Controls.Add(btnPFEncrypt);
            pnlPlayfair.Controls.Add(btnPFDecrypt);
            pnlPlayfair.Controls.Add(btnPFClear);
            pnlPlayfair.Controls.Add(btnPFCopy);
            pnlPlayfair.Controls.Add(lblPFMatrix);
            pnlPlayfair.Controls.Add(txtPFMatrix);
            pnlPlayfair.Location = new Point(313, 149);
            pnlPlayfair.Margin = new Padding(3, 4, 3, 4);
            pnlPlayfair.Name = "pnlPlayfair";
            pnlPlayfair.Size = new Size(1136, 782);
            pnlPlayfair.TabIndex = 2;
            // 
            // lblPFSectionTitle
            // 
            lblPFSectionTitle.AutoSize = true;
            lblPFSectionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPFSectionTitle.Location = new Point(21, 21);
            lblPFSectionTitle.Name = "lblPFSectionTitle";
            lblPFSectionTitle.Size = new Size(183, 28);
            lblPFSectionTitle.TabIndex = 0;
            lblPFSectionTitle.Text = "Thông tin Playfair";
            // 
            // lblPFKey
            // 
            lblPFKey.AutoSize = true;
            lblPFKey.Location = new Point(23, 73);
            lblPFKey.Name = "lblPFKey";
            lblPFKey.Size = new Size(99, 20);
            lblPFKey.TabIndex = 1;
            lblPFKey.Text = "Khóa Playfair:";
            // 
            // txtPFKey
            // 
            txtPFKey.Location = new Point(26, 100);
            txtPFKey.Margin = new Padding(3, 4, 3, 4);
            txtPFKey.Name = "txtPFKey";
            txtPFKey.Size = new Size(297, 27);
            txtPFKey.TabIndex = 2;
            txtPFKey.Text = "Harry Potter";
            // 
            // lblPFInput
            // 
            lblPFInput.AutoSize = true;
            lblPFInput.Location = new Point(23, 165);
            lblPFInput.Name = "lblPFInput";
            lblPFInput.Size = new Size(122, 20);
            lblPFInput.TabIndex = 7;
            lblPFInput.Text = "Văn bản đầu vào:";
            // 
            // txtPFInput
            // 
            txtPFInput.Font = new Font("Consolas", 10F);
            txtPFInput.Location = new Point(26, 193);
            txtPFInput.Margin = new Padding(3, 4, 3, 4);
            txtPFInput.Multiline = true;
            txtPFInput.Name = "txtPFInput";
            txtPFInput.ScrollBars = ScrollBars.Vertical;
            txtPFInput.Size = new Size(508, 496);
            txtPFInput.TabIndex = 8;
            // 
            // lblPFOutput
            // 
            lblPFOutput.AutoSize = true;
            lblPFOutput.Location = new Point(561, 163);
            lblPFOutput.Name = "lblPFOutput";
            lblPFOutput.Size = new Size(63, 20);
            lblPFOutput.TabIndex = 9;
            lblPFOutput.Text = "Kết quả:";
            // 
            // txtPFOutput
            // 
            txtPFOutput.Font = new Font("Consolas", 10F);
            txtPFOutput.Location = new Point(565, 193);
            txtPFOutput.Margin = new Padding(3, 4, 3, 4);
            txtPFOutput.Multiline = true;
            txtPFOutput.Name = "txtPFOutput";
            txtPFOutput.ReadOnly = true;
            txtPFOutput.ScrollBars = ScrollBars.Vertical;
            txtPFOutput.Size = new Size(542, 496);
            txtPFOutput.TabIndex = 10;
            // 
            // btnPFEncrypt
            // 
            btnPFEncrypt.BackColor = Color.DodgerBlue;
            btnPFEncrypt.FlatStyle = FlatStyle.Flat;
            btnPFEncrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPFEncrypt.ForeColor = Color.White;
            btnPFEncrypt.Location = new Point(26, 713);
            btnPFEncrypt.Margin = new Padding(3, 4, 3, 4);
            btnPFEncrypt.Name = "btnPFEncrypt";
            btnPFEncrypt.Size = new Size(137, 48);
            btnPFEncrypt.TabIndex = 11;
            btnPFEncrypt.Text = "Mã hóa";
            btnPFEncrypt.UseVisualStyleBackColor = false;
            // 
            // btnPFDecrypt
            // 
            btnPFDecrypt.FlatStyle = FlatStyle.Flat;
            btnPFDecrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPFDecrypt.Location = new Point(175, 713);
            btnPFDecrypt.Margin = new Padding(3, 4, 3, 4);
            btnPFDecrypt.Name = "btnPFDecrypt";
            btnPFDecrypt.Size = new Size(137, 48);
            btnPFDecrypt.TabIndex = 12;
            btnPFDecrypt.Text = "Giải mã";
            btnPFDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnPFClear
            // 
            btnPFClear.FlatStyle = FlatStyle.Flat;
            btnPFClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPFClear.Location = new Point(323, 713);
            btnPFClear.Margin = new Padding(3, 4, 3, 4);
            btnPFClear.Name = "btnPFClear";
            btnPFClear.Size = new Size(137, 48);
            btnPFClear.TabIndex = 13;
            btnPFClear.Text = "Làm mới";
            btnPFClear.UseVisualStyleBackColor = true;
            // 
            // btnPFCopy
            // 
            btnPFCopy.FlatStyle = FlatStyle.Flat;
            btnPFCopy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPFCopy.Location = new Point(472, 713);
            btnPFCopy.Margin = new Padding(3, 4, 3, 4);
            btnPFCopy.Name = "btnPFCopy";
            btnPFCopy.Size = new Size(137, 48);
            btnPFCopy.TabIndex = 14;
            btnPFCopy.Text = "Sao chép";
            btnPFCopy.UseVisualStyleBackColor = true;
            // 
            // lblPFMatrix
            // 
            lblPFMatrix.AutoSize = true;
            lblPFMatrix.Location = new Point(662, 73);
            lblPFMatrix.Name = "lblPFMatrix";
            lblPFMatrix.Size = new Size(154, 20);
            lblPFMatrix.TabIndex = 15;
            lblPFMatrix.Text = "Ma trận Playfair 5 × 5:";
            // 
            // txtPFMatrix
            // 
            txtPFMatrix.Font = new Font("Consolas", 12F);
            txtPFMatrix.Location = new Point(822, 73);
            txtPFMatrix.Margin = new Padding(3, 4, 3, 4);
            txtPFMatrix.Multiline = true;
            txtPFMatrix.Name = "txtPFMatrix";
            txtPFMatrix.ReadOnly = true;
            txtPFMatrix.Size = new Size(122, 103);
            txtPFMatrix.TabIndex = 16;
            txtPFMatrix.Text = "H A R Y P\r\nO T E B C\r\nD F G I K\r\nL M N Q S\r\nU V W X Z";
            // 
            // pnlRSA
            // 
            pnlRSA.BackColor = Color.White;
            pnlRSA.BorderStyle = BorderStyle.FixedSingle;
            pnlRSA.Controls.Add(lblRSASectionTitle);
            pnlRSA.Controls.Add(lblRSAKeySize);
            pnlRSA.Controls.Add(cboRSAKeySize);
            pnlRSA.Controls.Add(lblRSAPadding);
            pnlRSA.Controls.Add(cboRSAPadding);
            pnlRSA.Controls.Add(lblRSAFormat);
            pnlRSA.Controls.Add(cboRSAFormat);
            pnlRSA.Controls.Add(lblPublicKey);
            pnlRSA.Controls.Add(txtPublicKey);
            pnlRSA.Controls.Add(lblPrivateKey);
            pnlRSA.Controls.Add(txtPrivateKey);
            pnlRSA.Controls.Add(btnGenerateKey);
            pnlRSA.Controls.Add(btnImportKey);
            pnlRSA.Controls.Add(btnExportKey);
            pnlRSA.Controls.Add(btnClearKey);
            pnlRSA.Controls.Add(lblRSAInput);
            pnlRSA.Controls.Add(txtRSAInput);
            pnlRSA.Controls.Add(lblRSAOutput);
            pnlRSA.Controls.Add(txtRSAOutput);
            pnlRSA.Controls.Add(btnRSAEncrypt);
            pnlRSA.Controls.Add(btnRSADecrypt);
            pnlRSA.Controls.Add(btnRSAClear);
            pnlRSA.Controls.Add(btnRSACopy);
            pnlRSA.Location = new Point(313, 149);
            pnlRSA.Margin = new Padding(3, 4, 3, 4);
            pnlRSA.Name = "pnlRSA";
            pnlRSA.Size = new Size(1136, 782);
            pnlRSA.TabIndex = 3;
            pnlRSA.Visible = false;
            pnlRSA.Paint += pnlRSA_Paint;
            // 
            // lblRSASectionTitle
            // 
            lblRSASectionTitle.AutoSize = true;
            lblRSASectionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRSASectionTitle.Location = new Point(21, 21);
            lblRSASectionTitle.Name = "lblRSASectionTitle";
            lblRSASectionTitle.Size = new Size(148, 28);
            lblRSASectionTitle.TabIndex = 0;
            lblRSASectionTitle.Text = "Thông tin RSA";
            // 
            // lblRSAKeySize
            // 
            lblRSAKeySize.AutoSize = true;
            lblRSAKeySize.Location = new Point(23, 73);
            lblRSAKeySize.Name = "lblRSAKeySize";
            lblRSAKeySize.Size = new Size(67, 20);
            lblRSAKeySize.TabIndex = 1;
            lblRSAKeySize.Text = "Key Size:";
            // 
            // cboRSAKeySize
            // 
            cboRSAKeySize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRSAKeySize.FormattingEnabled = true;
            cboRSAKeySize.Items.AddRange(new object[] { "1024 bit", "2048 bit", "3072 bit", "4096 bit" });
            cboRSAKeySize.Location = new Point(26, 100);
            cboRSAKeySize.Margin = new Padding(3, 4, 3, 4);
            cboRSAKeySize.Name = "cboRSAKeySize";
            cboRSAKeySize.Size = new Size(159, 28);
            cboRSAKeySize.TabIndex = 2;
            // 
            // lblRSAPadding
            // 
            lblRSAPadding.AutoSize = true;
            lblRSAPadding.Location = new Point(208, 73);
            lblRSAPadding.Name = "lblRSAPadding";
            lblRSAPadding.Size = new Size(66, 20);
            lblRSAPadding.TabIndex = 3;
            lblRSAPadding.Text = "Padding:";
            // 
            // cboRSAPadding
            // 
            cboRSAPadding.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRSAPadding.FormattingEnabled = true;
            cboRSAPadding.Items.AddRange(new object[] { "PKCS#1 v1.5", "OAEP" });
            cboRSAPadding.Location = new Point(211, 100);
            cboRSAPadding.Margin = new Padding(3, 4, 3, 4);
            cboRSAPadding.Name = "cboRSAPadding";
            cboRSAPadding.Size = new Size(159, 28);
            cboRSAPadding.TabIndex = 4;
            // 
            // lblRSAFormat
            // 
            lblRSAFormat.AutoSize = true;
            lblRSAFormat.Location = new Point(394, 73);
            lblRSAFormat.Name = "lblRSAFormat";
            lblRSAFormat.Size = new Size(59, 20);
            lblRSAFormat.TabIndex = 5;
            lblRSAFormat.Text = "Format:";
            // 
            // cboRSAFormat
            // 
            cboRSAFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRSAFormat.FormattingEnabled = true;
            cboRSAFormat.Items.AddRange(new object[] { "UTF-8 Text", "Base64", "Hex" });
            cboRSAFormat.Location = new Point(398, 100);
            cboRSAFormat.Margin = new Padding(3, 4, 3, 4);
            cboRSAFormat.Name = "cboRSAFormat";
            cboRSAFormat.Size = new Size(159, 28);
            cboRSAFormat.TabIndex = 6;
            // 
            // lblPublicKey
            // 
            lblPublicKey.AutoSize = true;
            lblPublicKey.Location = new Point(23, 163);
            lblPublicKey.Name = "lblPublicKey";
            lblPublicKey.Size = new Size(80, 20);
            lblPublicKey.TabIndex = 7;
            lblPublicKey.Text = "Public Key:";
            // 
            // txtPublicKey
            // 
            txtPublicKey.Font = new Font("Consolas", 9F);
            txtPublicKey.Location = new Point(26, 193);
            txtPublicKey.Margin = new Padding(3, 4, 3, 4);
            txtPublicKey.Multiline = true;
            txtPublicKey.Name = "txtPublicKey";
            txtPublicKey.ScrollBars = ScrollBars.Vertical;
            txtPublicKey.Size = new Size(508, 159);
            txtPublicKey.TabIndex = 8;
            // 
            // lblPrivateKey
            // 
            lblPrivateKey.AutoSize = true;
            lblPrivateKey.Location = new Point(561, 163);
            lblPrivateKey.Name = "lblPrivateKey";
            lblPrivateKey.Size = new Size(85, 20);
            lblPrivateKey.TabIndex = 9;
            lblPrivateKey.Text = "Private Key:";
            // 
            // txtPrivateKey
            // 
            txtPrivateKey.Font = new Font("Consolas", 9F);
            txtPrivateKey.Location = new Point(565, 193);
            txtPrivateKey.Margin = new Padding(3, 4, 3, 4);
            txtPrivateKey.Multiline = true;
            txtPrivateKey.Name = "txtPrivateKey";
            txtPrivateKey.ScrollBars = ScrollBars.Vertical;
            txtPrivateKey.Size = new Size(542, 159);
            txtPrivateKey.TabIndex = 10;
            // 
            // btnGenerateKey
            // 
            btnGenerateKey.BackColor = Color.DodgerBlue;
            btnGenerateKey.FlatStyle = FlatStyle.Flat;
            btnGenerateKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateKey.ForeColor = Color.White;
            btnGenerateKey.Location = new Point(26, 373);
            btnGenerateKey.Margin = new Padding(3, 4, 3, 4);
            btnGenerateKey.Name = "btnGenerateKey";
            btnGenerateKey.Size = new Size(137, 48);
            btnGenerateKey.TabIndex = 11;
            btnGenerateKey.Text = "Tạo khóa";
            btnGenerateKey.UseVisualStyleBackColor = false;
            // 
            // btnImportKey
            // 
            btnImportKey.FlatStyle = FlatStyle.Flat;
            btnImportKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnImportKey.Location = new Point(175, 373);
            btnImportKey.Margin = new Padding(3, 4, 3, 4);
            btnImportKey.Name = "btnImportKey";
            btnImportKey.Size = new Size(137, 48);
            btnImportKey.TabIndex = 12;
            btnImportKey.Text = "Nhập khóa";
            btnImportKey.UseVisualStyleBackColor = true;
            // 
            // btnExportKey
            // 
            btnExportKey.FlatStyle = FlatStyle.Flat;
            btnExportKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportKey.Location = new Point(323, 373);
            btnExportKey.Margin = new Padding(3, 4, 3, 4);
            btnExportKey.Name = "btnExportKey";
            btnExportKey.Size = new Size(137, 48);
            btnExportKey.TabIndex = 13;
            btnExportKey.Text = "Xuất khóa";
            btnExportKey.UseVisualStyleBackColor = true;
            // 
            // btnClearKey
            // 
            btnClearKey.FlatStyle = FlatStyle.Flat;
            btnClearKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearKey.Location = new Point(472, 373);
            btnClearKey.Margin = new Padding(3, 4, 3, 4);
            btnClearKey.Name = "btnClearKey";
            btnClearKey.Size = new Size(137, 48);
            btnClearKey.TabIndex = 14;
            btnClearKey.Text = "Xóa khóa";
            btnClearKey.UseVisualStyleBackColor = true;
            // 
            // lblRSAInput
            // 
            lblRSAInput.AutoSize = true;
            lblRSAInput.Location = new Point(23, 449);
            lblRSAInput.Name = "lblRSAInput";
            lblRSAInput.Size = new Size(122, 20);
            lblRSAInput.TabIndex = 15;
            lblRSAInput.Text = "Văn bản đầu vào:";
            // 
            // txtRSAInput
            // 
            txtRSAInput.Font = new Font("Consolas", 10F);
            txtRSAInput.Location = new Point(26, 480);
            txtRSAInput.Margin = new Padding(3, 4, 3, 4);
            txtRSAInput.Multiline = true;
            txtRSAInput.Name = "txtRSAInput";
            txtRSAInput.ScrollBars = ScrollBars.Vertical;
            txtRSAInput.Size = new Size(508, 185);
            txtRSAInput.TabIndex = 16;
            // 
            // lblRSAOutput
            // 
            lblRSAOutput.AutoSize = true;
            lblRSAOutput.Location = new Point(561, 449);
            lblRSAOutput.Name = "lblRSAOutput";
            lblRSAOutput.Size = new Size(63, 20);
            lblRSAOutput.TabIndex = 17;
            lblRSAOutput.Text = "Kết quả:";
            // 
            // txtRSAOutput
            // 
            txtRSAOutput.Font = new Font("Consolas", 10F);
            txtRSAOutput.Location = new Point(565, 480);
            txtRSAOutput.Margin = new Padding(3, 4, 3, 4);
            txtRSAOutput.Multiline = true;
            txtRSAOutput.Name = "txtRSAOutput";
            txtRSAOutput.ReadOnly = true;
            txtRSAOutput.ScrollBars = ScrollBars.Vertical;
            txtRSAOutput.Size = new Size(542, 185);
            txtRSAOutput.TabIndex = 18;
            // 
            // btnRSAEncrypt
            // 
            btnRSAEncrypt.BackColor = Color.DodgerBlue;
            btnRSAEncrypt.FlatStyle = FlatStyle.Flat;
            btnRSAEncrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRSAEncrypt.ForeColor = Color.White;
            btnRSAEncrypt.Location = new Point(26, 689);
            btnRSAEncrypt.Margin = new Padding(3, 4, 3, 4);
            btnRSAEncrypt.Name = "btnRSAEncrypt";
            btnRSAEncrypt.Size = new Size(137, 48);
            btnRSAEncrypt.TabIndex = 19;
            btnRSAEncrypt.Text = "Mã hóa";
            btnRSAEncrypt.UseVisualStyleBackColor = false;
            // 
            // btnRSADecrypt
            // 
            btnRSADecrypt.FlatStyle = FlatStyle.Flat;
            btnRSADecrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRSADecrypt.Location = new Point(175, 689);
            btnRSADecrypt.Margin = new Padding(3, 4, 3, 4);
            btnRSADecrypt.Name = "btnRSADecrypt";
            btnRSADecrypt.Size = new Size(137, 48);
            btnRSADecrypt.TabIndex = 20;
            btnRSADecrypt.Text = "Giải mã";
            btnRSADecrypt.UseVisualStyleBackColor = true;
            // 
            // btnRSAClear
            // 
            btnRSAClear.FlatStyle = FlatStyle.Flat;
            btnRSAClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRSAClear.Location = new Point(323, 689);
            btnRSAClear.Margin = new Padding(3, 4, 3, 4);
            btnRSAClear.Name = "btnRSAClear";
            btnRSAClear.Size = new Size(137, 48);
            btnRSAClear.TabIndex = 21;
            btnRSAClear.Text = "Làm mới";
            btnRSAClear.UseVisualStyleBackColor = true;
            // 
            // btnRSACopy
            // 
            btnRSACopy.FlatStyle = FlatStyle.Flat;
            btnRSACopy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRSACopy.Location = new Point(472, 689);
            btnRSACopy.Margin = new Padding(3, 4, 3, 4);
            btnRSACopy.Name = "btnRSACopy";
            btnRSACopy.Size = new Size(137, 48);
            btnRSACopy.TabIndex = 22;
            btnRSACopy.Text = "Sao chép";
            btnRSACopy.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.White;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(14, 945);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1435, 46);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Sẵn sàng - Giao diện demo";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1463, 1008);
            Controls.Add(lblStatus);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Controls.Add(pnlRSA);
            Controls.Add(pnlPlayfair);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cipher Suite - Playfair / RSA";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlPlayfair.ResumeLayout(false);
            pnlPlayfair.PerformLayout();
            pnlRSA.ResumeLayout(false);
            pnlRSA.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMenuHint;
        private Label lblHeaderDesc;
    }
}