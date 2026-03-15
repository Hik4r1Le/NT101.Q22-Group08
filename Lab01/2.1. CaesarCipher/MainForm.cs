using System;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CaesarCipher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // Gán nút sự kiện
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = MaHoa(txtInput.Text, (int)numKey.Value);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = GiaiMa(txtInput.Text, (int)numKey.Value);
        }

        private void btnBruteForce_Click(object sender, EventArgs e)
        {
            string cipherText = txtInput.Text;

            int bestKey = 0;
            int bestScore = -1;
            string bestText = "";

            for (int key = 0; key < 26; key++)
            {
                string Text = GiaiMa(cipherText, key);
                int score = ChamDiem(Text);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestKey = key;
                    bestText = Text;
                }
            }

            txtOutput.Text = bestText;
            lblStatus.Text = $"Khóa phù hợp nhất = {bestKey}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
            numKey.Value = 0;
        }

        // Mã hóa và giải mã

        private string MaHoa(string text, int key)
        {
            return ShiftText(text, key);
        }

        private string GiaiMa(string text, int key)
        {
            return ShiftText(text, -key);
        }

        private string ShiftText(string text, int shift)
        {
            char ShiftChar(char c)
            {
                if (char.IsUpper(c))
                    return (char)('A' + ((c - 'A' + shift + 26) % 26));
                else if (char.IsLower(c))
                    return (char)('a' + ((c - 'a' + shift + 26) % 26));
                else
                    return c;
            }

            return new string(text.Select(ShiftChar).ToArray());
        }

        private int ChamDiem(string text)
        {
            string lower = text.ToLower();
            string[] words = { "the", "and", "of", "to", "in", "is", "technology", "research" };

            int score = 0;

            foreach (var w in words)
                if (lower.Contains(w)) score += 5;

            return score;
        }
    }
}