namespace CLSoft.MyWallet.Business.Encryption
{
    public interface IEncryption
    {
        string Encrypt(string clearString);
        bool Validate(string clearString, string hashedString);
    }
}