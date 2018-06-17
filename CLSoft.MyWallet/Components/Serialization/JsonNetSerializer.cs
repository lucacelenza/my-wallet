using CLSoft.MyWallet.Business.Serialization;
using Newtonsoft.Json;

namespace CLSoft.MyWallet.Components.Serialization
{
    public class JsonNetSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}