using portfolio_api.Enums;

namespace portfolio_api.Dtos.ProfileDtos {
    public class ConnectOrDisconnectSocialMediaDto {
        public required string SocialMediaID { get; set; }
        public required ConnectOrDisconnect Kind { get; set; }
    }
}