using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCTask
{
    class CBCAlgorithm
    {   //шифрация 
        public static UInt64 initVector = 5678432;

        public static UInt64[] CBCEncrypt(UInt64[] plainText) {
            var encryptedBlocks = new UInt64[plainText.Count()];//зашифрованные блоки
            encryptedBlocks[0] = FeistelNet.FeistelNetClass
                                .encryptBlock(plainText[0] ^ initVector);
            //шифрование каждого последующего блока на основе xor с предыдущим зашифрованным
            for(int i=1;i <plainText.Length;i++){
                encryptedBlocks[i] =
                    FeistelNet.FeistelNetClass.encryptBlock(plainText[i] ^ encryptedBlocks[i - 1]);
            }
            return encryptedBlocks;
        }
        //дешифрация
        public static UInt64[] CBCDecrypt(UInt64[] encryptedText)
        {
            var decryptedBlocks = new UInt64[encryptedText.Length];
            decryptedBlocks[0] = initVector ^
                FeistelNet.FeistelNetClass.decryptBlock(encryptedText[0]);
            //расшифрование каждого последующео блока на основе xor с зашифрованным предыдущим
            for(int i = 1; i < decryptedBlocks.Length; i++) {
                decryptedBlocks[i] = encryptedText[i - 1] ^
                    FeistelNet.FeistelNetClass.decryptBlock(encryptedText[i]);
            }
            return decryptedBlocks;
        }
    }
}
