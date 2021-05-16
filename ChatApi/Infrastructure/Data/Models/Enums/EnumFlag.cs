using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChatApi.Infrastructure.Models.Enums
{
    public enum EnumFlag
    {
        [JsonConverter(typeof(StringEnumConverter))]
        N = 0,

        [JsonConverter(typeof(StringEnumConverter))]
        Y = 1


    }
}