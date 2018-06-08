using AutoMapper;
using System;

namespace CLSoft.MyWallet.Mappings
{
    public class AutomapperMapper : Mapper
    {
        private readonly IMapper _mapper;

        public AutomapperMapper(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override TDest Map<TDest>(object source)
        {
            return _mapper.Map<TDest>(source);
        }
    }
}