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

        public MainForm()
        {
            InitializeComponent();

            btnPFEncrypt.Click += btnEncrypt_Click;
            btnPFDecrypt.Click += btnDecrypt_Click;
            btnPFClear.Click += btnClear_Click;

            btnPlayfair.Click += btnPlayfair_Click;
            btnRSA.Click += btnRSA_Click;



            ShowPlayfairUI();
        }


        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                PlayfairCipherEngine engine = new PlayfairCipherEngine(txtKey.Text);

                txtMatrix.Text = engine.GetMatrixAsText();
                txtOutput.Text = engine.MaHoa(txtInput.Text);
                lblStatus.Text = "Đã mã hóa thành công.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                PlayfairCipherEngine engine = new PlayfairCipherEngine(txtKey.Text);

                txtMatrix.Text = engine.GetMatrixAsText();
                txtOutput.Text = engine.GiaiMa(txtInput.Text);
                lblStatus.Text = "Đã giải mã thành công.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKey.Clear();
            txtInput.Clear();
            txtOutput.Clear();
            txtMatrix.Clear();

            lblStatus.Text = "Đã xóa dữ liệu.";
        }


        private void btnPlayfair_Click(object sender, EventArgs e)
        {
            ShowPlayfairUI();
        }

        private void btnRSA_Click(object sender, EventArgs e)
        {
            ShowRSAUI();
        }

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

        private void pnlRSA_Paint(object sender, PaintEventArgs e)
        {

        }
    }


    public class PlayfairCipherEngine
    {
        public char[,] Matrix { get; private set; } = new char[5, 5];
        private readonly Dictionary<char, (int Row, int Col)> positions = new();

        public PlayfairCipherEngine(string key)
        {
            BuildMatrix(key);
        }

        // Tạo ma trận Playfair
        private void BuildMatrix(string key)
        {
            string normalizedKey = NormalizeText(key);

            StringBuilder sb = new StringBuilder();
            HashSet<char> used = new HashSet<char>();

            // Thêm ký tự từ khóa trước
            foreach (char c in normalizedKey)
            {
                if (!used.Contains(c))
                {
                    used.Add(c);
                    sb.Append(c);
                }
            }

            // Thêm alphabet còn lại, bỏ J
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c == 'J') continue;

                if (!used.Contains(c))
                {
                    used.Add(c);
                    sb.Append(c);
                }
            }

            string full = sb.ToString();

            int index = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    Matrix[r, c] = full[index];
                    positions[full[index]] = (r, c);
                    index++;
                }
            }
        }

        // Chuẩn hóa chuỗi
        private string NormalizeText(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    sb.Append(c == 'J' ? 'I' : c);
                }
            }

            return sb.ToString();
        }

        private List<string> PreparePlainPairs(string plaintext)
        {
            string text = NormalizeText(plaintext);
            List<string> pairs = new List<string>();

            int i = 0;
            while (i < text.Length)
            {
                char first = text[i];
                char second;

                if (i + 1 >= text.Length)
                {
                    second = 'X';
                    pairs.Add($"{first}{second}");
                    i++;
                }
                else
                {
                    second = text[i + 1];

                    if (first == second)
                    {
                        pairs.Add($"{first}X");
                        i++;
                    }
                    else
                    {
                        pairs.Add($"{first}{second}");
                        i += 2;
                    }
                }
            }

            return pairs;
        }

        private List<string> PrepareCipherPairs(string ciphertext)
        {
            string text = NormalizeText(ciphertext);

            if (text.Length % 2 != 0)
                throw new ArgumentException("Ciphertext phải có số lượng ký tự chẵn.");

            List<string> pairs = new List<string>();

            for (int i = 0; i < text.Length; i += 2)
            {
                pairs.Add(text.Substring(i, 2));
            }

            return pairs;
        }

        // Mã Hóa
        public string MaHoa(string plaintext)
        {
            List<string> pairs = PreparePlainPairs(plaintext);
            return TransformPairs(pairs, true);
        }

        // Giải Mã
        public string GiaiMa(string ciphertext)
        {
            List<string> pairs = PrepareCipherPairs(ciphertext);
            return TransformPairs(pairs, false);
        }

        // Playfair Cipher
        private string TransformPairs(List<string> pairs, bool encrypt)
        {
            StringBuilder result = new StringBuilder();

            foreach (string pair in pairs)
            {
                char a = pair[0];
                char b = pair[1];

                var posA = positions[a];
                var posB = positions[b];

                // Cùng hàng
                if (posA.Row == posB.Row)
                {
                    if (encrypt)
                    {
                        result.Append(Matrix[posA.Row, (posA.Col + 1) % 5]);
                        result.Append(Matrix[posB.Row, (posB.Col + 1) % 5]);
                    }
                    else
                    {
                        result.Append(Matrix[posA.Row, (posA.Col + 4) % 5]);
                        result.Append(Matrix[posB.Row, (posB.Col + 4) % 5]);
                    }
                }
                // Cùng cột
                else if (posA.Col == posB.Col)
                {
                    if (encrypt)
                    {
                        result.Append(Matrix[(posA.Row + 1) % 5, posA.Col]);
                        result.Append(Matrix[(posB.Row + 1) % 5, posB.Col]);
                    }
                    else
                    {
                        result.Append(Matrix[(posA.Row + 4) % 5, posA.Col]);
                        result.Append(Matrix[(posB.Row + 4) % 5, posB.Col]);
                    }
                }
                // Khác hàng khác cột
                else
                {
                    result.Append(Matrix[posA.Row, posB.Col]);
                    result.Append(Matrix[posB.Row, posA.Col]);
                }
            }

            return result.ToString();
        }

        //  5x5
        public string GetMatrixAsText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(Matrix[i, j]);
                    if (j < 4) sb.Append(" ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}