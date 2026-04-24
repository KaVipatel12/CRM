using CRM_Api.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CRM_Api.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly string _key;
        private readonly byte[] _salt;

        public EncryptionService(IConfiguration config)
        {
            var settings = config.GetSection("EncryptionSettings");
            _key = settings["Key"] ?? throw new InvalidOperationException("Encryption Key is missing in appsettings.json");
            var saltStr = settings["Salt"] ?? throw new InvalidOperationException("Encryption Salt is missing in appsettings.json");
            _salt = Encoding.ASCII.GetBytes(saltStr);
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;

            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_key, _salt, 10000, HashAlgorithmName.SHA256);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    plainText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return plainText;
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;

            try
            {
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_key, _salt, 10000, HashAlgorithmName.SHA256);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    
                    using (MemoryStream ms = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (MemoryStream msOutput = new MemoryStream())
                            {
                                cs.CopyTo(msOutput);
                                byte[] decryptedBytes = msOutput.ToArray();
                                return Encoding.Unicode.GetString(decryptedBytes);
                            }
                        }
                    }
                }
            }
            catch
            {
                return cipherText;
            }
        }
    }
}
