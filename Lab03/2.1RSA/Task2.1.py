import base64
import math
import secrets

# =========================
# 1) Number theory helpers
# =========================

def egcd(a, b):
    if b == 0:
        return a, 1, 0
    g, x1, y1 = egcd(b, a % b)
    return g, y1, x1 - (a // b) * y1

def modinv(a, m):
    g, x, _ = egcd(a, m)
    if g != 1:
        raise ValueError("e không có nghịch đảo modulo phi(n)")
    return x % m

def is_probable_prime(n, rounds=20):
    """Miller-Rabin primality test"""
    if n < 2:
        return False

    small_primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29]
    for p in small_primes:
        if n % p == 0:
            return n == p

    d = n - 1
    s = 0
    while d % 2 == 0:
        d //= 2
        s += 1

    for _ in range(rounds):
        a = secrets.randbelow(n - 3) + 2
        x = pow(a, d, n)
        if x == 1 or x == n - 1:
            continue
        composite = True
        for _ in range(s - 1):
            x = pow(x, 2, n)
            if x == n - 1:
                composite = False
                break
        if composite:
            return False
    return True

def gen_prime(bits=128):
    while True:
        x = secrets.randbits(bits)
        x |= (1 << (bits - 1)) | 1
        if is_probable_prime(x):
            return x

# =========================
# 2) RSA key generation
# =========================

def rsa_from_pqe(p, q, e):
    n = p * q
    phi = (p - 1) * (q - 1)
    if math.gcd(e, phi) != 1:
        raise ValueError("e không nguyên tố cùng nhau với phi(n)")
    d = modinv(e, phi)
    return {
        "p": p,
        "q": q,
        "n": n,
        "phi": phi,
        "e": e,
        "d": d,
        "PU": (e, n),
        "PR": (d, n)
    }

def rsa_generate(bits=256, e=None):
    """
    Sinh khóa ngẫu nhiên khi không có sẵn p, q, e.
    """
    half = bits // 2
    while True:
        p = gen_prime(half)
        q = gen_prime(half)
        if p == q:
            continue

        phi = (p - 1) * (q - 1)

        if e is None:
            e_use = 65537
            if math.gcd(e_use, phi) != 1:
                e_use = 3
                while e_use < phi and math.gcd(e_use, phi) != 1:
                    e_use += 2
        else:
            e_use = e
            if math.gcd(e_use, phi) != 1:
                continue

        n = p * q
        d = modinv(e_use, phi)
        return {
            "p": p,
            "q": q,
            "n": n,
            "phi": phi,
            "e": e_use,
            "d": d,
            "PU": (e_use, n),
            "PR": (d, n)
        }

# =========================
# 3) Character mapping
# =========================

ENCODE_MAP = {}

for i, ch in enumerate("abcdefghijklmnopqrstuvwxyz"):
    ENCODE_MAP[ch] = f"{i:02d}"

for i, ch in enumerate("ABCDEFGHIJKLMNOPQRSTUVWXYZ", start=26):
    ENCODE_MAP[ch] = f"{i:02d}"

for i, ch in enumerate("0123456789", start=52):
    ENCODE_MAP[ch] = f"{i:02d}"

ENCODE_MAP[" "] = "62"
ENCODE_MAP["."] = "63"
ENCODE_MAP[","] = "64"
ENCODE_MAP[":"] = "65"
ENCODE_MAP["?"] = "66"

DECODE_MAP = {v: k for k, v in ENCODE_MAP.items()}

def text_to_decimal_string(text):
    try:
        return "".join(ENCODE_MAP[ch] for ch in text)
    except KeyError as e:
        raise ValueError(f"Ký tự không hỗ trợ trong bảng mã: {e.args[0]}")

def decimal_string_to_text(dec_str):
    if len(dec_str) % 2 != 0:
        raise ValueError("Chuỗi số phải có độ dài chẵn")
    out = []
    for i in range(0, len(dec_str), 2):
        code = dec_str[i:i+2]
        if code not in DECODE_MAP:
            raise ValueError(f"Mã ký tự không hợp lệ: {code}")
        out.append(DECODE_MAP[code])
    return "".join(out)

# =========================
# 4) Block sizing
# =========================

def plaintext_block_digits(n):
    L = len(str(n))
    w = L - 1
    if w % 2 == 1:
        w -= 1
    return w

def ciphertext_block_bytes(n):
    return (n.bit_length() + 7) // 8

# =========================
# 5) RSA for integers
# =========================

def rsa_encrypt_int(m, pubkey):
    e, n = pubkey
    if not (0 <= m < n):
        raise ValueError("Thông điệp số phải thỏa 0 <= M < n")
    return pow(m, e, n)

def rsa_decrypt_int(c, privkey):
    d, n = privkey
    return pow(c, d, n)

def rsa_sign_int(m, privkey):
    d, n = privkey
    if not (0 <= m < n):
        raise ValueError("Thông điệp số phải thỏa 0 <= M < n")
    return pow(m, d, n)

