namespace portfolio_api.Dtos {
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

