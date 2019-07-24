namespace VidyoConnector
{
    public interface ICryptoService
    {
        byte[] ComputeHash(byte[] key, byte[] buffer);
    }
}
