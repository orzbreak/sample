// 加解密

using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("輸入加密字串：");
            string word = Console.ReadLine();
      
            byte[] secret = Encrypt(word,new DESCryptoServiceProvider());
            Console.WriteLine("加密後字串：" + Encoding.UTF8.GetString(secret));
        
            string untie = Decrypt(secret, new DESCryptoServiceProvider());
            Console.WriteLine("解密後字串：" +untie);
            Console.ReadLine();
        }
        //金鑰
        static string encryptKey="Apple+" ;
        //加密
         static byte[] Encrypt(string PlainText, SymmetricAlgorithm Algorithm)
        {

            MemoryStream ms=new MemoryStream();
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);

            CryptoStream encStream = new CryptoStream(ms, Algorithm.CreateEncryptor(key, key), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(encStream);
            sw.WriteLine(PlainText);

            sw.Close();
            encStream.Close();
            byte[] buffer=ms.ToArray();
            ms.Close();
          

            return buffer;
        }
        //解密
        static string Decrypt(byte[] CypherText, SymmetricAlgorithm Algorithm)
        {

            MemoryStream ms =new MemoryStream(CypherText);
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);
            CryptoStream encStream = new CryptoStream(ms, Algorithm.CreateDecryptor(key, key), CryptoStreamMode.Read);
            
            StreamReader sr = new StreamReader(encStream);
            string val = sr.ReadLine();

            sr.Close();
            encStream.Close();
            ms.Close();
                
            return val;
        }
    }
}