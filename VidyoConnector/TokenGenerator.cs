using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VidyoConnector
{
    internal class TokenGenerator
    {
        private string Key { get; }
        private string AppId { get; }
        public string UserName { private get; set; } 
        private long ExpiresInSecs { get; }

        private const long EpochSeconds = 62167219200;

        public TokenGenerator(string key, string appId, string userName, long expiresInSecs)
        {
            Key = key;
            AppId = appId;
            UserName = userName;
            ExpiresInSecs = expiresInSecs;
        }

        public string GenerateToken()
        {
            TimeSpan timeSinceEpoch = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            string expires = (Math.Floor(timeSinceEpoch.TotalSeconds) + EpochSeconds + ExpiresInSecs).ToString();

            string jid = UserName + "@" + AppId;
            string body = "provision" + "\0" + jid + "\0" + expires + "\0" + "";

            var encoder = new UTF8Encoding();
            var cryptoService = DependencyService.Get<ICryptoService>();
            byte[] mac = cryptoService.ComputeHash(encoder.GetBytes(Key), encoder.GetBytes(body));

            // macBase64 can be used for debugging
            //string macBase64 = Convert.ToBase64String(hashmessage);

            // Get the hex version of the mac
            string macHex = BytesToHex(mac);

            string serialized = body + '\0' + macHex;

            return Convert.ToBase64String(encoder.GetBytes(serialized));
        }

        private static string BytesToHex(IReadOnlyCollection<byte> bytes)
        {
            var hex = new StringBuilder(bytes.Count * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
