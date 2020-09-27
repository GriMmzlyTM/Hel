using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hel.Toolkit.Serializer
{
    /// <summary>
    /// Helper class for serializing objects
    /// </summary>
    public static class ByteSerializer
    {
        /// <summary>
        /// Deserialize a loaded array of bytes back into an object.
        /// </summary>
        /// <param name="arrBytes">File data</param>
        /// <returns></returns>
        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            
            var obj = binForm.Deserialize(memStream);
            
            return obj;
        }

        /// <summary>
        /// Serialize an object into a byte array that can be written to a file
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(object obj)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            
            return ms.ToArray();
        }
    }
}