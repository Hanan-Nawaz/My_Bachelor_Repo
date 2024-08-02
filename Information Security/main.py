from module.RSA import RSA
from utils.colors import colors

if __name__ == '__main__':
    public_key, private_key = RSA().generate_keys() 
    print(f"{colors.blue_filled_bullet} Public key: {colors.BLUE}", public_key, f"{colors.RESET}")
    print(f"{colors.green_filled_bullet} Private key: {colors.GREEN}", private_key, f"{colors.RESET}")
    
    shower, ctext = RSA().encrypt("Hello World",public_key)
    print(f"\n{colors.yellow_unfilled_bullet} Encrypted message\n----------------")
    print(f"{colors.YELLOW}", shower, f"{colors.RESET}\n----------------")
    plaintext = RSA().decrypt(ctext, private_key)
    print(f"\n{colors.green_filled_bullet} Decrypted message\n----------------")
    print(f"{colors.GREEN}", plaintext, f"{colors.RESET}\n----------------")    
