using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PlayfairCipher
{
    public enum RSAKeySize
    {
        Bits1024 = 1024,
        Bits2048 = 2048,
        Bits3072 = 3072,
        Bits4096 = 4096
    }

    public enum RSAPaddingMode
    {
        PKCS1,     // "PKCS#1 v1.5"
        OAEP_SHA1  // "OAEP"  (SHA-1 is the standard OAEP default)
    }

    public enum RSAKeyFormat
    {
        Utf8,   // "UTF-8 Text"  – only valid for decrypted plaintext output
        Base64, // "Base64"
        Hex     // "Hex"
    }


    public class RSACipherEngine : IDisposable
    {
        private RSA _rsa;

        public RSAKeySize KeySize { get; private set; } = RSAKeySize.Bits2048;
        public RSAPaddingMode Padding { get; private set; } = RSAPaddingMode.OAEP_SHA1;
        public RSAKeyFormat Format { get; private set; } = RSAKeyFormat.Base64;

        public RSACipherEngine()
        {
            _rsa = RSA.Create();
        }

        public void SetKeySize(RSAKeySize size) { KeySize = size; }
        public void SetPadding(RSAPaddingMode pad) { Padding = pad; }
        public void SetFormat(RSAKeyFormat fmt) { Format = fmt; }


        public void TaoKhoa()
        {
            _rsa?.Dispose();
            _rsa = RSA.Create((int)KeySize);
        }

        public string GetPublicKey()
        {
            EnsureKey();
            byte[] der = _rsa.ExportSubjectPublicKeyInfo();
            return WrapPem(Convert.ToBase64String(der), "PUBLIC KEY");
        }

        public string GetPrivateKey()
        {
            EnsureKey();
            EnsurePrivate();
            byte[] der = _rsa.ExportPkcs8PrivateKey();
            return WrapPem(Convert.ToBase64String(der), "PRIVATE KEY");
        }


        public void NhapKhoaPublic(string keyText)
        {
            if (string.IsNullOrWhiteSpace(keyText))
                throw new ArgumentException("Khóa công khai không được để trống.");

            byte[] der = DecodePemOrRaw(keyText);
            _rsa ??= RSA.Create();
            _rsa.ImportSubjectPublicKeyInfo(der, out _);
        }

        public void NhapKhoaPrivate(string keyText)
        {
            if (string.IsNullOrWhiteSpace(keyText))
                throw new ArgumentException("Khóa bí mật không được để trống.");

            byte[] der = DecodePemOrRaw(keyText);
            _rsa ??= RSA.Create();
            _rsa.ImportPkcs8PrivateKey(der, out _);
        }


        public void XuatKhoaPublic(string filePath)
            => File.WriteAllText(filePath, GetPublicKey(), Encoding.UTF8);

        public void XuatKhoaPrivate(string filePath)
            => File.WriteAllText(filePath, GetPrivateKey(), Encoding.UTF8);


        public void XoaKhoa()
        {
            _rsa?.Dispose();
            _rsa = RSA.Create();
        }

        public string MaHoa(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                throw new ArgumentException("Văn bản đầu vào không được để trống.");

            EnsureKey();

            byte[] data = Encoding.UTF8.GetBytes(plaintext);
            byte[] encrypted = _rsa.Encrypt(data, GetPadding());

            return Format switch
            {
                RSAKeyFormat.Hex => BytesToHex(encrypted),
                _ => Convert.ToBase64String(encrypted)  // Base64 & Utf8
            };
        }

        public string GiaiMa(string ciphertext)
        {
            if (string.IsNullOrEmpty(ciphertext))
                throw new ArgumentException("Văn bản đầu vào không được để trống.");

            EnsureKey();
            EnsurePrivate();

            byte[] data = IsHex(ciphertext.Trim())
                ? HexToBytes(ciphertext.Trim())
                : Convert.FromBase64String(ciphertext.Trim());

            byte[] decrypted = _rsa.Decrypt(data, GetPadding());
            return Encoding.UTF8.GetString(decrypted);
        }

        private RSAEncryptionPadding GetPadding() => Padding switch
        {
            RSAPaddingMode.PKCS1 => RSAEncryptionPadding.Pkcs1,
            _ => RSAEncryptionPadding.OaepSHA1
        };

        private static string WrapPem(string base64, string label)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-----BEGIN {label}-----");
            for (int i = 0; i < base64.Length; i += 64)
                sb.AppendLine(base64.Substring(i, Math.Min(64, base64.Length - i)));
            sb.Append($"-----END {label}-----");
            return sb.ToString();
        }

        private static byte[] DecodePemOrRaw(string text)
        {
            text = text.Trim();

            if (text.StartsWith("-----"))           // PEM
                return Convert.FromBase64String(StripPemHeaders(text));

            if (IsHex(text))                        // Hex DER
                return HexToBytes(text);

            return Convert.FromBase64String(text);  // Base64 DER
        }

        private static string StripPemHeaders(string pem)
        {
            var sb = new StringBuilder();
            foreach (var line in pem.Split('\n'))
            {
                string l = line.Trim();
                if (!l.StartsWith("-----"))
                    sb.Append(l);
            }
            return sb.ToString();
        }

        private static bool IsHex(string s)
        {
            foreach (char c in s)
                if (!Uri.IsHexDigit(c) && c != ' ' && c != '-')
                    return false;
            return s.Length > 0;
        }

        private static byte[] HexToBytes(string hex)
        {
            hex = hex.Replace(" ", "").Replace("-", "");
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return bytes;
        }

        private static string BytesToHex(byte[] data)
            => BitConverter.ToString(data).Replace("-", "").ToLowerInvariant();

        private void EnsureKey()
        {
            if (_rsa == null)
                throw new InvalidOperationException("Chưa có khóa. Hãy tạo hoặc nhập khóa trước.");
        }

        private void EnsurePrivate()
        {
            try { _rsa.ExportPkcs8PrivateKey(); }
            catch { throw new InvalidOperationException("Chưa có khóa bí mật. Hãy tạo hoặc nhập khóa bí mật."); }
        }

        public void Dispose()
        {
            _rsa?.Dispose();
            _rsa = null;
        }
    }
}