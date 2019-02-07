namespace MyLibrary.Mathematics.Cryptography
{
    public interface ICryptography
    {
        string Encryption(string plaintext);
        string Decryption(string ciphertext);
    }
}