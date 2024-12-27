using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace portfolio_api.Dtos.Profile {
    // [JsonConverter(typeof(StringEnumConverter))]
    public enum SocialMediaKind {
        // [EnumMember(Value = "connect")]
        Connect,
        // [EnumMember(Value = "disconnect")]
        Disconnect
    };
    public class ConnectOrDisconnectSocialMediaDto {
        public required string SocialMediaID { get; set; }
        // [JsonConverter(typeof(StringEnumConverter))]
        public required SocialMediaKind Kind { get; set; }
    }
}

