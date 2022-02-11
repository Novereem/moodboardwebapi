using System;
using System.Security.Cryptography;
using System.Text;
using mb.Common;
using mb.Common.Models;
using mb.Common.Models.ApiModels;

namespace mb.Logic
{
    public class AccountService
    {
        private readonly IAccountData _accountData;

        public AccountService(IAccountData accountData)
        {
            _accountData = accountData;
        }

        public string Register(ApiAccount apiAccount)
        {
            Account account = new Account(apiAccount.Email, apiAccount.Username, apiAccount.Password);
            return _accountData.Register(account);
        }

        public string Login(ApiAccount apiAccount)
        {
            Account account = new Account(apiAccount.Username, apiAccount.Password);
            Account checkAccount = _accountData.GetAccount(account.Username);
            if (account.Password != checkAccount.Password)
            {
                return "/403";
            }
            
            return EncryptString(account.Username);
        }
        
        private string EncryptString(string text)
        {
            string hash = "43&v#94nv"; // moet van local private variable komen
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                    {Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string newText = Convert.ToBase64String(results, 0, results.Length);
                    return newText;
                }
            }
        }
        
        private string DecryptString(string text)
        {
            string hash = "43&v#94nv"; // moet van local private variable komen
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                    {Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}