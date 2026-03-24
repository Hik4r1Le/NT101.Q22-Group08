from Crypto.Cipher import AES


key = b'1234567890123456'
plaintext = b"UIT_LAB_UIT_LAB_UIT_LAB_UIT_LAB_" 

def print_blocks(hex_str):
    print(f"  Khối 1: {hex_str[:32]}")
    print(f"  Khối 2: {hex_str[32:]}")

# 1. AES-ECB
cipher_ecb = AES.new(key, AES.MODE_ECB)
ct_ecb = cipher_ecb.encrypt(plaintext)
print("--- AES-ECB ---")
print_blocks(ct_ecb.hex())

# 2. AES-CBC
iv = b'0000000000000000' 
cipher_cbc = AES.new(key, AES.MODE_CBC, iv)
ct_cbc = cipher_cbc.encrypt(plaintext)
print("\n--- AES-CBC ---")
print_blocks(ct_cbc.hex())

# ==========================================
# 3. THỬ NGHIỆM CÁC MODE OF OPERATION KHÁC
# ==========================================

# AES-CFB (Cipher Feedback)
cipher_cfb = AES.new(key, AES.MODE_CFB, iv=iv)
ct_cfb = cipher_cfb.encrypt(plaintext)
print("\n--- AES-CFB ---")
print_blocks(ct_cfb.hex())

# AES-OFB (Output Feedback)
cipher_ofb = AES.new(key, AES.MODE_OFB, iv=iv)
ct_ofb = cipher_ofb.encrypt(plaintext)
print("\n--- AES-OFB ---")
print_blocks(ct_ofb.hex())

# AES-CTR (Counter)
nonce = b'12345678'
cipher_ctr = AES.new(key, AES.MODE_CTR, nonce=nonce)
ct_ctr = cipher_ctr.encrypt(plaintext)
print("\n--- AES-CTR ---")
print_blocks(ct_ctr.hex())