using portfolio_api.Enums;

namespace portfolio_api.Dtos.ProfileDtos
{
    public class ConnectOrDisconnectPostDto
    {
        public required string PostID { get; set; }
        public required ConnectOrDisconnect Kind { get; set; }
    }
}