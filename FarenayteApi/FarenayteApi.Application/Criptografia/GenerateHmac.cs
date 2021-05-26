using System;
using System.Security.Cryptography;
using System.Text;

public class GenerateHmac
{
    public const string privateKey = "kdfjhgkhs3432jgh!xgy@guas$342fr4rfuyge%fiuy%c87y87yfdedfsdhg@#$#¨%$dsudsaasf";

    public static string HmacSHA256(string text)
    {
        // change according to your needs, an UTF8Encoding
        // could be more suitable in certain situations
        ASCIIEncoding encoding = new ASCIIEncoding();

        Byte[] textBytes = encoding.GetBytes(text);
        Byte[] keyBytes = encoding.GetBytes(privateKey);

        Byte[] hashBytes;

        using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            hashBytes = hash.ComputeHash(textBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}