using portfolio_api.Enums;

namespace portfolio_api.Dtos {
    public class ConnectOrDisconnectSocialMediaDto {
        public required string SocialMediaID { get; set; }
        public required SocialMediaKind Kind { get; set; }
    }
}