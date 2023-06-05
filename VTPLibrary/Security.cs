using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace VTPLibrary
{
    public class Security
    {
        private static readonly string _publicKey =
            "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA0htfjoCHRwgA0fa6RZ1l" +
            "Fx9Eiz1iapyLVytBxw3YCDR5flYiKlZYBJoDP4jCFU7Gg/iLrEtADq5deQuTHFtS" +
            "/weCKyScNHFr3ziFp2rYu9A4D8tQFhZCmMtoq64hkGJ6iHSDk4zJtKY/7vGWU8HX" +
            "oBZHgsNM0scxN132YFudkDrLzbfW0afr1CDxlQqlCHIDiEHvA/7w1Hw3v70JTErW" +
            "65+eMUILXKRaGtLx9LdIjzQdTlWqmKV0/yGQCjnBwm3wEZ3nSWsY+PKUVGfsl0K6" +
            "KUQdz550fYcET3qUXtzoYnkB7XXmG2za79+gOfTdCUIJXCqsgyRvIfINeHpfcfxU" +
            "hQIDAQAB";

        public static string CreateKey(string key, string msisdn, string threadId)
        {
            var keyBytes = Convert.FromBase64String(_publicKey);
            var message = JsonConvert.SerializeObject(new { key, msisdn, threadId });
            var messageBytes = Encoding.UTF8.GetBytes(message);

            using var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);
            var encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string TripleDesEncrypt(string message, string key, string iv)
        {
            var des = CreateDes(key, iv);
            var ct = des.CreateEncryptor();
            var input = Encoding.UTF8.GetBytes(message);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
        }

        public static string TripleDesDecrypt(string data, string key, string iv)
        {
            var des = CreateDes(key, iv);
            var ct = des.CreateDecryptor();
            var input = Convert.FromBase64String(data);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Encoding.UTF8.GetString(output);
        }


        private static TripleDES CreateDes(string key, string iv)
        {
            using var md5 = MD5.Create();
            using var des = TripleDES.Create();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(iv);
            des.Padding = PaddingMode.PKCS7;
            des.Mode = CipherMode.CBC;
            return des;
        }
    }
}
