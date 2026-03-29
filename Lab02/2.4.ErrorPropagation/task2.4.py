from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad

BLOCK_SIZE = 16
DATA_SIZE = 1000

key = b'0123456789abcdef'
iv  = b'abcdef9876543210'

plaintext = b'A' * DATA_SIZE
plaintext_padded = pad(plaintext, BLOCK_SIZE)

def flip_bit(data, byte_index):
    data = bytearray(data)
    data[byte_index] ^= 0x01
    return bytes(data)

def count_corrupted_blocks(p1, p2):
    blocks1 = [p1[i:i+16] for i in range(0, len(p1), 16)]
    blocks2 = [p2[i:i+16] for i in range(0, len(p2), 16)]
    corrupted = 0
    for b1, b2 in zip(blocks1, blocks2):
        if b1 != b2:
            corrupted += 1
    return corrupted

modes = {
    "ECB": AES.MODE_ECB,
    "CBC": AES.MODE_CBC,
    "CFB": AES.MODE_CFB,
    "OFB": AES.MODE_OFB
}

print("=== Error Propagation Test ===\n")

for name, mode in modes.items():
    if mode == AES.MODE_ECB:
        cipher_enc = AES.new(key, mode)
        cipher_dec = AES.new(key, mode)
    else:
        cipher_enc = AES.new(key, mode, iv=iv)
        cipher_dec = AES.new(key, mode, iv=iv)

    ciphertext = cipher_enc.encrypt(plaintext_padded)

    corrupted_ct = flip_bit(ciphertext, 25)

    decrypted_padded = cipher_dec.decrypt(corrupted_ct)

    try:
        decrypted = unpad(decrypted_padded, BLOCK_SIZE)
    except ValueError:
        decrypted = decrypted_padded  # CFB/OFB có thể không unpad được

    corrupted_blocks = count_corrupted_blocks(plaintext, decrypted)

    print(f"Mode: {name}")
    print(f"  Corrupted blocks: {corrupted_blocks}/63\n")