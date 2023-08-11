using System.IO;
using System.Security.Cryptography;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public static class AesEncryptor
{
    public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
    {
        //check arguments
        if (plainText == null || plainText.Length <= 0)
        {
            throw new ArgumentNullException(nameof(plainText));
        }

        if (Key == null || Key.Length <= 0)
        {
            throw new ArgumentNullException(nameof(Key));
        }

        if (IV == null || IV.Length <= 0)
        {
            throw new ArgumentNullException(nameof(IV));
        }

        byte[] encrypted;

        using (AesCryptoServiceProvider aesAIg = new())
        {
            aesAIg.Key = Key;
            aesAIg.IV = IV;

            ICryptoTransform encryptor = aesAIg.CreateEncryptor(aesAIg.Key, aesAIg.IV);

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                //Write all data to the stream
                swEncrypt.Write(plainText);
            }

            encrypted = msEncrypt.ToArray();
        }

        //Return the encrypted bytes from the memory stream
        return encrypted;
    }

    //public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    //{
    //    if (cipherText == null || cipherText.Length <= 0)
    //        throw new ArgumentNullException("cypherText");
    //    if (Key == null || Key.Length <= 0)
    //        throw new ArgumentNullException("Key");
    //    if (IV == null || IV.Length <= 0)
    //        throw new ArgumentNullException("Key");

    // string plaintext = null;

    // using (AesCryptoServiceProvider aesAIg = new AesCryptoServiceProvider()) { aesAIg.Key =
    // Key; aesAIg.IV = IV;

    // ICryptoTransform decryptor = aesAIg.CreateDecryptor(aesAIg.Key, aesAIg.IV);

    // using (MemoryStream msDecrypt = new MemoryStream(cipherText)) { using (CryptoStream
    // csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) { using
    // (StreamReader srDecrypt = new StreamReader(csDecrypt)) { //Write all data to the stream
    // plaintext = srDecrypt.ReadToEnd(); }

    //            }
    //        }
    //    }
    //    return plaintext;
    //}

    public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
        {
            throw new ArgumentNullException(nameof(cipherText));
        }

        if (Key == null || Key.Length <= 0)
        {
            throw new ArgumentNullException(nameof(Key));
        }

        if (IV == null || IV.Length <= 0)
        {
            throw new ArgumentNullException(nameof(IV));
        }

        // Declare the string used to hold the decrypted text.
        string? plaintext = null;

        // Create an Aes object with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using MemoryStream msDecrypt = new(cipherText);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            // Read the decrypted bytes from the decrypting stream and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
        }

        return plaintext;
    }
}