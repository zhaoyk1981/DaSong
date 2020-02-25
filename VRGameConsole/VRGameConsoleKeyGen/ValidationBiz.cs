using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsoleKeyGen
{
    public class ValidationBiz
    {
        private const string VALIDATION_FILE_PATH = "d:\\validation.dat";

        public string GetValidationData()
        {
            if (!File.Exists(VALIDATION_FILE_PATH))
            {
                return null;
            }

            return File.ReadAllText(VALIDATION_FILE_PATH, Encoding.UTF8);
        }

        public void SaveValidationData()
        {

        }

        public void Create(string content)
        {
            try
            {
                Delete();
                File.WriteAllText(VALIDATION_FILE_PATH, content, Encoding.UTF8);
                File.SetAttributes(VALIDATION_FILE_PATH, FileAttributes.Hidden | FileAttributes.System);
            }
            catch
            {
                Delete();
            }
        }

        public void Delete()
        {
            try
            {
                if (File.Exists(VALIDATION_FILE_PATH))
                {
                    File.Delete(VALIDATION_FILE_PATH);
                }
            }
            catch
            {

            }
        }

        public long GetLastAccessTime()
        {
            if (!File.Exists(VALIDATION_FILE_PATH))
            {
                return 0;
            }

            return File.GetLastAccessTimeUtc(VALIDATION_FILE_PATH).Ticks;
        }

        public void SetLastAccessTime()
        {
            if (!File.Exists(VALIDATION_FILE_PATH))
            {
                return;
            }

            File.SetLastAccessTimeUtc(VALIDATION_FILE_PATH, DateTime.UtcNow);
        }

        public bool Validate()
        {
            var str = GetValidationData();
            if (string.IsNullOrEmpty(str))
            {
                Delete();
                return false;
            }

            var cpuId = GetHash(this.GetCpuId());
            ComputerInfo model = null;
            try
            {
                model = JsonConvert.DeserializeObject<ComputerInfo>(DesDecrypt(str));
                if (model.CpuId != cpuId || model.DateStart > DateTime.UtcNow.Ticks || model.DateEnd < DateTime.UtcNow.Ticks || GetLastAccessTime() > DateTime.UtcNow.Ticks || model.Passed > DateTime.UtcNow.Ticks)
                {
                    Delete();
                    return false;
                }
            }
            catch
            {
                Delete();
                return false;
            }

            return true;
        }


        public string GetCpuId()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }

            return strID;
        }

        /// <summary> 加密字符串
        /// </summary> 
        /// <param name="strText">需被加密的字符串</param> 
        /// <param name="strEncrKey">密钥</param> 
        /// <returns></returns> 
        public static string DesEncrypt(string strText, string strEncrKey = "A~GJL&RY")
        {
            try
            {
                byte[] byKey = null;
                byte[] IV = { 0x13, 0x24, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

                byKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        /// <summary> 解密字符串
        /// </summary> 
        /// <param name="strText">需被解密的字符串</param> 
        /// <param name="sDecrKey">密钥</param> 
        /// <returns></returns> 
        public static string DesDecrypt(string strText, string sDecrKey = "A~GJL&RY")
        {
            try
            {
                byte[] byKey = null;
                byte[] IV = { 0x13, 0x24, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = new Byte[strText.Length];

                byKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = new UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return null;
            }
        }

        private const string Salt = "3741C199-78C6-4D73-9FF6-8995E9A036EB";

        private static string GetHash(string text)
        {
            // SHA512 is disposable by inheritance.
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text + Salt));
                // Get the hashed string.
                return BitConverter.ToString(hashedBytes)
                                   .Replace("-", "")
                                   .ToLower();
            }
        }

        public string GenKey(string cpuId, long start, long end)
        {
            var model = new ComputerInfo();
            model.CpuId = GetHash(cpuId);
            model.DateStart = start;
            model.DateEnd = end;
            var str = JsonConvert.SerializeObject(model);
            str = DesEncrypt(str);
            return str;
        }
    }
}
