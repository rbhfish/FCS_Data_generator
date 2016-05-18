using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FCSDataProductor
{
    public class SingletonFCSDataEncodingTool
    {
        private volatile static SingletonFCSDataEncodingTool _instance = null;
        private static readonly object lockHelper = new object();
        private SingletonFCSDataEncodingTool() { }
        public static SingletonFCSDataEncodingTool CreateInstance() {
            if (_instance == null) {
                lock (lockHelper) {
                    if (_instance == null)
                        _instance = new SingletonFCSDataEncodingTool();
                }
            }
            return _instance;
        }
        //convert key(ascii)-value(utf8) to byte string
        public void ConvertKeyVlaue2Byte(string strKey,string strValue,ref byte[] bMem)
        {
            //byte[] bMem = null;
            ASCIIEncoding ascii = new ASCIIEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] bKey = ascii.GetBytes(strKey);
            byte[] bValue = utf8.GetBytes(strValue);
            bMem = new byte[bKey.Length + bValue.LongLength];
            Buffer.BlockCopy(bKey,0,bMem,0,bKey.Length);
            Buffer.BlockCopy(bValue, 0, bMem, bKey.Length, bValue.Length);
            //Console.WriteLine("I am here");
        }
        //write byte string into file
        public void WriteBinaryStream2File(string strPath,byte[] bMem) 
        {
            FileStream fs = new FileStream(strPath.ToString(), FileMode.Append);
            BinaryWriter writeBinary = new BinaryWriter(fs);
            writeBinary.Write(bMem);
            writeBinary.Close();
            fs.Close();
        }
        
    }
}
