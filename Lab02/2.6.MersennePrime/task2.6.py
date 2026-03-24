import random
from sympy import isprime, prevprime, randprime

def gcd(a, b):
    while b:
        a, b = b, a % b
    return abs(a)

def modular_pow(base, exp, mod):
    if mod == 1:
        return 0
    res = 1
    base %= mod
    while exp > 0:
        if exp % 2 == 1:
            res = (res * base) % mod
        base = (base * base) % mod
        exp //= 2
    return res

def main():
    # 1. Prime Number Operations
    print("--- Prime Number Generation ---")
    # Generating 8, 16, and 64-bit primes 
    print(f"8-bit prime: {randprime(2**7, 2**8)}") 
    print(f"16-bit prime: {randprime(2**15, 2**16)}") 
    print(f"64-bit prime: {randprime(2**63, 2**64)}") 

    print("\n--- 10 Largest Primes Less Than M10 ---")
    # M10 is defined as 2^89 - 1
    m10 = 2**89 - 1
    primes_under_m10 = []
    current = m10
    for _ in range(10):
        current = prevprime(current)
        primes_under_m10.append(current)
    print(primes_under_m10) 

    print("\n--- Primality Check (< 2^89 - 1) ---")
    #test_num = random.randint(2, m10-1)
    try:
        test_num = int(input("Enter number to test primality: "))
    except:
        test_num = random.randint(2, m10 - 1)
    print(f"Is {test_num} prime? {isprime(test_num)}")

    # 2. Greatest Common Divisor (GCD)
    print("\n--- Large Integer GCD ---")
    a = 12378678901765437890999456781634567643456543234567898765432
    b = 78765445231679210987687654321887654321098765432101234567890
    print(f"GCD: {gcd(a, b)}") 

    # 3. Modular Exponentiation
    print("\n--- Modular Exponentiation ---")
    # Calculation for exponents x > 40 
    try:
        base = int(input("Enter base: "))
        exp = int(input("Enter exponent: "))
        mod = int(input("Enter modulus: "))
    except:
        base, exp, mod = 7, 40, 19 #default values
    print(f"{base}^{exp} mod {mod} = {modular_pow(base, exp, mod)}")

if __name__ == "__main__":
    main()