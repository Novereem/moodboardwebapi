using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using mb.Common;
using mb.Common.Models;
using mb.Common.Models.ApiModels;
using Microsoft.AspNetCore.Http;

namespace mb.Logic
{
    public class MoodboardService
    {
        private readonly IMoodboardData _moodboardData;
        private readonly AccountService _accountService;

        public MoodboardService(IMoodboardData moodboardData)
        {
            _moodboardData = moodboardData;
        }

        public void AddMoodboard(ApiMoodboard apiMoodboard)
        {
            //debugging
            string name = EncryptString(apiMoodboard.Account);
            apiMoodboard.Name = DecryptString(name);
            _moodboardData.AddMoodboard(apiMoodboard);
        }

        public List<Post> AddPost(ApiPost apiPost)
        {
            Post post = new Post(apiPost.FirstName, apiPost.LastName, apiPost.Email, apiPost.Text, "");
            return _moodboardData.AddPost(post);
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