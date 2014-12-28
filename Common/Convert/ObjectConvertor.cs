using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Convert
{
    public class ObjectConvertor
    {
        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            byte[] data;

            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                data = ms.ToArray();
            }
            
            return data;
        }
    }
}
