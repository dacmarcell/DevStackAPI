namespace portfolio_api.Dtos.Profile {
    public enum SocialMediaKind {Connect, Disconnect};
    public class ConnectOrDisconnectSocialMediaDto {
        public required string SocialMediaID { get; set; }
        public required SocialMediaKind Kind { get; set; }
    }
}

