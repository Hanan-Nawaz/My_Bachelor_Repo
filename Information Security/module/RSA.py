import random

class RSA():
    def __init__(self):
        """
            Select primes and store them as p and q
        """

        self.p = self.generate_random_prime()
        self.q = self.generate_random_prime()
    
    def generate_random_prime(self):
        """
            -> generate a large random integer
                -> check if its a prime
                -> if not repeat.
        """

        max_prime_length = 1000000000000
        while(1):
            ran_prime = random.randint(1000, max_prime_length)
            if self.is_prime(ran_prime):
                return ran_prime

    def is_prime(self, num):
        """
            prime number: a whole number which isn't divisible by any other whole number rather than itself
            check if num = 2; 2 is only even prime number, return true
            check if num < 2; prime numbers cannot be smaller than 2
                [Logical OR] num % 2 == 0; check if num is divisible by 2 (is even number) as prime number
                                        cannot be even except 2.
            enter for loop:
            |    |-> start from 3
            |    |-> (upto sqrt of num) + 2
            |    |-> increment by 2 to get odd numbers
            |
            |--> check num is divisble by any other n; if yes return false

            else:
                Return true            
        """

        if num == 2:
            return True
        if num < 2 or num % 2 == 0:
            return False
        for n in range(3, int(num**0.5)+2, 2):
            if num % n == 0:
                return False
        return True
    
    def gcd(self, a, b):
        """
            Implementation of Euclidean algorithm to find GCD

            while b does not become zero, do the following:
            -> update value of a = b
            -> update value of b = a mod b
        
            return a
        """

        while b != 0:
            a, b = b, a % b
        return a

    def ext_gcd(self, a, b):
        """
            Implementation of Extended Euclidean algorithm
            Finds GCD as well as coefficients (x, y)

            if a = 0; we reached end hence b is GCD
                return a tuple (b, 0, 1) where b = gcd, 0 = x(coefficeint), 1 = y(coefficient)
            
            else recursive self call; store result in g, y, x
                return g = gcd, x - (b // a) = update value of x coefficient, y = remains same
        """
        
        if a == 0:
            return (b, 0, 1)
        else:
            g, y, x = self.ext_gcd(b % a, a)
            return (g, x - (b // a) * y, y)
    
    def generate_keys(self):
        """
            1. Store previously generated primes into local variables
            2. compute n = p * q
            3. computer PHI(n) = (p - 1) * (q - 1)
            4. choose a co-prime number (e) to (n) such that:
                4.1. (1 > e > phi(n))
                4.2. check if e and phi(n) are co-prime
                    4.2.1. if not choose another until gcd(e, phi(n)) = 1
            5. Select the first value return from the ext_gcd: which is the GCD of e and phi(n) as 'd'
            6. if 'd' isn't positive: check by (d = d mod z) should be zero
                6.1. if not increment d with z.
            7. return public = (e, n) and private = (d, n) keys.
        """
        p = self.p
        q = self.q
        
        n = p * q
        z = (p - 1) * (q - 1) 
        
        e = random.randint(1, z)
        
        g = self.gcd(e, z)
        while g != 1:
            e = random.randint(1, z)
            g = self.gcd(e, z)

        d = self.ext_gcd(e, z)[1]

        d = d % z
        if(d < 0):
            d += z
        
        public_key = (e,n)
        private_key = (d, n)
        return public_key, private_key 

    @staticmethod
    def encrypt(text, public_key):
        """
            RSA encryption with public key
                -> seperate tuple (e, n)
                -> ord(char) = convert character to its ASCII value
                -> pow(ord(char), key, n) = raise ASCII value of each character to power of key MOD n
                    -> c = m^e mod n
                -> ctext = [... for char in text] = python list comprehension to generate a list of encrypted message
                -> "".join(str(e) for e in ctext) = combine resulting list elements to create a single string
        """

        e, n = public_key
        ctext = [pow(ord(char), e, n) for char in text]
        return "".join(str(x) for x in ctext), ctext

    @staticmethod
    def decrypt(ctext, private_key):
        """
            RSA decryption with private key
                -> seperate tuple (d, n)
                -> pow(char, key, n) = raise ASCII value of each character to power of key MOD n
                    -> m = c^d mod n
                -> chr() = convert ASCII to characters
                ->text = [... for char in ctext] = python list comprehension to generate a list of decrypted message (character wise)
                -> "".join(text) = combine resulting list elements to create a single string
        """

        try:
            d,n = private_key
            text = [chr(pow(char, d, n)) for char in ctext]
            return "".join(text)
        except TypeError as e:
            print(e)
    
