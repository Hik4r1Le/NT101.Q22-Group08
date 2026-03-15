using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_2_5_Official
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            string key = textBox1.Text;
            richTextBox2.Text = Encrypt(input, key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            string key = textBox1.Text;
            richTextBox2.Text = Decrypt(input, key);
        }
        //Encryption
        private string Encrypt(string text, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return "Vui lòng nhập Key";
            if (string.IsNullOrWhiteSpace(text)) return "Vui lòng nhập văn bản";

            text = text.ToUpper();
            key = key.ToUpper();

            string validKey = "";
            foreach (char c in key)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validKey += c;
                }
                else
                {
                    return "Cảnh báo: Key không hợp lệ! Vui lòng chỉ nhập các chữ cái Alphabet";
                }
            }

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    int p = c - 'A';
                    int k = validKey[keyIndex % validKey.Length] - 'A';

                    int outputCharValue = (p + k) % 26;

                    result.Append((char)(outputCharValue + 'A'));
                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        // Decryption
        private string Decrypt(string text, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return "Vui lòng nhập Key!";
            if (string.IsNullOrWhiteSpace(text)) return "Vui lòng nhập văn bản!";

            text = text.ToUpper();
            key = key.ToUpper();

            string validKey = "";
            foreach (char c in key)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validKey += c;
                }
                else
                {
                    return "Cảnh báo: Key không hợp lệ! Vui lòng chỉ nhập các chữ cái Alphabet";
                }
            }
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    int p = c - 'A';
                    int k = validKey[keyIndex % validKey.Length] - 'A';

                    int outputCharValue = (p - k + 26) % 26;

                    result.Append((char)(outputCharValue + 'A'));
                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
