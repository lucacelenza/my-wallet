using BCrypt;
using CLSoft.MyWallet.Business.Encryption;

namespace CLSoft.MyWallet.Components.Encryption
{
    public class BCryptEncryption : IEncryption
    {
        public string Encrypt(string clearString)
        {
            var salt = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(clearString, salt);
        }

        public bool Validate(string clearString, string hashedString)
        {
            return BCryptHelper.CheckPassword(clearString, hashedString);
        }
    }
}