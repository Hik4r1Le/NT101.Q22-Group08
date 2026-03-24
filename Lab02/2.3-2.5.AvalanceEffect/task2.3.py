from Crypto.Cipher import DES

def avalanche_test(key):
    p1 = b'STAYHOME'
    p2 = b'STAYHOMA'
    #DES at ECB mode
    cipher = DES.new(key, DES.MODE_ECB)

    ct1 = cipher.encrypt(p1)
    ct2 = cipher.encrypt(p2)

    # bytes to binary strings for bit comparison
    #use 2:.zfill(64) to ensure 64 bits (8 bytes) representation
    bin_ct1 = bin(int.from_bytes(ct1, 'big'))[2:].zfill(64)
    bin_ct2 = bin(int.from_bytes(ct2, 'big'))[2:].zfill(64)

    # count different bits (Hamming distance)
    hamming_distance = sum(b1 != b2 for b1, b2 in zip(bin_ct1, bin_ct2))

    total_bits = 64
    percent_changed = (hamming_distance / total_bits) * 100

    print(f"--- Key: {key} ---")
    print(f"Text 1 (p1): {bin_ct1}")
    print(f"Text 2 (p2): {bin_ct2}")
    print(f"Hamming Distance: {hamming_distance}/{total_bits} bit")
    print(f"Percentage of changed bits:   {percent_changed:.2f}%\n")

def main():
    avalanche_test(b'24520742')
    avalanche_test(b'23520617')
    avalanche_test(b'23520622')

if __name__ == "__main__":
    main()