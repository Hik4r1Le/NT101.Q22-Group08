import re
import os
# ==========================================
# CẤU HÌNH TẦN SUẤT NGÔN NGỮ
# ==========================================
LANGUAGE_FREQS = {
    'english': [
        0.08167, 0.01492, 0.02782, 0.04253, 0.12702, 0.02228, 0.02015,
        0.06094, 0.06966, 0.00015, 0.00772, 0.04025, 0.02406, 0.06749,
        0.07507, 0.01929, 0.00095, 0.05987, 0.06327, 0.09056, 0.02758,
        0.00978, 0.02360, 0.00150, 0.01974, 0.00074
    ]
}
# ==========================================
# CÁC HÀM XỬ LÝ CỐT LÕI
# ==========================================
def normalize_text(text):
    return re.sub(r'[^a-z]', '', text.lower())

def calculate_ioc(text):
    n = len(text)
    if n <= 1: return 0
    counts = [text.count(chr(i + 97)) for i in range(26)]
    ioc = sum(c * (c - 1) for c in counts) / (n * (n - 1))
    return ioc

def find_key_length(ciphertext, max_len=20):
    ioc_results = []
    print("\n--- BƯỚC 1: Phân tích độ dài khóa (IoC) ---")
    for length in range(1, max_len + 1):
        columns = ['' for _ in range(length)]
        for i, char in enumerate(ciphertext):
            columns[i % length] += char
            
        avg_ioc = float(sum(calculate_ioc(col) for col in columns)) / length
        ioc_results.append((length, avg_ioc))
        
        bar = '*' * int(avg_ioc * 500)
        print(f"Độ dài {length:2d}: IoC = {avg_ioc:.4f} | {bar}")
        
    best_len, max_ioc = max(ioc_results, key=lambda x: x[1])
    
    final_len = best_len
    for length, ioc in ioc_results:
        if best_len % length == 0 and length < best_len:
            if ioc >= max_ioc * 0.9: 
                final_len = length
                break
                
    return final_len

def chi_squared(text, expected_freqs):
    n = len(text)
    counts = [text.count(chr(i + 97)) for i in range(26)]
    chi_sq = 0
    for i in range(26):
        expected = n * expected_freqs[i]
        if expected > 0:
            chi_sq += ((counts[i] - expected) ** 2) / expected
    return chi_sq

def find_key(ciphertext, key_len, language='english'):
    key = ""
    target_freqs = LANGUAGE_FREQS[language]
    columns = ['' for _ in range(key_len)]
    for i, char in enumerate(ciphertext):
        columns[i % key_len] += char

    for col_idx, col_text in enumerate(columns):
        best_shift = 0
        min_chi_sq = float('inf')
        for shift in range(26):
            shifted_text = "".join(chr(((ord(c) - 97 - shift) % 26) + 97) for c in col_text)
            
            chi_sq = float(chi_squared(shifted_text, target_freqs)) 
            
            if chi_sq < min_chi_sq:
                min_chi_sq = chi_sq
                best_shift = shift

        key += chr(int(best_shift) + 97)
    return key

def decrypt_vigenere(ciphertext, key):
    plaintext = ""
    key_idx = 0
    for char in ciphertext:
        if char.isalpha():
            is_upper = char.isupper()
            c_val = ord(char.lower()) - 97
            k_val = ord(key[key_idx % len(key)]) - 97
            p_val = (c_val - k_val) % 26
            decrypted_char = chr(p_val + 97)
            plaintext += decrypted_char.upper() if is_upper else decrypted_char
            key_idx = key_idx + 1  # type: ignore
        else:
            plaintext += char
            
    return plaintext

# ==========================================
# KHỐI GIAO DIỆN & NHẬP LIỆU
# ==========================================

def get_input_data():
    """Hàm xử lý menu tương tác để lấy ciphertext."""
    default_text = """
    pp oiuibvql avpgzwm, vyabnwzycbbg klhqla mv uqwckl kzzwktcfcwg hpp
    wwftwzcktakah bxjjzcynlu pyzbcgp zzht omnpxtcfckts eahkxwve uvw
    h uqn wy ywxy-jtzgp wiejwxubbvpe wiesgp utzvtunpfz va nztuurizf
    tgemizlu uh etfu fbim htq bikk va xmvprtyz. mogey lxagdgqgpufck
    tsialqmooe uzx buqx nhy edsxmviduxape wyg zlpqlimpqz uvw kkscbts
    uuavbui mhl oltuzqvhvuiv mv rdibxjv pubt wtupivf, yqv jkvyecvz vp
    fbm buvqlvxa czx khuhuxmgakmf khtoghqvhvuivl zwob il jtqxqm jcdx
    bkhpeukmpqzm igk gyuqe.
    """
    
    while True:
        print("\n" + "="*50)
        print(" VUI LÒNG CHỌN NGUỒN DỮ LIỆU ĐẦU VÀO ".center(50))
        print("="*50)
        print("1. Đọc ciphertext từ file (.txt)")
        print("2. Nhập trực tiếp ciphertext từ bàn phím")
        print("3. Sử dụng đoạn ciphertext mặc định của bài tập")
        print("0. Thoát chương trình")
        
        choice = input("\nNhập lựa chọn của bạn (0-3): ").strip()
        
        if choice == '1':
            filepath = input("Nhập tên file: ").strip()
            if os.path.exists(filepath):
                with open(filepath, 'r', encoding='utf-8') as f:
                    return f.read()
            else:
                print(f"[!] Lỗi: Không tìm thấy file '{filepath}'. Vui lòng thử lại!")
                
        elif choice == '2':
            print("\nNhập ciphertext (nhấn Enter 2 lần liên tiếp để kết thúc):")
            lines = []
            while True:
                try:
                    line = input()
                    if not line: 
                        break
                    lines.append(line)
                except EOFError:
                    break
            return '\n'.join(lines)
            
        elif choice == '3':
            return default_text
            
        elif choice == '0':
            print("Đang thoát chương trình...")
            exit()
        else:
            print("[!] Lựa chọn không hợp lệ, vui lòng nhập từ 0 đến 3.")

# ==========================================
# KHỐI THỰC THI CHÍNH
# ==========================================
if __name__ == "__main__":
    print("="*60)
    print(" HỆ THỐNG PHÁ MÃ VIGENÈRE TỰ ĐỘNG (CIPHERTEXT-ONLY ATTACK) ".center(60))
    print("="*60)
    
    raw_ciphertext = get_input_data()
    
    if raw_ciphertext is None or not raw_ciphertext.strip():
        print("[!] Không có dữ liệu để xử lý. Thoát...")
        exit()
        
    print("\n[Đang chuẩn hóa dữ liệu đầu vào...]")
    normalized_cipher = normalize_text(raw_ciphertext)
    
    key_length = find_key_length(normalized_cipher)
    print(f"\n=> BƯỚC 1: Độ dài khóa tối ưu là {key_length}")
    
    print("\n--- BƯỚC 2: Phân tích tần suất Chi-square ---")
    found_key = find_key(normalized_cipher, key_length, language='english')
    print(f"=> BƯỚC 2: Từ khóa tìm được là: '{found_key.upper()}'")
    
    print("\n--- BƯỚC 3: Tiến hành giải mã ---")
    plaintext = decrypt_vigenere(raw_ciphertext, found_key)
    
    print("\n" + "="*60)
    print("PLAINTEXT".center(60, "="))
    print("="*60)
    print(plaintext.strip())
    print("="*60)