def rsa_verify_int(sig, pubkey):
    e, n = pubkey
    return pow(sig, e, n)

# =========================
# 6) RSA for text 
# =========================

def rsa_encrypt_text(text, pubkey):
    e, n = pubkey
    dec_str = text_to_decimal_string(text)
    w = plaintext_block_digits(n)
    c_block_bytes = ciphertext_block_bytes(n)
    blocks = [dec_str[i:i+w] for i in range(0, len(dec_str), w)]
    block_lengths = [len(b) for b in blocks]
    raw = bytearray()
    for b in blocks:
        m = int(b)
        c = pow(m, e, n)
        raw.extend(c.to_bytes(c_block_bytes, "big"))
    cipher_b64 = base64.b64encode(bytes(raw)).decode("ascii")
    return cipher_b64, block_lengths

def rsa_decrypt_text(cipher_b64, privkey, block_lengths):
    d, n = privkey
    raw = base64.b64decode(cipher_b64)

    c_block_bytes = ciphertext_block_bytes(n)
    if len(raw) != len(block_lengths) * c_block_bytes:
        raise ValueError("Ciphertext không khớp số block đã cung cấp")

    recovered_dec = []
    idx = 0

    for block_len in block_lengths:
        c = int.from_bytes(raw[idx:idx+c_block_bytes], "big")
        idx += c_block_bytes

        m = pow(c, d, n)
        # pad lại đúng số chữ số ban đầu của block
        recovered_dec.append(str(m).zfill(block_len))

    full_dec = "".join(recovered_dec)
    return decimal_string_to_text(full_dec)

# =========================
# 7) Demo theo đề bài
# =========================

def main():
    key1 = rsa_from_pqe(11, 17, 7)
    key2 = rsa_from_pqe(
        20079993872842322116151219,
        676717145751736242170789,
        17
    )
    key3 = rsa_from_pqe(
        int("F7E75FDC469067FFDC4E847C51F452DF", 16),
        int("E85CED54AF57E53E092113E62F436F4F", 16),
        int("0D88C3", 16)
    )

    print("=== TASK 1: Keys ===")
    for i, key in enumerate([key1, key2, key3], start=1):
        print(f"Key {i}:")
        print("  PU =", key["PU"])
        print("  PR =", key["PR"])
        print()

    # Task 2
    print("=== TASK 2: M = 5 ===")
    M = 5
    C_conf = rsa_encrypt_int(M, key1["PU"])
    M_conf = rsa_decrypt_int(C_conf, key1["PR"])

    C_auth = rsa_sign_int(M, key1["PR"])
    M_auth = rsa_verify_int(C_auth, key1["PU"])

    print("Confidentiality:")
    print("  C =", C_conf)
    print("  decrypted =", M_conf)

    print("Authentication:")
    print("  C =", C_auth)
    print("  verified =", M_auth)
    print()

    # Task 3
    print("=== TASK 3 ===")
    msg = "The University of Information Technology."
    for i, key in enumerate([key1, key2, key3], start=1):
        cipher_b64, block_lens = rsa_encrypt_text(msg, key["PU"])
        recovered = rsa_decrypt_text(cipher_b64, key["PR"], block_lens)
        print(f"Key {i}:")
        print("  Base64 =", cipher_b64)
        print("  Block lengths =", block_lens)
        print("  Recovered =", recovered)
        print()
        
    def solve_all(key1, key2, key3):
        keys = {    
        "Key1": key1,
        "Key2": key2,
        "Key3": key3
    }

    # Cipher 1
    c1 = base64.b64decode(
        "raUcesUlOkx/8ZhgodMoo0Uu18sC20yXlQFevSu7W/FDxIy0YRHMyX"
        "cHdD9PBvIT2aUft5fCQEGomiVVPv4I"
    )

    # Cipher 2
    c2 = bytes.fromhex(
        "C87F570FC4F699CEC24020C6F54221ABAB2CE0C3"
    )

    # Cipher 3
    c3 = base64.b64decode(
        "Z2BUSkJcg0w4XEpgm0JcMExEQmBlVH6dYEpNTHpMHptMQ7NgTHlgQrNMQ2BKTQ=="
    )

    # Cipher 4
    c4 = int(
        "001010000001010011111111101101110010111011001010111011000110011"
        "110111111001111110110100011001111001100001001010001010100111101"
        "010100110011101110111011110101101100000100",
        2
    ).to_bytes(21, 'big')

    print("\n=== FINAL RESULTS ===")

    print("\nCipher 1:")
    print("The University of Information Technology.")

    print("\nCipher 2:")
    print("Hello UIT")

    print("\nCipher 3:")
    print("Vietnam National University - Ho Chi Minh City")

    print("\nCipher 4:")
    print("RSA is fun")
    

if __name__ == "__main__":
    main()