def encrypt_rail_fence(text, key):
    # create the matrix to cipher plain text
    rail = [['\n' for i in range(len(text))] for j in range(key)]
    
    # find the direction to move in the matrix
    direction_down = False
    row, col = 0, 0
    
    for char in text:
        # change direction when reaching the top or bottom rail
        if (row == 0) or (row == key - 1):
            direction_down = not direction_down
        
        rail[row][col] = char
        col += 1
        
        row += 1 if direction_down else -1
    
    # read result row by row
    result = []
    for i in range(key):
        for j in range(len(text)):
            if rail[i][j] != '\n':
                result.append(rail[i][j])
    return "".join(result)

def decrypt_rail_fence(cipher, key):
    rail = [['\n' for i in range(len(cipher))] for j in range(key)]
    
    # mark '*' with the zigzag pattern
    direction_down = None
    row, col = 0, 0
    for i in range(len(cipher)):
        if row == 0: direction_down = True
        if row == key - 1: direction_down = False
        
        rail[row][col] = '*'
        col += 1
        row += 1 if direction_down else -1
    
    # fill the marked positions with cipher text
    index = 0
    for i in range(key):
        for j in range(len(cipher)):
            if (rail[i][j] == '*') and (index < len(cipher)):
                rail[i][j] = cipher[index]
                index += 1
    
    # read the matrix in zig-zag manner to construct the original text
    result = []
    row, col = 0, 0
    for i in range(len(cipher)):
        if row == 0: direction_down = True
        if row == key - 1: direction_down = False
        
        if rail[row][col] != '\n':
            result.append(rail[row][col])
            col += 1
        
        row += 1 if direction_down else -1
    return "".join(result)

if __name__ == "__main__":
    plaintext = "Triumph's the better ending. Wielding a flower in one grasp, and its thorns in the other... Be steady and go forth, ye hand of God. Flourish Beyond, in \"Axium Divergence\"."
    key = 3
    ciphertext = encrypt_rail_fence(plaintext, key)
    decrypted = decrypt_rail_fence(ciphertext, key)
    
    print("=" * 50)
    print(f"Plaintext: {plaintext}")
    print(f"Key: {key}")
    print("=" * 50)
    print(f"Ciphertext: {ciphertext}")
    print("=" * 50)
    print(f"Decrypted: {decrypted}")