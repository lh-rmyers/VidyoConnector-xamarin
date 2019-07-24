using System.Security.Cryptography;
[assembly: Xamarin.Forms.Dependency(typeof(VidyoConnector.MacOS.CryptoService))]

namespace VidyoConnector.MacOS
{
    public class CryptoService : ICryptoService
    {
        public byte[] ComputeHash(byte[] key, byte[] buffer)
        {
            HMACSHA384 hmacsha384 = new HMACSHA384(key);
            return hmacsha384.ComputeHash(buffer);
        }
    }
}