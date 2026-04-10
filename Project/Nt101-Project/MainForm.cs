using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PlayfairCipher
{
    public partial class MainForm : Form
    {
        private TextBox txtKey => txtPFKey;
        private TextBox txtInput => txtPFInput;
        private TextBox txtOutput => txtPFOutput;
        private TextBox txtMatrix => txtPFMatrix;

        private RSACipherEngine _rsaEngine = new RSACipherEngine();

        public MainForm()
        {
            InitializeComponent();

            btnPFEncrypt.Click += btnEncrypt_Click;
            btnPFDecrypt.Click += btnDecrypt_Click;
            btnPFClear.Click += btnClear_Click;
            btnPFCopy.Click += btnPFCopy_Click;

            btnPlayfair.Click += btnPlayfair_Click;
            btnRSA.Click += btnRSA_Click;

            InitRSAPanel();
            ShowPlayfairUI();
        }

        private void InitRSAPanel()
        {
            cboRSAKeySize.SelectedIndex = 1;
            cboRSAPadding.SelectedIndex = 1;
            cboRSAFormat.SelectedIndex = 1;

            btnGenerateKey.Click += btnGenerateKey_Click;
            btnImportKey.Click += btnImportKey_Click;
            btnExportKey.Click += btnExportKey_Click;
            btnClearKey.Click += btnClearKey_Click;
            btnRSAEncrypt.Click += btnRSAEncrypt_Click;
            btnRSADecrypt.Click += btnRSADecrypt_Click;
            btnRSAClear.Click += btnRSAClear_Click;
            btnRSACopy.Click += btnRSACopy_Click;

            cboRSAKeySize.SelectedIndexChanged += (s, e) =>
                _rsaEngine.SetKeySize(cboRSAKeySize.SelectedIndex switch
                {
                    0 => RSAKeySize.Bits1024,
                    2 => RSAKeySize.Bits3072,
                    3 => RSAKeySize.Bits4096,
                    _ => RSAKeySize.Bits2048
                });

            cboRSAPadding.SelectedIndexChanged += (s, e) =>
                _rsaEngine.SetPadding(cboRSAPadding.SelectedIndex == 0
                    ? RSAPaddingMode.PKCS1
                    : RSAPaddingMode.OAEP_SHA1);

            cboRSAFormat.SelectedIndexChanged += (s, e) =>
                _rsaEngine.SetFormat(cboRSAFormat.SelectedIndex switch
                {
                    0 => RSAKeyFormat.Utf8,
                    2 => RSAKeyFormat.Hex,
                    _ => RSAKeyFormat.Base64
                });
        }

        // ── Playfair ──────────────────────────────────────────────────────────

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var engine = new PlayfairCipherEngine(txtKey.Text);
                txtMatrix.Text = engine.GetMatrixAsText();
                txtOutput.Text = engine.MaHoa(txtInput.Text);
                lblStatus.Text = "Đã mã hóa thành công.";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var engine = new PlayfairCipherEngine(txtKey.Text);
                txtMatrix.Text = engine.GetMatrixAsText();
                txtOutput.Text = engine.GiaiMa(txtInput.Text);
                lblStatus.Text = "Đã giải mã thành công.";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKey.Clear();
            txtInput.Clear();
            txtOutput.Clear();
            txtMatrix.Clear();
            lblStatus.Text = "Đã xóa dữ liệu.";
        }

        private void btnPFCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOutput.Text))
            {
                Clipboard.SetText(txtOutput.Text);
                lblStatus.Text = "Đã sao chép kết quả.";
            }
        }

        // ── RSA ───────────────────────────────────────────────────────────────

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Đang tạo khóa…";
                Cursor = Cursors.WaitCursor;
                _rsaEngine.TaoKhoa();
                txtPublicKey.Text = _rsaEngine.GetPublicKey();
                txtPrivateKey.Text = _rsaEngine.GetPrivateKey();
                lblStatus.Text = "Đã tạo khóa thành công.";
            }
            catch (Exception ex) { ShowError(ex); }
            finally { Cursor = Cursors.Default; }
        }

        private void btnImportKey_Click(object sender, EventArgs e)
        {
            try
            {
                bool imported = false;
                if (!string.IsNullOrWhiteSpace(txtPublicKey.Text)) { _rsaEngine.NhapKhoaPublic(txtPublicKey.Text); imported = true; }
                if (!string.IsNullOrWhiteSpace(txtPrivateKey.Text)) { _rsaEngine.NhapKhoaPrivate(txtPrivateKey.Text); imported = true; }
                lblStatus.Text = imported ? "Đã nhập khóa thành công." : "Không có khóa nào để nhập.";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnExportKey_Click(object sender, EventArgs e)
        {
            try
            {
                using var dlgPub = new SaveFileDialog { Title = "Lưu khóa công khai", FileName = "public_key.pem", Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*" };
                if (dlgPub.ShowDialog() == DialogResult.OK) _rsaEngine.XuatKhoaPublic(dlgPub.FileName);

                using var dlgPriv = new SaveFileDialog { Title = "Lưu khóa bí mật", FileName = "private_key.pem", Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*" };
                if (dlgPriv.ShowDialog() == DialogResult.OK) _rsaEngine.XuatKhoaPrivate(dlgPriv.FileName);

                lblStatus.Text = "Đã xuất khóa thành công.";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnClearKey_Click(object sender, EventArgs e)
        {
            _rsaEngine.XoaKhoa();
            txtPublicKey.Clear();
            txtPrivateKey.Clear();
            lblStatus.Text = "Đã xóa khóa.";
        }

        private void btnRSAEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtRSAOutput.Text = _rsaEngine.MaHoa(txtRSAInput.Text);
                lblStatus.Text = "Đã mã hóa thành công.";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnRSADecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtRSAOutput.Text = _rsaEngine.GiaiMa(txtRSAInput.Text);
                lblStatus.Text = "Đã giải mã thành công.";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnRSAClear_Click(object sender, EventArgs e)
        {
            txtRSAInput.Clear();
            txtRSAOutput.Clear();
            lblStatus.Text = "Đã làm mới.";
        }

        private void btnRSACopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRSAOutput.Text))
            {
                Clipboard.SetText(txtRSAOutput.Text);
                lblStatus.Text = "Đã sao chép kết quả.";
            }
        }

        // ── Navigation ────────────────────────────────────────────────────────

        private void btnPlayfair_Click(object sender, EventArgs e) => ShowPlayfairUI();
        private void btnRSA_Click(object sender, EventArgs e) => ShowRSAUI();

        private void ShowPlayfairUI()
        {
            pnlPlayfair.Visible = true;
            pnlRSA.Visible = false;
            lblCurrentCipher.Text = "Playfair Cipher";
            lblHeaderDesc.Text = "Giao diện Playfair Cipher.";
            btnPlayfair.BackColor = System.Drawing.Color.AliceBlue;
            btnRSA.BackColor = System.Drawing.Color.White;
            lblStatus.Text = "Đã chuyển sang Playfair Cipher.";
        }

        private void ShowRSAUI()
        {
            pnlPlayfair.Visible = false;
            pnlRSA.Visible = true;
            lblCurrentCipher.Text = "RSA Cipher";
            lblHeaderDesc.Text = "Giao diện RSA Cipher.";
            btnPlayfair.BackColor = System.Drawing.Color.White;
            btnRSA.BackColor = System.Drawing.Color.AliceBlue;
            lblStatus.Text = "Đã chuyển sang RSA Cipher.";
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Lỗi: " + ex.Message;
        }

        private void pnlRSA_Paint(object sender, PaintEventArgs e) { }
    }


    public class PlayfairCipherEngine
    {
        public char[,] Matrix { get; private set; } = new char[5, 5];
        private readonly Dictionary<char, (int Row, int Col)> positions = new();

        public PlayfairCipherEngine(string key) => BuildMatrix(key);

        private void BuildMatrix(string key)
        {
            string normalizedKey = NormalizeText(key);
            var sb = new StringBuilder();
            var used = new HashSet<char>();

            foreach (char c in normalizedKey)
                if (used.Add(c)) sb.Append(c);

            for (char c = 'A'; c <= 'Z'; c++)
                if (c != 'J' && used.Add(c)) sb.Append(c);

            string full = sb.ToString();
            int index = 0;
            for (int r = 0; r < 5; r++)
                for (int c = 0; c < 5; c++)
                {
                    Matrix[r, c] = full[index];
                    positions[full[index]] = (r, c);
                    index++;
                }
        }

        private string NormalizeText(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text.ToUpper())
                if (char.IsLetter(c)) sb.Append(c == 'J' ? 'I' : c);
            return sb.ToString();
        }

        private List<string> PreparePlainPairs(string plaintext)
        {
            string text = NormalizeText(plaintext);
            var pairs = new List<string>();
            int i = 0;
            while (i < text.Length)
            {
                char first = text[i];
                if (i + 1 >= text.Length) { pairs.Add($"{first}X"); i++; }
                else if (text[i + 1] == first) { pairs.Add($"{first}X"); i++; }
                else { pairs.Add($"{first}{text[i + 1]}"); i += 2; }
            }
            return pairs;
        }

        private List<string> PrepareCipherPairs(string ciphertext)
        {
            string text = NormalizeText(ciphertext);
            if (text.Length % 2 != 0)
                throw new ArgumentException("Ciphertext phải có số lượng ký tự chẵn.");
            var pairs = new List<string>();
            for (int i = 0; i < text.Length; i += 2)
                pairs.Add(text.Substring(i, 2));
            return pairs;
        }

        public string MaHoa(string plaintext) => TransformPairs(PreparePlainPairs(plaintext), true);
        public string GiaiMa(string ciphertext) => TransformPairs(PrepareCipherPairs(ciphertext), false);

        private string TransformPairs(List<string> pairs, bool encrypt)
        {
            var result = new StringBuilder();
            int dir = encrypt ? 1 : 4;

            foreach (string pair in pairs)
            {
                var posA = positions[pair[0]];
                var posB = positions[pair[1]];

                if (posA.Row == posB.Row)
                {
                    result.Append(Matrix[posA.Row, (posA.Col + dir) % 5]);
                    result.Append(Matrix[posB.Row, (posB.Col + dir) % 5]);
                }
                else if (posA.Col == posB.Col)
                {
                    result.Append(Matrix[(posA.Row + dir) % 5, posA.Col]);
                    result.Append(Matrix[(posB.Row + dir) % 5, posB.Col]);
                }
                else
                {
                    result.Append(Matrix[posA.Row, posB.Col]);
                    result.Append(Matrix[posB.Row, posA.Col]);
                }
            }
            return result.ToString();
        }

        public string GetMatrixAsText()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(Matrix[i, j]);
                    if (j < 4) sb.Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}