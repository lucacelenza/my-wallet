using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Mappings.Home
{
    public class ColorValueResolver : IValueResolver<object, object, string>
    {
        private readonly Random _random;

        public ColorValueResolver(Random random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public string Resolve(object source, object destination, string destMember, ResolutionContext context)
        {
            return string.Format("#{0:X6}", _random.Next(0x1000000) & 0x7F7F7F);
        }
    }
}
