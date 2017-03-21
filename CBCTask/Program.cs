using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCTask
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "1234567887654321darya";
            UInt64[] blocks = FeistelNet.FeistelNetClass.GetBlocks(text);
            //шифрование
            UInt64[] resultEncrypted = CBCAlgorithm.CBCEncrypt(blocks);
            String cipherText =
                Encoding.ASCII.GetString(resultEncrypted.SelectMany(r => BitConverter.GetBytes(r).Reverse()).ToArray());          
            Console.WriteLine("Encrypted text: {0}", cipherText);
            //дешифрование
            UInt64[] resultDecrypted = CBCAlgorithm.CBCDecrypt(resultEncrypted);
            String plainText =
                Encoding.ASCII.GetString(resultDecrypted.SelectMany(r => BitConverter.GetBytes(r).Reverse()).ToArray());
            //убираем с конца лишние символы
            plainText = plainText.Substring(0, text.Length);
            Console.WriteLine("Decrypted text: {0}", plainText);
            Console.ReadLine();
        }
    }
}
