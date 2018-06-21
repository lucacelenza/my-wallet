using AutoMapper;
using CLSoft.MyWallet.Business.Encryption;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class HashedStringResolver : IMemberValueResolver<object, object, string, string>
    {
        private readonly IEncryption _encryption;

        public HashedStringResolver(IEncryption encryption)
        {
            _encryption = encryption ?? throw new ArgumentNullException(nameof(encryption));
        }

        public string Resolve(object source, object destination, string sourceMember, string destMember, ResolutionContext context)
        {
            return _encryption.Encrypt(sourceMember);
        }
    }
}